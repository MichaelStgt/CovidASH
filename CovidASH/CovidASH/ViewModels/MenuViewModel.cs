// <copyright file="MenuViewModel.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using CovidASH.Models;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="MenuViewModel" />.
    /// <a href = "https://www.buymeacoffee.com/MichaelStgt" target="_blank"><img src = "https://cdn.buymeacoffee.com/buttons/default-orange.png" alt="Buy Me A Coffee" style="height: 51px !important;width: 217px !important;" ></a>
    /// <style>.bmc-button img{height: 34px !important;width: 35px !important;margin-bottom: 1px !important;box-shadow: none !important;border: none !important;vertical-align: middle !important;}.bmc-button{padding: 7px 15px 7px 10px !important;line-height: 35px !important;height:51px !important;text-decoration: none !important;display:inline-flex !important;color:#FFFFFF !important;background-color:#FF813F !important;border-radius: 5px !important;border: 1px solid transparent !important;padding: 7px 15px 7px 10px !important;font-size: 22px !important;letter-spacing: 0.6px !important;box-shadow: 0px 1px 2px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 1px 2px 2px rgba(190, 190, 190, 0.5) !important;margin: 0 auto !important;font-family:'Cookie', cursive !important;-webkit-box-sizing: border-box !important;box-sizing: border-box !important;}.bmc-button:hover, .bmc-button:active, .bmc-button:focus {-webkit-box-shadow: 0px 1px 2px 2px rgba(190, 190, 190, 0.5) !important;text-decoration: none !important;box-shadow: 0px 1px 2px 2px rgba(190, 190, 190, 0.5) !important;opacity: 0.85 !important;color:#FFFFFF !important;}</style><link href="https://fonts.googleapis.com/css?family=Cookie" rel="stylesheet"><a class="bmc-button" target="_blank" href="https://www.buymeacoffee.com/MichaelStgt"><img src="https://cdn.buymeacoffee.com/buttons/bmc-new-btn-logo.svg" alt="Buy me a coffee"><span style="margin-left:5px;font-size:28px !important;">Buy me a coffee</span></a>.
    /// </summary>
    public class MenuViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Defines the menuItems.
        /// </summary>
        private ObservableCollection<HomeMenuItem> menuItems;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuViewModel"/> class.
        /// </summary>
        public MenuViewModel()
        {
            this.MenuItems = new ObservableCollection<HomeMenuItem>();

            this.LoadMenuItemsCommand = new Command(async () => await this.LoadMenuItemsCommandExecute());

            this.Title = "Menu";

            // this.OpenWebCommand = new Command<string>(async (s) => await Browser.OpenAsync("https://www.buymeacoffee.com/MichaelStgt"));
            this.OpenWebCommand = new Command<string>(async (s) => await Browser.OpenAsync(s));
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the BuymeacoffeeImage.
        /// </summary>
        public string BuymeacoffeeImage
        {
            get
            {
                return "https://cdn.buymeacoffee.com/buttons/default-orange.png";
            }
        }

        /// <summary>
        /// Gets or sets the LoadMenuItemsCommand.
        /// </summary>
        public Command LoadMenuItemsCommand
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the MenuItems.
        /// </summary>
        public ObservableCollection<HomeMenuItem> MenuItems
        {
            get
            {
                return this.menuItems;
            }

            set
            {
                this.SetProperty(ref this.menuItems, value);
            }
        }

        /// <summary>
        /// Gets the OpenWebCommand.
        /// </summary>
        public Command<string> OpenWebCommand
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// The LoadMenuItemsCommandExecute.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private Task LoadMenuItemsCommandExecute()
        {
            this.IsBusy = true;

            try
            {
                this.MenuItems.Add(new HomeMenuItem { Id = MenuItemType.Browse, Title = "Dashboard" });
                this.MenuItems.Add(new HomeMenuItem { Id = MenuItemType.About, Title = "About" });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.IsBusy = false;
            }

            return Task.FromResult(true);
        }

        #endregion Methods
    }
}