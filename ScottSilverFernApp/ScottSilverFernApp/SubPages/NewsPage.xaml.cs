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
	public partial class NewsPage : ContentPage
	{
		public NewsPage ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_TappedNew1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("http://earthhour.wwf.sg/"));
        }
        private void TapGestureRecognizer_TappedNew2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("http://www.mfe.govt.nz/news-events/sign-join-conversation-zero-carbon-bill"));
        }
        private void TapGestureRecognizer_TappedNew3(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://www.mpi.govt.nz/protection-and-response/responding/alerts/myrtle-rust"));
        }
        private void TapGestureRecognizer_TappedNew4(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://www.radionz.co.nz/national/programmes/afternoons/audio/2018635731/expert-feature-the-humble-cabbage-tree-ti-kouka"));
        }
        private void TapGestureRecognizer_TappedNew5(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("http://blog.tepapa.govt.nz/2018/03/06/what-happens-when-you-ask-ornithologists-to-do-botany/"));
        }
        private void TapGestureRecognizer_TappedNew6(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("http://greenpeace.nz/petitionEndOil"));

        }
        private void TapGestureRecognizer_TappedNew7(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("http://www.doc.govt.nz/our-work/battle-for-our-birds/"));
        }
        private void TapGestureRecognizer_TappedNew8(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("http://www.mfe.govt.nz/news-events/microbeads-banned"));
        }
        private void TapGestureRecognizer_TappedNew9(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WebPage("https://www.theatlantic.com/technology/archive/2015/07/when-you-give-a-tree-an-email-address/398210/?utm_source=fbb"));

        }
    }
}