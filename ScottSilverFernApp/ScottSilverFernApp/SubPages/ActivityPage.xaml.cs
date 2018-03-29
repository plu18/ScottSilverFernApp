using ScottSilverFernApp.SubPages;
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
	public partial class ActivityPage : ContentPage
	{
		public ActivityPage ()
		{
			InitializeComponent ();
        }
        private void TapGestureRecognizer_TappedC1top(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://www.worldwildlife.org/"));
        }

        private void TapGestureRecognizer_TappedC1bot(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://twitter.com/WWF"));
        }

        private void TapGestureRecognizer_TappedC2top(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://www.mpi.govt.nz/"));
        }

        private void TapGestureRecognizer_TappedC2bot(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://www.facebook.com/SilverFernApp/"));
        }

        private void TapGestureRecognizer_TappedC3top(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://www.greenpeace.org/"));
        }

        private void TapGestureRecognizer_TappedC3bot(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://twitter.com/Greenpeace"));
        }

        private void TapGestureRecognizer_TappedC4top(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("http://www.nzpcn.org.nz/"));
        }

        private void TapGestureRecognizer_TappedC4bot(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("http://www.nzpcn.org.nz/members_forum.aspx?scfStart_Results=0&"));
        }

        private void TapGestureRecognizer_TappedC5top(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://www.greens.org.nz/"));
        }

        private void TapGestureRecognizer_TappedC5bot(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://www.facebook.com/nzgreenparty/"));
        }

        private void TapGestureRecognizer_TappedC6top(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("http://www.canterbury.ac.nz/engineering/schools/forestry/"));
        }

        private void TapGestureRecognizer_TappedC6bot(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://www.facebook.com/universitycanterbury/"));
        }
    }
}