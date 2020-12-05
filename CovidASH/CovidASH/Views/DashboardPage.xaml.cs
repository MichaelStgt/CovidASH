// <copyright file="DashboardPage.xaml.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Views
{
    using System;
    using System.ComponentModel;
    using CovidASH.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="DashboardPage" />.
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class DashboardPage : ContentPage
    {
        #region Fields

        /// <summary>
        /// Defines the viewModel.
        /// </summary>
        private DashboardViewModel viewModel;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardPage"/> class.
        /// </summary>
        public DashboardPage()
        {
            this.InitializeComponent();

            this.BindingContext = this.viewModel = new DashboardViewModel();
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// The OnAppearing.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.viewModel.CountryDataCollection.Count == 0)
            {
                this.viewModel.LoadCountriesCommand.Execute(null);
            }
        }

        #endregion Methods
    }
}