// <copyright file="DateToStringConverter.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.Converter
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    /// <summary>
    /// Defines the <see cref="DateToStringConverter" />.
    /// </summary>
    public class DateToStringConverter : IValueConverter
    {
        #region Properties

        /// <summary>
        /// Gets the CultureInfo.
        /// </summary>
        private CultureInfo CultureInfo
        {
            get
            {
                return App.Culture;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// The Convert.
        /// </summary>
        /// <param name="value">The value<see cref="object"/>.</param>
        /// <param name="targetType">The targetType<see cref="Type"/>.</param>
        /// <param name="parameter">The parameter<see cref="object"/>.</param>
        /// <param name="culture">The culture<see cref="CultureInfo"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateTime = (DateTime)value;

            // DateTime dateTime = DateTime.MinValue + timeSpan;

            //// acknowledgement: based on some code from
            //// http://stackoverflow.com/questions/1292246/why-doesnt-datetime-toshorttimestring-respect-the-short-time-format-in-regio

            DateTimeFormatInfo dateTimeFormat = this.CultureInfo.DateTimeFormat; // CultureInfo.CurrentCulture.DateTimeFormat;

            // string shortTimePattern
            //    = dateTimeFormat.LongTimePattern.Replace(":ss", String.Empty).Replace(":s", String.Empty);
            // return dateTime.ToString(shortTimePattern);
            // string pattern = "MM-dd-yyyyy";
            // string formated = string.Format(dateTimeFormat, dateTime.ToString());
            // formated = dateTime.ToString(dateTimeFormat.ShortDatePattern);
            // return formated;
            return dateTime.ToString(dateTimeFormat.ShortDatePattern);
        }

        /// <summary>
        /// The ConvertBack.
        /// </summary>
        /// <param name="value">The value<see cref="object"/>.</param>
        /// <param name="targetType">The targetType<see cref="Type"/>.</param>
        /// <param name="parameter">The parameter<see cref="object"/>.</param>
        /// <param name="culture">The culture<see cref="CultureInfo"/>.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // return null;
            // throw new NotImplementedException();
            return value;
        }

        #endregion Methods
    }
}