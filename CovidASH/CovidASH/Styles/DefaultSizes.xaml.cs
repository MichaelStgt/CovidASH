// <copyright file="DefaultSizes.xaml.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Styles
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Defines the <see cref="DefaultSizes" />.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultSizes : ResourceDictionary
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultSizes"/> class.
        /// </summary>
        public DefaultSizes()
        {
            this.InitializeComponent();
        }

        #endregion Constructors
    }
}