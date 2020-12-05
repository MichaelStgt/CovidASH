// <copyright file="Localize.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2019.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

[assembly: Xamarin.Forms.Dependency(typeof(CovidASH.Localization.Droid.Localize))]

namespace CovidASH.Localization.Droid
{
    using System.Globalization;
    using System.Threading;
    using Debug = System.Diagnostics.Debug;

    /// <summary>
    /// Defines the <see cref="Localize" />.
    /// </summary>
    public class Localize : CovidASH.Localization.ILocalize
    {
        #region Methods

        /// <summary>
        /// The GetCurrentCultureInfo.
        /// </summary>
        /// <returns>The <see cref="CultureInfo"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>")]
        public CultureInfo GetCurrentCultureInfo()
        {
            string netLanguage = "en";
            Java.Util.Locale androidLocale = Java.Util.Locale.Default;

            netLanguage = this.AndroidToDotnetLanguage(androidLocale.ToString().Replace("_", "-"));

            return new CultureInfo(netLanguage);
        }

        /// <summary>
        /// The SetLocale.
        /// </summary>
        /// <param name="cultureInfo">The cultureInfo<see cref="CultureInfo"/>.</param>
        public void SetLocale(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Debug.WriteLine("CurrentCulture set: " + cultureInfo.Name);
        }

        /// <summary>
        /// The AndroidToDotnetLanguage.
        /// </summary>
        /// <param name="androidLanguage">The androidLanguage<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string AndroidToDotnetLanguage(string androidLanguage)
        {
            // Debug.WriteLine("Android Language:" + androidLanguage);

            // certain languages need to be converted to CultureInfo equivalent
            switch (androidLanguage)
            {
                case "en-DE": // Language English in Region Germany is not supported, use English
                    return "en-US"; // closest supported

                case "in-ID": // "Indonesian (Indonesia)" has different code in  .NET
                    return "id-ID"; // correct code for .NET
                case "gsw-CH": // "Schweizerdeutsch (Swiss German)" not supported .NET culture
                    return "de-CH"; // closest supported
                default:
                    return "en-US";

                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }

            // Debug.WriteLine(".NET Language/Locale:" + netLanguage);
        }

        /// <summary>
        /// The ToDotnetFallbackLanguage.
        /// </summary>
        /// <param name="platCulture">The platCulture<see cref="PlatformCulture"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        private string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            // Debug.WriteLine(".NET Fall-back-Language:" + platCulture.LanguageCode);

            switch (platCulture.LanguageCode)
            {
                case "gsw":
                    return "de-CH"; // equivalent to German (Switzerland) for this App

                    // add more application-specific cases here (if required)
                    // ONLY use cultures that have been tested and known to work
            }

            // Debug.WriteLine(".NET Fallback Language/Locale:" + netLanguage + " (application-specific)");
            return platCulture.LanguageCode; // use the first part of the identifier (two chars, usually);
        }

        #endregion Methods
    }
}