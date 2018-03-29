﻿using ScottSilverFernApp.Models;
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
	public partial class DetailsView : ContentView
	{
		public DetailsView ()
		{
			InitializeComponent ();
		}

        public DetailsView(Species item)
        {
            InitializeComponent();

            this.BindingContext = item;
        }

    }
}