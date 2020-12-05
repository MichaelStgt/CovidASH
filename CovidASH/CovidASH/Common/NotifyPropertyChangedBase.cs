// <copyright file="NotifyPropertyChangedBase.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Defines the <see cref="NotifyPropertyChangedBase" />.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:Elements should appear in the correct order", Justification = "<Pending>")]
    public partial class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyPropertyChangedBase"/> class.
        /// </summary>
        public NotifyPropertyChangedBase()
        {
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Defines the PropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Methods

        /// <summary>
        /// The OnPropertyChanged.
        /// </summary>
        /// <param name="propertyName">The propertyName<see cref="string"/>.</param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = this.PropertyChanged;
            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The SetProperty.
        /// </summary>
        /// <typeparam name="T">The type of the property set.</typeparam>
        /// <param name="backingStore">The backingStore<see cref="T"/>.</param>
        /// <param name="value">The value<see cref="T"/>.</param>
        /// <param name="propertyName">The propertyName<see cref="string"/>.</param>
        /// <param name="onChanged">The onChanged<see cref="Action"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        protected bool OverwriteProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            try
            {
                backingStore = value;

                onChanged?.Invoke();
                this.OnPropertyChanged(propertyName);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// The SetProperty.
        /// </summary>
        /// <typeparam name="T">The type of the property set.</typeparam>
        /// <param name="backingStore">The backingStore<see cref="T"/>.</param>
        /// <param name="value">The value<see cref="T"/>.</param>
        /// <param name="propertyName">The propertyName<see cref="string"/>.</param>
        /// <param name="onChanged">The onChanged<see cref="Action"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName]string propertyName = "", Action onChanged = null)
        {
            try
            {
                if (EqualityComparer<T>.Default.Equals(backingStore, value))
                {
                    return false;
                }

                backingStore = value;

                onChanged?.Invoke();
                this.OnPropertyChanged(propertyName);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Methods
    }
}