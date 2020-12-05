// <copyright file="HomeMenuItem.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Models
{
    /// <summary>
    /// Defines the <see cref="HomeMenuItem" />.
    /// </summary>
    public class HomeMenuItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public MenuItemType Id
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        public string Title
        {
            get; set;
        }

        #endregion Properties
    }
}