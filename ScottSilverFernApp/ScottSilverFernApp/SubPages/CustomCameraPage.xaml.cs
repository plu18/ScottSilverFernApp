using ScottSilverFernApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScottSilverFernApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScottSilverFernApp.Helpers;

namespace ScottSilverFernApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomCameraPage : ContentPage
	{
        private static CustomCameraPage instance = null;
        public CustomCameraPage ()
		{
            
            InitializeComponent();
            this.BindingContext = this;
            this.IsBusy = false;

            MessagingCenter.Subscribe<CustomCameraPage>(this, "StartLoading", async (sender) =>
            {
                this.IsBusy = true;
            });

            MessagingCenter.Subscribe<CustomCameraPage>(this, "StopLoading", async (sender) =>
            {
                this.IsBusy = false;
            });

            MessagingCenter.Subscribe<CustomCameraPage, List<Species>>(this, "StreamSend", async (sender, arg) =>
            {
                
                //List<Species> speciesList = await CameraHelper.CommonOperationCameraLibPictures(arg);

                IdentifyListPage identifyListPage = new IdentifyListPage();
                
                //await DisplayAlert(speciesList.Count.ToString(), "NULL", "KKKKKKKKKK");
                if (arg.Any())
                    identifyListPage.Content = new IdentifyListView(arg);

                this.IsBusy = false;

                await Navigation.PushAsync(identifyListPage);
                
            });
        }
        

        public static CustomCameraPage getInstance()
        {
            if (instance == null)
                instance = new CustomCameraPage();

            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
                instance = null;
        }
    }
}