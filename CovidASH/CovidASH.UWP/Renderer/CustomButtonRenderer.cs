// <copyright file="CustomButtonRenderer.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(
    typeof(Xamarin.Forms.Button),
    typeof(CovidASH.UWP.Renderer.CustomButtonRenderer) //,
                                                       //new[] { typeof(CustomControls.Controls.CustomVisual) }
    )]

namespace CovidASH.UWP.Renderer
{
    using System.ComponentModel;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.UWP;

    /// <summary>
    /// Defines the <see cref="CustomEntryRenderer" />.
    /// </summary>
    public class CustomButtonRenderer : Xamarin.Forms.Platform.UWP.ButtonRenderer
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomButtonRenderer"/> class.
        /// </summary>
        public CustomButtonRenderer()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// The OnElementChanged.
        /// </summary>
        /// <param name="e">The e<see cref="ElementChangedEventArgs{Button}"/>.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            // return;
            if (this.Control != null && this.Element != null)
            {
                Windows.UI.Xaml.Style buttonStyle = (Windows.UI.Xaml.Style)CovidASH.UWP.App.Current.Resources["ButtonStyle"];

                if (buttonStyle != null)
                {
                    this.Control.Style = buttonStyle;
                }

                this.RemoveBorder();
            }
        }

        /// <summary>
        /// The OnElementPropertyChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="PropertyChangedEventArgs"/>.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        /// <summary>
        /// The RemoveBorder.
        /// </summary>
        private void RemoveBorder()
        {
            this.Control.BorderThickness = new Windows.UI.Xaml.Thickness(0);
        }

        #endregion Methods
    }
}