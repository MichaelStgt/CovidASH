// <copyright file="IPlatformThemeManager.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Styles
{
    using Xamarin.Essentials;

    #region Interfaces

    /// <summary>
    /// Defines the <see cref="IPlatformThemeManager" />.
    /// </summary>
    public interface IPlatformThemeManager
    {
        #region Methods

        /// <summary>
        /// The ChangeTheme.
        /// </summary>
        /// <param name="appTheme">The appTheme<see cref="AppTheme"/>.</param>
        void ChangeTheme(AppTheme appTheme);

        #endregion Methods
    }

    #endregion Interfaces
}