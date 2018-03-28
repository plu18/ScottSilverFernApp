using System;
using Android.App;
using Android.Runtime;
using ScottSilverFernApp.CustomGoogleMap;

using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Plugin.CurrentActivity;

namespace ScottSilverFernApp.Droid
{
    [Application]
    [MetaData("com.google.android.maps.v2.API_KEY", Value = Variables.Google_Maps_Android_API_Key)]
    public class MyApp : Application
    {
        public MyApp(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
        
        
    }
}