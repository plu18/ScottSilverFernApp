using System;
using Android.App;
using Android.Runtime;

using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;

namespace ScottSilverFernApp.Droid
{
    [Application]
    [MetaData("com.google.android.maps.v2.API_KEY", Value = "AIzaSyBhI_hEm0TkUfYkT9hvn5PS5GMKMs9zquk")]
    public class MyApp : Application, Application.IActivityLifecycleCallbacks
    {
        public MyApp(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            //A great place to initialize Xamarin.Insights and Dependency Services!
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}