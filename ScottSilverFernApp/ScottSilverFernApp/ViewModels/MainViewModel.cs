using System;

using Xamarin.Forms;

namespace ScottSilverFernApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(Page page) : base(page)
        {
            Title = "Silver Fern";
        }
    }
}