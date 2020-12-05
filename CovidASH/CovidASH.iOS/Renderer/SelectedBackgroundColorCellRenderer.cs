// <copyright file="SelectedBackgroundColorCellRenderer.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

[assembly: Xamarin.Forms.ExportRenderer(typeof(CovidASH.Controls.SelectableViewCell), typeof(CustomControls.iOS.Renderer.SelectedBackgroundColorCellRenderer))]

namespace CustomControls.iOS.Renderer
{
    using CovidASH.Controls;

    // using PokerManager.Controls;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    /// <summary>
    /// Defines the <see cref="SelectedBackgroundColorCellRenderer" />.
    /// </summary>
    public class SelectedBackgroundColorCellRenderer : ViewCellRenderer
    {
        /// <summary>
        /// Defines the bgView.
        /// </summary>
        private UIView bgView;

        /// <summary>
        /// Defines the cell.
        /// </summary>
        private UITableViewCell cell;

        /// <summary>
        /// The GetCell.
        /// </summary>
        /// <param name="item">The item<see cref="Cell"/>.</param>
        /// <param name="reusableCell">The reusableCell<see cref="UITableViewCell"/>.</param>
        /// <param name="tv">The table view<see cref="UITableView"/>.</param>
        /// <returns>The <see cref="UITableViewCell"/>.</returns>
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            this.cell = base.GetCell(item, reusableCell, tv);
            this.cell.SelectedBackgroundView = new UIView
            {
                BackgroundColor = UIColor.DarkGray,
            };

            return this.cell;
        }

        ///// <summary>
        ///// The Element_PropertyChanged.
        ///// </summary>
        ///// <param name="sender">The sender<see cref="object"/>.</param>
        ///// <param name="e">The e<see cref="System.ComponentModel.PropertyChangedEventArgs"/>.</param>
        //private void Element_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    SelectableViewCell element = sender as SelectableViewCell;
        //    this.bgView = new UIView(this.cell.SelectedBackgroundView.Bounds);

        //    if (element?.SelectedBackgroundColor != Color.Default)
        //    {
        //        this.bgView.Layer.BackgroundColor = element.SelectedBackgroundColor.ToCGColor();
        //    }
        //    else
        //    {
        //        this.bgView.Layer.BackgroundColor = UIColor.Orange.CGColor;
        //    }

        //    this.cell.SelectedBackgroundView = this.bgView;
        //}
    }
}