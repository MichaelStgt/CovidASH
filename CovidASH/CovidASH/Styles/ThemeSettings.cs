// <copyright file="ThemeSettings.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Styles
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="ThemeSettings" />.
    /// </summary>
    public static class ThemeSettings
    {
        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="ThemeSettings"/> class.
        /// </summary>
        static ThemeSettings()
        {
            SwitchThemeModeCommand = new Command(async () => await SwitchModeCommandExecute().ConfigureAwait(false));
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the SwitchThemeModeCommand.
        /// </summary>
        public static ICommand SwitchThemeModeCommand
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Theme.
        /// </summary>
        public static AppTheme Theme
        {
            get
            {
                if (Application.Current.Properties.ContainsKey("Theme"))
                {
                    if (Enum.TryParse(Application.Current.Properties["Theme"].ToString(), true, out AppTheme appTheme))
                    {
                        if (Enum.IsDefined(typeof(AppTheme), appTheme))
                        {
                            return appTheme;
                        }
                    }
                }

                return AppTheme.Light;
            }

            set
            {
                Application.Current.Properties["Theme"] = value.ToString();
                Application.Current.SavePropertiesAsync();
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// The SwitchModeCommandExecute.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        public static Task SwitchModeCommandExecute()
        {
            AppTheme appTheme = ThemeSettings.Theme;

            if (appTheme.Equals(AppTheme.Light))
            {
                Application.Current.Resources = new DarkTheme();

                IPlatformThemeManager platformManager = DependencyService.Get<IPlatformThemeManager>();

                platformManager?.ChangeTheme(AppTheme.Dark);

                ThemeSettings.Theme = AppTheme.Dark;
            }
            else
            {
                Application.Current.Resources = new LightTheme();

                IPlatformThemeManager platformManager = DependencyService.Get<IPlatformThemeManager>();

                // platformManager.ChangeTheme("light");
                platformManager?.ChangeTheme(AppTheme.Light);

                ThemeSettings.Theme = AppTheme.Light;
            }

            // App.MasterDetailPage.IsPresented = false;
            return Task.FromResult(true);
        }

        #endregion Methods
    }
}