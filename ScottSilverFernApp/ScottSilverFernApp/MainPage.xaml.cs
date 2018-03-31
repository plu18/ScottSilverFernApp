using BottomBar.XamarinForms;
using ScottSilverFernApp.ViewModels;

namespace ScottSilverFernApp
{
	public partial class MainPage : BottomBarPage
    {
		public MainPage()
		{
			InitializeComponent();
            BindingContext = new MainViewModel(this);
        }
    }
}
