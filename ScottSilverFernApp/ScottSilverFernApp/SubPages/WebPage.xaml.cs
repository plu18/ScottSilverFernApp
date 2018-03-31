using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScottSilverFernApp.SubPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WebPage : ContentPage
	{
		public WebPage (string path)
		{
			InitializeComponent ();

            this.BackgroundColor = Color.Red;

            var browser = new WebView();
            browser.Source = path;
            //ToolbarItems.Add(new ToolbarItem("", "", () => { browser.GoBack(); }));
            Content = browser;
        }
        
	}
}