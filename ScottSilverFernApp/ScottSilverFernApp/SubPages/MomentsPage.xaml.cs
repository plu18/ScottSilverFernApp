﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScottSilverFernApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MomentsPage : ContentPage
	{
		public MomentsPage ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_TappedLogin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}