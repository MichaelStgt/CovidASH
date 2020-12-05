// <copyright file="BaseViewModel.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.ViewModels
{
    using CovidASH.Common;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="BaseViewModel" />.
    /// </summary>
    public class BaseViewModel : NotifyPropertyChangedBase
    {
        #region Fields

        /// <summary>
        /// Defines the isBusy.
        /// </summary>
        private bool isBusy = false;

        /// <summary>
        /// Defines the navigation.
        /// </summary>
        private INavigation navigation;

        /// <summary>
        /// Defines the title.
        /// </summary>
        private string title = string.Empty;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether IsBusy.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                this.SetProperty(ref this.isBusy, value);
            }
        }

        /// <summary>
        /// Gets or sets the Navigation.
        /// </summary>
        public INavigation Navigation
        {
            get
            {
                return this.navigation;
            }

            set
            {
                this.SetProperty(ref this.navigation, value);
            }
        }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.SetProperty(ref this.title, value);
            }
        }

        #endregion Properties
    }
}