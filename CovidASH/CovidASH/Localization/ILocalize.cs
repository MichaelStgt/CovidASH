// <copyright file="ILocalize.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Localization
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Implementations of this interface MUST convert iOS and Android
    /// platform-specific locales to a value supported in .NET because
    /// ONLY valid .NET cultures can have their RESX resources loaded and used.
    /// </summary>
    public interface ILocalize
    {
        /// <summary>
        /// This method must evaluate platform-specific locale settings
        /// and convert them (when necessary) to a valid .NET locale.
        /// </summary>
        /// <returns>Bla.</returns>
        CultureInfo GetCurrentCultureInfo();

        /// <summary>
        /// The SetLocale.
        /// </summary>
        /// <param name="ci">The ci<see cref="CultureInfo"/>.</param>
        void SetLocale(CultureInfo ci);
    }

    /// <summary>
    /// Helper class for splitting locales like
    ///   iOS: ms_MY, gsw_CH
    ///   Android: in-ID
    /// into parts so we can create a .NET culture (or fallback culture).
    /// </summary>
    public class PlatformCulture
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformCulture"/> class.
        /// </summary>
        /// <param name="platformCultureString">The platformCultureString<see cref="string"/>.</param>
        public PlatformCulture(string platformCultureString)
        {
            if (string.IsNullOrEmpty(platformCultureString))
            {
                throw new ArgumentException("Expected culture identifier", nameof(platformCultureString)); // in C# 6 use nameof(platformCultureString)
            }

            this.PlatformString = platformCultureString.Replace("_", "-"); // .NET expects dash, not underscore
            var dashIndex = this.PlatformString.IndexOf("-", StringComparison.Ordinal);
            if (dashIndex > 0)
            {
                var parts = this.PlatformString.Split('-');
                this.LanguageCode = parts[0];
                this.LocaleCode = parts[1];
            }
            else
            {
                this.LanguageCode = this.PlatformString;
                this.LocaleCode = string.Empty;
            }
        }

        /// <summary>
        /// Gets the PlatformString.
        /// </summary>
        public string PlatformString
        {
            get;
        }

        /// <summary>
        /// Gets the LanguageCode.
        /// </summary>
        public string LanguageCode
        {
            get;
        }

        /// <summary>
        /// Gets the LocaleCode.
        /// </summary>
        public string LocaleCode
        {
            get;
        }

        /// <summary>
        /// The ToString.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public override string ToString()
        {
            return this.PlatformString;
        }
    }
}