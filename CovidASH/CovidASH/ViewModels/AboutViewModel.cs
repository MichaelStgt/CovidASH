// <copyright file="AboutViewModel.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.ViewModels
{
    using System.Windows.Input;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="AboutViewModel" />.
    /// </summary>
    public class AboutViewModel : BaseViewModel
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
        /// </summary>
        public AboutViewModel()
        {
            this.Title = "About";
            // this.OpenWebCommand = new Command<string>(async (s) => await Browser.OpenAsync("https://github.com/novelCOVID/API"));
            this.OpenWebCommand = new Command<string>(async (s) => await Browser.OpenAsync(s));
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the OpenWebCommand.
        /// </summary>
        public Command<string> OpenWebCommand
        {
            get;
        }

        #endregion Properties
    }
}