// <copyright file="App.xaml.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH
{
    using System.Globalization;
    using System.Threading.Tasks;
    using CovidASH.Localization;
    using CovidASH.Styles;
    using CovidASH.Views;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using Xamarin.Forms.PlatformConfiguration;
    using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;

    /// <summary>
    /// Defines the <see cref="App" />.
    /// </summary>
    public partial class App : Xamarin.Forms.Application
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            this.On<Windows>().SetImageDirectory("Assets");

            this.InitializeComponent();
            this.LoadStyles();

            //// This lookup is NOT required for Windows platforms - the Culture will be automatically set
            //// But if we want to use the locale in the TranslateExtension, we'll get it for all platforms
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.iOS || Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android || Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP)
            {
                // determine the correct, supported .NET culture
                CultureInfo ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }

            this.MainPage = new MainPage();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the Culture.
        /// </summary>
        public static global::System.Globalization.CultureInfo Culture
        {
            get; set;
        }

        /// <summary>
        /// Gets the MainDisplayInfo.
        /// </summary>
        public static DisplayInfo MainDisplayInfo
        {
            get
            {
                return DeviceDisplay.MainDisplayInfo;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// The OnResume.
        /// </summary>
        protected override void OnResume()
        {
        }

        /// <summary>
        /// The OnSleep.
        /// </summary>
        protected override void OnSleep()
        {
        }

        /// <summary>
        /// The OnStart.
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        /// The LoadStyles.
        /// </summary>
        /// <returns>The <see cref="Task"/>.</returns>
        private Task LoadStyles()
        {
            AppTheme appTheme;

            // If this settings is not set, this must be the first time the user runs this App. Default to the Theme of the device
            // On Android and iOS, this works, but on UWP it will get the Theme of the App running, which is set in
            // App.xaml, RequestedTheme="Light"
            if (!App.Current.Properties.ContainsKey("Theme"))
            {
                appTheme = AppInfo.RequestedTheme;
                ThemeSettings.Theme = appTheme;
            }
            else
            {
                appTheme = ThemeSettings.Theme;
            }

            IPlatformThemeManager platformManager = DependencyService.Get<IPlatformThemeManager>();

            platformManager?.ChangeTheme(appTheme);

            if (appTheme.Equals(AppTheme.Light))
            {
                Current.Resources = new LightTheme();
            }
            else
            {
                Current.Resources = new DarkTheme();
            }

            const int smallWidthResolution = 768;
            const int smallHeightResolution = 1280;

            if (MainDisplayInfo.Width <= smallWidthResolution && MainDisplayInfo.Height <= smallHeightResolution)
            {
                this.AppDictionary.MergedDictionaries.Add(new SmallDeviceSizes());
            }
            else
            {
                this.AppDictionary.MergedDictionaries.Add(new DefaultSizes());
            }

            return Task.FromResult(true);
        }

        #endregion Methods
    }
}