// <copyright file="Localize.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2019.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

[assembly: Xamarin.Forms.Dependency(typeof(CovidASH.Localization.iOS.Localize))]

namespace CovidASH.Localization.iOS
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Foundation;
    using CovidASH.Localization;

    /// <summary>
    /// Defines the <see cref="Localize" />.
    /// </summary>
    public class Localize : CovidASH.Localization.ILocalize
    {
        #region Methods

        /// <summary>
        /// The GetCurrentCultureInfo.
        /// </summary>
        /// <returns>The CultureInfo<see cref="CultureInfo"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Simplification", "RCS1128:Use coalesce expression.", Justification = "<Pending>")]
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];

                netLanguage = this.iOSToDotnetLanguage(pref);
            }

            CultureInfo cultureInfo;
            try
            {
                cultureInfo = new System.Globalization.CultureInfo(netLanguage);

                // If there is now known language, simply use englisch
            }
            catch (CultureNotFoundException cnfe)
            {
                var fallback = this.ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                Console.WriteLine(netLanguage + " failed, trying " + fallback + " (" + cnfe.Message + ")");
                cultureInfo = new System.Globalization.CultureInfo(fallback);

                // If an error occurs, assume there is no valid language and simply use English
                if (cultureInfo == null)
                {
                    cultureInfo = new System.Globalization.CultureInfo("en");
                }
            }

            return cultureInfo;
        }

        /// <summary>
        /// The SetLocale.
        /// </summary>
        /// <param name="cultureInfo">The cultureInfo<see cref="CultureInfo"/>.</param>
        public void SetLocale(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Console.WriteLine("CurrentCulture set: " + cultureInfo.Name);
        }

        /// <summary>
        /// The iOSToDotnetLanguage.
        /// </summary>
        /// <param name="iOSLanguage">The iOSLanguage<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
        private string iOSToDotnetLanguage(string iOSLanguage)
        {
            // Console.WriteLine("iOS Language:" + iOSLanguage);
            // .NET cultures don't support underscores

            // certain languages need to be converted to CultureInfo equivalent
            switch (iOSLanguage)
            {
                case "en-DE": // Language English in Region Germany is not supported, use English
                    return "en-US"; // closest supported

                case "gsw-CH": // "Schweizerdeutsch (Swiss German)" not supported .NET culture
                    return "de-CH"; // closest supported
                default:
                    return "en-US";
            }

            // Console.WriteLine(".NET Language/Locale:" + netLanguage);
            // return iOSLanguage.Replace("_", "-");
        }

        /// <summary>
        /// The ToDotnetFallbackLanguage.
        /// </summary>
        /// <param name="platCulture">The platCulture<see cref="PlatformCulture"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            Console.WriteLine(".NET Fallback Language:" + platCulture.LanguageCode);
            var netLanguage = platCulture.LanguageCode; // use the first part of the identifier (two chars, usually);

            switch (platCulture.LanguageCode)
            {
                // force different 'fallback' behavior for some language codes
                case "pt":
                    netLanguage = "pt-PT"; // fallback to Portuguese (Portugal)
                    break;

                case "gsw":
                    netLanguage = "de-CH"; // equivalent to German (Switzerland) for this App
                    break;
                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }

            Console.WriteLine(".NET Fallback Language/Locale:" + netLanguage + " (application-specific)");
            return netLanguage;
        }

        #endregion Methods
    }
}