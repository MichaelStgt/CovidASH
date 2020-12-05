// <copyright file="ContinentData.cs" company="Egbakou, Kodjo Laurent (egbakou)">
// https://github.com/egbakou/Covid19Tracker.NET
// </copyright>

namespace Covid19Tracker.Models
{
    using System;
    using System.Collections.Generic;
    using Covid19Tracker.Helpers;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a continent data class.
    /// </summary>
    public class ContinentData
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Active.
        /// </summary>
        [JsonProperty("active")]
        public long Active
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Cases.
        /// </summary>
        [JsonProperty("cases")]
        public long Cases
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the ContinentName.
        /// </summary>
        [JsonProperty("continent")]
        public string ContinentName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Countries.
        /// </summary>
        [JsonProperty("countries")]
        public IList<string> Countries
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Critical.
        /// </summary>
        [JsonProperty("critical")]
        public long Critical
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Deaths.
        /// </summary>
        [JsonProperty("deaths")]
        public long Deaths
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the DodayDeaths.
        /// </summary>
        [JsonProperty("todayDeaths")]
        public long TodayDeaths
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Population
        /// Gets or Sets Population..
        /// </summary>
        [JsonProperty("population")]
        public long Population
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Recovered.
        /// </summary>
        [JsonProperty("recovered")]
        public long Recovered
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Tests.
        /// </summary>
        [JsonProperty("tests")]
        public long Tests
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the TodayCases.
        /// </summary>
        [JsonProperty("todayCases")]
        public long TodayCases
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Updated.
        /// </summary>
        [JsonProperty("updated")]
        [JsonConverter(typeof(LongToUTCDateTimeConverter))]
        public DateTime Updated
        {
            get; set;
        }

        #endregion Properties
    }
}