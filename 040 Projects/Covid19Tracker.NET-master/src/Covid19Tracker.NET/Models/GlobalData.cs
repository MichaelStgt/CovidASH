// <copyright file="GlobalData.cs" company="Egbakou, Kodjo Laurent (egbakou)">
// https://github.com/egbakou/Covid19Tracker.NET
// </copyright>

namespace Covid19Tracker.Models
{
    using System;
    using Covid19Tracker.Helpers;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="GlobalData" />.
    /// Sample Data can be found in
    /// ..\App_data\GlobalData.json
    /// </summary>
    public class GlobalData
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
        /// Gets or sets the ActivePerOneMillion.
        /// </summary>
        [JsonProperty("activePerOneMillion")]
        public long ActivePerOneMillion
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the AffectedCountries.
        /// </summary>
        [JsonProperty("affectedCountries")]
        public int AffectedCountries
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
        /// Gets or sets the CasesPerOneMillion.
        /// </summary>
        [JsonProperty("casesPerOneMillion")]
        public long CasesPerOneMillion
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
        /// Gets or sets the CriticalPerOneMillion.
        /// </summary>
        [JsonProperty("criticalPerOneMillion")]
        public long CriticalPerOneMillion
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
        /// Gets or sets the DeathsPerOneMillion.
        /// </summary>
        [JsonProperty("deathsPerOneMillion")]
        public long DeathsPerOneMillion
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the OneCasePerPeople.
        /// </summary>
        [JsonProperty("oneCasePerPeople")]
        public long OneCasePerPeople
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the OneDeathPerPeople.
        /// </summary>
        [JsonProperty("oneDeathPerPeople")]
        public long OneDeathPerPeople
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the OneTestPerPeople.
        /// </summary>
        [JsonProperty("oneTestPerPeople")]
        public long OneTestPerPeople
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Population
        /// Gets or Sets Population....
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
        /// Gets or sets the RecoveredPerOneMillion.
        /// </summary>
        [JsonProperty("recoveredPerOneMillion")]
        public long RecoveredPerOneMillion
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
        /// Gets or sets the TestsPerOneMillion.
        /// </summary>
        [JsonProperty("testsPerOneMillion")]
        public long TestsPerOneMillion
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
        /// Gets or sets the TodayDeaths.
        /// </summary>
        [JsonProperty("todayDeaths")]
        public long TodayDeaths
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the TodayRecovered.
        /// </summary>
        [JsonProperty("todayRecovered")]
        public long TodayRecovered
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