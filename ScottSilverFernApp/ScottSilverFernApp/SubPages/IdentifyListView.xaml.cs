﻿using ScottSilverFernApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScottSilverFernApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IdentifyListView : ContentView
    {
        public ObservableCollection<string> Items { get; set; }

        public IdentifyListView()
        {
            InitializeComponent();
        }
        public IdentifyListView(List<Species> speciesList)
        {
            InitializeComponent();
            SpeciesListView.ItemsSource = new List<Species>
            {

                new Species
                {
                    speciesName=speciesList[0].speciesName,
                    similarity=speciesList[0].similarity*100,
                    invasiveOrNot=speciesList[0].invasiveOrNot,
                    invasiveOrNotString=InvasiveOrNotReturn(speciesList[0].invasiveOrNot),
                    imageAddr=speciesList[0].imageAddr,
                    alsoKnownAs=speciesList[0].alsoKnownAs,
                    family=speciesList[0].family,
                    origin=speciesList[0].origin,
                    generalDescription=speciesList[0].generalDescription,
                    habitats=speciesList[0].habitats,
                    dispersal=speciesList[0].dispersal,
                    impactOnEnvironment=speciesList[0].impactOnEnvironment,
                    siteManagement=speciesList[0].siteManagement,
                    recommendedApproaches=speciesList[0].recommendedApproaches,
                },
                new Species
                {
                    speciesName=speciesList[1].speciesName,
                    similarity=speciesList[1].similarity*100,
                    invasiveOrNot=speciesList[1].invasiveOrNot,
                    invasiveOrNotString=InvasiveOrNotReturn(speciesList[1].invasiveOrNot),
                    imageAddr=speciesList[1].imageAddr,
                    alsoKnownAs=speciesList[1].alsoKnownAs,
                    family=speciesList[1].family,
                    origin=speciesList[1].origin,
                    generalDescription=speciesList[1].generalDescription,
                    habitats=speciesList[1].habitats,
                    dispersal=speciesList[1].dispersal,
                    impactOnEnvironment=speciesList[1].impactOnEnvironment,
                    siteManagement=speciesList[1].siteManagement,
                    recommendedApproaches=speciesList[1].recommendedApproaches,
                },
                new Species
                {
                   speciesName=speciesList[2].speciesName,
                    similarity=speciesList[2].similarity*100,
                    invasiveOrNot=speciesList[2].invasiveOrNot,
                    invasiveOrNotString=InvasiveOrNotReturn(speciesList[2].invasiveOrNot),
                    imageAddr=speciesList[2].imageAddr,
                    alsoKnownAs=speciesList[2].alsoKnownAs,
                    family=speciesList[2].family,
                    origin=speciesList[2].origin,
                    generalDescription=speciesList[2].generalDescription,
                    habitats=speciesList[2].habitats,
                    dispersal=speciesList[2].dispersal,
                    impactOnEnvironment=speciesList[2].impactOnEnvironment,
                    siteManagement=speciesList[2].siteManagement,
                    recommendedApproaches=speciesList[2].recommendedApproaches,
                }
            };
        }
        string InvasiveOrNotReturn(Boolean set)
        {
            if (set.Equals(true))
            {
                return "Invasive Species";
            }
            else
            {
                return "Non-invasive Species";
            }
        }
        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Species;
            DetailsView detailsView = new DetailsView();
            detailsView.BindingContext = item;
            //ListViewPageAndDetailsPage.Children.Add(detailsView, Constraint.Constant(0));
            //SpeciesListView.IsEnabled = false;
            SpeciesListView.IsVisible = false;
            ButtonBack.IsVisible = false;
            ListViewPageAndDetailsPage.Children.Add(detailsView);
            //ListViewPageAndDetailsPage.Children.Insert(0,detailsView);
        }
        protected void GoBackButtonPressed()
        {
            this.IsVisible = false;

        }
    }
}
