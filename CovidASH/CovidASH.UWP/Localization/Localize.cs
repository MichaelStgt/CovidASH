// <copyright file="Localize.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2019.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

[assembly: Xamarin.Forms.Dependency(typeof(CovidASH.UWP.Localization.Localize))]

namespace CovidASH.UWP.Localization
{
    using System;
    using System.Globalization;
    using System.Threading;

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
        public CultureInfo GetCurrentCultureInfo()
        {
            return new System.Globalization.CultureInfo(
                Windows.System.UserProfile.GlobalizationPreferences.Languages[0]);
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

        #endregion Methods
    }
}