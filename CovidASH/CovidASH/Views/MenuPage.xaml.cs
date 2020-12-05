// <copyright file="MenuPage.xaml.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Views
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using CovidASH.Models;
    using CovidASH.ViewModels;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="MenuPage" />.
    /// The tappable Label is described here:
    /// https://xamarinhelp.com/hyperlink-in-xamarin-forms-label/.
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPage"/> class.
        /// </summary>
        public MenuPage()
        {
            this.InitializeComponent();

            this.ViewModel = new MenuViewModel();

            this.BindingContext = this.ViewModel;

            // this.MenuListView.ItemSelected += this.ListViewMenu_ItemSelected;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the ViewModel.
        /// </summary>
        public MenuViewModel ViewModel
        {
            get; set;
        }

        /// <summary>
        /// Gets the RootPage.
        /// </summary>
        private MainPage RootPage
        {
            get => Application.Current.MainPage as MainPage;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// The OnAppearing.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.ViewModel.MenuItems.Count == 0)
            {
                this.ViewModel.LoadMenuItemsCommand.Execute(null);
                // this.MenuListView.SelectedItem = this.ViewModel.MenuItems[0];
                this.MenuListView.ItemSelected += this.MenuListView_ItemSelected;
            }
        }

        /// <summary>
        /// The MenuListView_ItemSelected.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="SelectedItemChangedEventArgs"/>.</param>
        private async void MenuListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            await this.RootPage.NavigateFromMenu(id);

            this.MenuListView.SelectedItem = null;
        }

        #endregion Methods
    }
}