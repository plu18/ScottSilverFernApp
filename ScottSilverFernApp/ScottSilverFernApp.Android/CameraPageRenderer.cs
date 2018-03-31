using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ScottSilverFernApp;
using ScottSilverFernApp.Droid;
using Android.App;
using Android.Content;
using Android.Hardware;
using Android.Views;
using Android.Graphics;
using Android.Widget;
using System.Threading.Tasks;
using System.Net.Http;
using ScottSilverFernApp.CustomGoogleMap;
using System.Net.Http.Headers;
using ScottSilverFernApp.Models;
using System.Collections.Generic;
using ScottSilverFernApp.Services;
using System.Linq;
using Plugin.Media;
using ScottSilverFernApp.Helpers;

[assembly: ExportRenderer(typeof(CustomCameraPage), typeof(CameraPageRenderer))]
namespace ScottSilverFernApp.Droid
{
    public class CameraPageRenderer : PageRenderer, TextureView.ISurfaceTextureListener
    {
        global::Android.Hardware.Camera camera;
        global::Android.Widget.Button takePhotoButton;
        global::Android.Widget.Button toggleFlashButton;
        global::Android.Widget.Button switchCameraButton;
        global::Android.Widget.Button galleryButton;
        global::Android.Widget.Button backButton;
        global::Android.Views.View view;

        Activity activity;
        CameraFacing cameraType;
        TextureView textureView;
        SurfaceTexture surfaceTexture;

        bool isLoading = false;

        bool flashOn;

        public CameraPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                SetupUserInterface();
                SetupEventHandlers();
                AddView(view);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"			ERROR: ", ex.Message);
            }
        }

        void SetupUserInterface()
        {
            activity = this.Context as Activity;
            view = activity.LayoutInflater.Inflate(Resource.Layout.CameraLayout, this, false);
            cameraType = CameraFacing.Back;

            textureView = view.FindViewById<TextureView>(Resource.Id.textureView);
            textureView.SurfaceTextureListener = this;
        }

        void SetupEventHandlers()
        {
            takePhotoButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.takePhotoButton);
            takePhotoButton.Click += TakePhotoButtonTapped;

            switchCameraButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.switchCameraButton);
            switchCameraButton.Click += SwitchCameraButtonTapped;

            toggleFlashButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.toggleFlashButton);
            toggleFlashButton.Click += ToggleFlashButtonTapped;

            galleryButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.galleryButton);
            galleryButton.Click += GalleryButtonTapped;

            //backButton = view.FindViewById<global::Android.Widget.Button>(Resource.Id.backButton);
            //backButton.Click += BackButtonTapped;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

            view.Measure(msw, msh);
            view.Layout(0, 0, r - l, b - t);
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {

        }

        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            camera = global::Android.Hardware.Camera.Open((int)cameraType);
            textureView.LayoutParameters = new FrameLayout.LayoutParams(width, height);
            surfaceTexture = surface;

            camera.SetPreviewTexture(surface);
            PrepareAndStartCamera();
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            camera.StopPreview();
            camera.Release();
            return true;
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
            PrepareAndStartCamera();
        }


        void PrepareAndStartCamera()
        {
            camera.StopPreview();

            var display = activity.WindowManager.DefaultDisplay;
            if (display.Rotation == SurfaceOrientation.Rotation0)
            {
                camera.SetDisplayOrientation(90);
            }

            if (display.Rotation == SurfaceOrientation.Rotation270)
            {
                camera.SetDisplayOrientation(180);
            }

            camera.StartPreview();
        }

        void ToggleFlashButtonTapped(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            flashOn = !flashOn;
            if (flashOn)
            {
                if (cameraType == CameraFacing.Back)
                {
                    toggleFlashButton.SetBackgroundResource(Resource.Drawable.FlashButton);
                    cameraType = CameraFacing.Back;

                    camera.StopPreview();
                    camera.Release();
                    camera = global::Android.Hardware.Camera.Open((int)cameraType);
                    var parameters = camera.GetParameters();
                    parameters.FlashMode = global::Android.Hardware.Camera.Parameters.FlashModeTorch;
                    camera.SetParameters(parameters);
                    camera.SetPreviewTexture(surfaceTexture);
                    PrepareAndStartCamera();
                }
            }
            else
            {
                toggleFlashButton.SetBackgroundResource(Resource.Drawable.NoFlashButton);
                camera.StopPreview();
                camera.Release();

                camera = global::Android.Hardware.Camera.Open((int)cameraType);
                var parameters = camera.GetParameters();
                parameters.FlashMode = global::Android.Hardware.Camera.Parameters.FlashModeOff;
                camera.SetParameters(parameters);
                camera.SetPreviewTexture(surfaceTexture);
                PrepareAndStartCamera();
            }
        }

        void SwitchCameraButtonTapped(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (cameraType == CameraFacing.Front)
            {
                cameraType = CameraFacing.Back;

                camera.StopPreview();
                camera.Release();
                camera = global::Android.Hardware.Camera.Open((int)cameraType);
                camera.SetPreviewTexture(surfaceTexture);
                PrepareAndStartCamera();
            }
            else
            {
                cameraType = CameraFacing.Front;

                camera.StopPreview();
                camera.Release();
                camera = global::Android.Hardware.Camera.Open((int)cameraType);
                camera.SetPreviewTexture(surfaceTexture);
                PrepareAndStartCamera();
            }
        }

        async void TakePhotoButtonTapped(object sender, EventArgs e)
        {
            if (isLoading)
                return;
            camera.StopPreview();
            isLoading = true;
            MessagingCenter.Send<CustomCameraPage>(CustomCameraPage.getInstance(), "StartLoading");

            var image = textureView.Bitmap;

            try
            {
                var absolutePath = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim).AbsolutePath;
                var folderPath = absolutePath + "/Camera";
                var filePath = System.IO.Path.Combine(folderPath, string.Format("photo_{0}.jpg", Guid.NewGuid()));

                FileStream fileStream = new FileStream(filePath, FileMode.Create);
                await image.CompressAsync(Bitmap.CompressFormat.Jpeg, 50, fileStream);
                
                var intent = new Android.Content.Intent(Android.Content.Intent.ActionMediaScannerScanFile);
                var file = new Java.IO.File(filePath);

                var uri = Android.Net.Uri.FromFile(file);
                intent.SetData(uri);
                MainActivity.Instance.SendBroadcast(intent);

                Stream stream = fileStream as Stream;

                //MessagingCenter.Send<CustomCameraPage>(CustomCameraPage.getInstance(), "Navigation");
                //MessagingCenter.Send<CustomCameraPage, string>(CustomCameraPage.getInstance(), "PathSend", filePath);

                List<Species> speciesList = await CameraHelper.CommonOperationCameraLibPictures(stream);

                MessagingCenter.Send<CustomCameraPage, List<Species>>(CustomCameraPage.getInstance(), "StreamSend", speciesList);
                //MessagingCenter.Send<CustomCameraPage, Stream>(CustomCameraPage.getInstance(), "StreamSend", stream);

                fileStream.Close();
                image.Recycle();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"				", ex.Message);
            }

            isLoading = false;
            MessagingCenter.Send<CustomCameraPage>(CustomCameraPage.getInstance(), "StopLoading");
            camera.StartPreview();
        }

        async void GalleryButtonTapped(object sender, EventArgs e)
        {
            if (isLoading)
                return;

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            if (file == null)
                return;

            MessagingCenter.Send<CustomCameraPage>(CustomCameraPage.getInstance(), "StartLoading");
            camera.StopPreview();
            isLoading = true;

            Stream stream = file.GetStream();


            List<Species> speciesList = await CameraHelper.CommonOperationCameraLibPictures(stream);

            MessagingCenter.Send<CustomCameraPage, List<Species>>(CustomCameraPage.getInstance(), "StreamSend", speciesList);

            MessagingCenter.Send<CustomCameraPage>(CustomCameraPage.getInstance(), "StopLoading");
            isLoading = false;
            file.Dispose();
            camera.StartPreview();
        }

        async void BackButtonTapped(object sender, EventArgs e)
        {

        }


        public Stream LoadFromFile(string fileName)
        {
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            return System.IO.File.OpenRead(root + "/Syncfusion/" + fileName.ToString());
        }

    }
}