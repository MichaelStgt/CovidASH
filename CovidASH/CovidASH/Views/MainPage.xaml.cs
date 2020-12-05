// <copyright file="MainPage.xaml.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Views
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using CovidASH.Models;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="MainPage" />.
    /// </summary>
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        #region Fields

        /// <summary>
        /// Defines the MenuPages.
        /// </summary>
        private Dictionary<int, NavigationPage> menuPages = new Dictionary<int, NavigationPage>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            this.MasterBehavior = MasterBehavior.Popover;

            this.menuPages.Add((int)MenuItemType.Browse, (NavigationPage)this.Detail);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// The NavigateFromMenu.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public async Task NavigateFromMenu(int id)
        {
            if (!this.menuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Browse:
                        this.menuPages.Add(id, new NavigationPage(new DashboardPage()));
                        break;

                    case (int)MenuItemType.About:
                        this.menuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                }
            }

            var newPage = this.menuPages[id];

            if (newPage != null && this.Detail != newPage)
            {
                this.Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                {
                    await Task.Delay(100);
                }

                this.IsPresented = false;
            }
        }

        #endregion Methods
    }
}