// <copyright file="SelectableViewCell.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Controls
{
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="SelectableViewCell" />.
    /// </summary>
    public class SelectableViewCell : Xamarin.Forms.ViewCell
    {
        #region Fields

        /// <summary>
        /// Defines the SelectedBackgroundColorProperty.
        /// </summary>
        public static readonly BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create(
            nameof(SelectedBackgroundColor),
            typeof(Color),
            typeof(SelectableViewCell),
            defaultValue: Color.DarkGray);

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the SelectedBackgroundColor.
        /// </summary>
        public Color SelectedBackgroundColor
        {
            get
            {
                return (Color)this.GetValue(SelectedBackgroundColorProperty);
            }

            set
            {
                this.SetValue(SelectedBackgroundColorProperty, value);
            }
        }

        #endregion Properties
    }
}