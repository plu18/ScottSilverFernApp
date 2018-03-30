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

namespace ScottSilverFernApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomCameraPage : ContentPage
	{
        private static CustomCameraPage instance = null;
        public CustomCameraPage ()
		{
            
            InitializeComponent();

            MessagingCenter.Subscribe<CustomCameraPage>(this, "Navigation1", async (sender) =>
            {
                IdentifyListPage identifyListPage = IdentifyListPage.getInstance();
                await Navigation.PushAsync(identifyListPage);
            });

            MessagingCenter.Subscribe<CustomCameraPage, Stream>(this, "StreamSend", async (sender, arg) =>
            {
                
                List<Species> speciesList = await CustomCameraController.CommonOperationCameraLibPictures(arg);

                IdentifyListPage identifyListPage = IdentifyListPage.getInstance();
                await Navigation.PushAsync(identifyListPage);

                await DisplayAlert(speciesList.Count.ToString(), "NULL", "!!!");
                if (speciesList.Any())
                    identifyListPage.Content = new IdentifyListView(speciesList);
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