using Microsoft.WindowsAzure.MobileServices;
using ScottSilverFernApp.Models;
using ScottSilverFernApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace ScottSilverFernApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasicMapPage : ContentPage
	{
        public BasicMapPage() : base()
        {
            InitializeComponent();

            // MapTypes
            var mapTypeValues = new List<MapType>();
            foreach (var mapType in Enum.GetValues(typeof(MapType)))
            {
                mapTypeValues.Add((MapType)mapType);
            }

            map.MapType = mapTypeValues[0];

            // Map Long clicked
            map.MapLongClicked += (sender, e) =>
            {
                var lat = e.Point.Latitude.ToString("0.000");
                var lng = e.Point.Longitude.ToString("0.000");
                this.DisplayAlert("MapLongClicked", $"{lat}/{lng}", "CLOSE");
            };

            map.CameraIdled += (sender, args) =>
            {
                var p = args.Position;
            };

            AddPinFromAzure();
        }



        public async void AddPinFromAzure()
        {
            AzureDataServiceForPins azureDataServiceForPins = new AzureDataServiceForPins();

            try
            {
                IEnumerable<SPECIES_LA_LONG> iEnumerablePinClass = await azureDataServiceForPins.GetPinsAsync();
                AddPin(iEnumerablePinClass);
            }
            catch(MobileServiceInvalidOperationException e) 
            {
            }
            
        }

        public void AddPin(IEnumerable<SPECIES_LA_LONG> iEnumerablePinClass)
        {
            for (int i = 0; i < iEnumerablePinClass.Count(); i++)
            {
                SPECIES_LA_LONG pinClass = iEnumerablePinClass.ElementAt(i);
                var pin = new Pin()
                {
                    Type = PinType.Place,
                    Label = pinClass.speciesName,
                    Address = pinClass.latitude + "," + pinClass.longtitude,
                    Position = new Position(pinClass.latitude, pinClass.longtitude)
                };
                map.Pins.Add(pin);
            }
        }
    }
}