using ScottSilverFernApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScottSilverFernApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IdentifyListPage : ContentPage
	{
        public ObservableCollection<string> Items { get; set; }

        public IdentifyListPage()
        {
            InitializeComponent();
            
        }

        public IdentifyListPage(List<Species> speciesList)
        {
            InitializeComponent();

            IdentifyListView identifyListView = new IdentifyListView(speciesList);
            Content = identifyListView;
        }
        
    }
}