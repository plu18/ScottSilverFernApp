using ScottSilverFernApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScottSilverFernApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailsPage : ContentPage
	{
		public DetailsPage ()
		{
			InitializeComponent ();
        }
        public DetailsPage(Species item)
        {
            InitializeComponent();

            DetailsView detailsView = new DetailsView();
            detailsView.BindingContext = item;
            Content = detailsView;
            
        }

    }
}