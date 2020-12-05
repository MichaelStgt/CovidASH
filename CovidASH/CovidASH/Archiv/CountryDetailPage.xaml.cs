// <copyright file="CountryDetailPage.xaml.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Views
{
    using System.ComponentModel;
    using CovidASH.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="CountryDetailPage" />.
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class CountryDetailPage : ContentPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryDetailPage"/> class.
        /// </summary>
        /// <param name="viewModel">The viewModel<see cref="CountryDetailViewModel"/>.</param>
        public CountryDetailPage(CountryDetailViewModel viewModel)
        {
            this.InitializeComponent();
            this.ViewModel = viewModel;

            this.BindingContext = this.ViewModel;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the ViewModel
        /// Defines the viewModel..
        /// </summary>
        private CountryDetailViewModel ViewModel
        {
            get; set;
        }

        #endregion Properties
    }
}