// <copyright file="CountryDetailViewModel.cs" company="Behr, Michael">
// Copyright Behr, Michael 2018-2020.
// All rights reserved.
// Use of this code is subject to the terms of our license.
// See license.txt file in the project root for full license information.
// </copyright>

namespace CovidASH.ViewModels
{
    using Covid19Tracker.Models;

    /// <summary>
    /// Defines the <see cref="CountryDetailViewModel" />.
    /// </summary>
    public class CountryDetailViewModel : BaseViewModel
    {
        #region Fields

        /// <summary>
        /// Defines the casesPerMillion.
        /// </summary>
        private long casesPerMillion;

        /// <summary>
        /// Defines the deathsPerMillion.
        /// </summary>
        private long deathsPerMillion;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryDetailViewModel"/> class.
        /// </summary>
        /// <param name="country">The item<see cref="CountryData"/>.</param>
        public CountryDetailViewModel(CountryData country)
        {
            this.Title = country?.CountryName;
            this.Country = country;
            this.CasesPerMillion = 1000000 * country.Cases / country.Population;
            this.DeathsPerMillion = 1000000 * country.Deaths / country.Population;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the CasesPerMillion.
        /// </summary>
        public long CasesPerMillion
        {
            get
            {
                return this.casesPerMillion;
            }

            set
            {
                this.SetProperty(ref this.casesPerMillion, value);
            }
        }

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        public CountryData Country
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the DeathsPerMillion.
        /// </summary>
        public long DeathsPerMillion
        {
            get
            {
                return this.deathsPerMillion;
            }

            set
            {
                this.SetProperty(ref this.deathsPerMillion, value);
            }
        }

        #endregion Properties
    }
}