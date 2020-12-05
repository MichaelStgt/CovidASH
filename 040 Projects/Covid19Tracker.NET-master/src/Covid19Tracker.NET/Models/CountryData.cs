// <copyright file="CountryData.cs" company="Egbakou, Kodjo Laurent (egbakou)">
// https://github.com/egbakou/Covid19Tracker.NET
// </copyright>

namespace Covid19Tracker.Models
{
    using System;
    using Covid19Tracker.Helpers;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a country data class.
    /// Sample Data can be found in
    /// ..\App_data\CountryData.json
    /// </summary>
    public class CountryData
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Active.
        /// OK
        /// </summary>
        [JsonProperty("active")]
        public long Active
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the ActivePerOneMillion.
        /// OK
        /// </summary>
        [JsonProperty("activePerOneMillion")]
        public long ActivePerOneMillion
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Cases.
        /// OK
        /// </summary>
        [JsonProperty("cases")]
        public long Cases
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the CasesPerOneMillion.
        /// OK
        /// </summary>
        [JsonProperty("casesPerOneMillion")]
        public long CasesPerOneMillion
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Continent.
        /// OK
        /// </summary>
        [JsonProperty("continent")]
        public string Continent
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the CountryInfo.
        /// Todo: use this to create a filter page
        /// </summary>
        [JsonProperty("countryInfo")]
        public CountryInfo CountryInfo
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the CountryName.
        /// OK
        /// </summary>
        [JsonProperty("country")]
        public string CountryName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Critical.
        /// OK
        /// </summary>
        [JsonProperty("critical")]
        public long Critical
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the CriticalPerOneMillion.
        /// OK
        /// </summary>
        [JsonProperty("criticalPerOneMillion")]
        public long CriticalPerOneMillion
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Deaths.
        /// OK
        /// </summary>
        [JsonProperty("deaths")]
        public long Deaths
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the DeathsPerOneMillion.
        /// OK
        /// </summary>
        [JsonProperty("deathsPerOneMillion")]
        public long DeathsPerOneMillion
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the OneCasePerPeople.
        /// No idea what this should be good for
        /// </summary>
        [JsonProperty("oneCasePerPeople")]
        public long OneCasePerPeople
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the OneDeathPerPeople.
        /// No idea what this should be good for
        /// </summary>
        [JsonProperty("oneDeathPerPeople")]
        public long OneDeathPerPeople
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the OneTestPerPeople.
        /// No idea what this should be good for
        /// </summary>
        [JsonProperty("oneTestPerPeople")]
        public long OneTestPerPeople
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Population
        /// </summary>
        [JsonProperty("population")]
        public long Population
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Recovered.
        /// OK
        /// </summary>
        [JsonProperty("recovered")]
        public long Recovered
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the RecoveredPerOneMillion.
        /// OK
        /// </summary>
        [JsonProperty("recoveredPerOneMillion")]
        public long RecoveredPerOneMillion
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Tests.
        /// OK
        /// </summary>
        [JsonProperty("tests")]
        public long Tests
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the TestsPerOneMillion.
        /// OK
        /// </summary>
        [JsonProperty("testsPerOneMillion")]
        public long TestsPerOneMillion
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the TodayCases.
        /// OK
        /// </summary>
        [JsonProperty("todayCases")]
        public long TodayCases
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the TodayDeaths.
        /// OK
        /// </summary>
        [JsonProperty("todayDeaths")]
        public long TodayDeaths
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the TodayDeaths.
        /// OK
        /// </summary>
        [JsonProperty("todayRecovered")]
        public long TodayRecovered
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the Updated.
        /// OK
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