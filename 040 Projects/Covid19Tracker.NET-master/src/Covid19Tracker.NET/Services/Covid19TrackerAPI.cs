// <copyright file="Covid19TrackerAPI.cs" company="Egbakou, Kodjo Laurent (egbakou)">
// https://github.com/egbakou/Covid19Tracker.NET
// </copyright>

namespace Covid19Tracker.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Covid19Tracker.Models;
    using Newtonsoft.Json.Linq;
    using RestSharp;
    using static Covid19Tracker.Constants.APIResources;

    /// <summary>
    /// A Class consumes an API provided by @NovelCOVID (Github) for tracking the global coronavirus (COVID-19, SARS-CoV-2) outbreak.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "RCS1102:Make class static.", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<Pending>")]
    public class Covid19TrackerAPI
    {
        #region Fields

        /// <summary>
        /// Defines a RestClient static object....
        /// </summary>
        private static readonly RestClient Client = new RestClient(API_BASE_URI);

        #endregion Fields

        #region Methods

        /// <summary>
        /// Get All Continents Totals for Actual and Yesterday Data.
        /// </summary>
        /// <returns>A List with an element for each continent that has stats available.</returns>
        public static async Task<List<ContinentData>> GetContinentsDataAsync()
        {
            var request = new RestRequest(
                $"{CONTINENTS_ENDPOINT}",
                Method.GET,
                DataFormat.Json);

            IRestResponse response = await Client.ExecuteGetAsync(request).ConfigureAwait(false);

            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray.ToObject<List<ContinentData>>();
            }

            throw new Exception("No data found. Please check if https://disease.sh is available.");
        }

        /// <summary>
        /// Get All Countries Totals for Actual and Yesterday Data.
        /// </summary>
        /// <returns>A List with an element for each country that has stats available./>.</returns>
        public static async Task<List<CountryData>> GetCountriesDataAsync()
        {
            var request = new RestRequest(
                $"{COUNTRIES_ENDPOINT}",
                Method.GET,
                DataFormat.Json);

            IRestResponse response = await Client.ExecuteGetAsync(request).ConfigureAwait(false);

            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JArray jsonArray = JArray.Parse(response.Content);
                return jsonArray.ToObject<List<CountryData>>();
            }

            throw new Exception("No data found. Please check if https://disease.sh is available.");
        }

        /// <summary>
        /// Get a Specific Continent Totals for Actual and Yesterday Data.
        /// </summary>
        /// <param name="continent">The continent name (in English).</param>
        /// <returns>The continent data.</returns>
        public static async Task<ContinentData> GetDataByContinentAsync(string continent)
        {
            var request = new RestRequest(
                $"{CONTINENTS_ENDPOINT}/{continent}",
                Method.GET,
                DataFormat.Json);

            IRestResponse response = await Client.ExecuteGetAsync(request).ConfigureAwait(false);

            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JObject jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<ContinentData>();
            }

            throw new Exception("Continent not found or doesn't have any cases");
        }

        /// <summary>
        /// Get a Specific Country's Totals for Actual and Yesterday Data.s.
        /// </summary>
        /// <param name="country">The country name (in English).</param>
        /// <returns>Country data.</returns>
        public static async Task<CountryData> GetDataByCountryAsync(string country)
        {
            var request = new RestRequest(
                $"{COUNTRIES_ENDPOINT}/{country}",
                Method.GET,
                DataFormat.Json);

            IRestResponse response = await Client.ExecuteGetAsync(request).ConfigureAwait(false);

            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JObject jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<CountryData>();
            }

            throw new Exception("Country not found or doesn't have any cases");
        }

        /// <summary>
        /// Get global stats: cases, deaths, recovered, time last updated, and active cases. Data is updated every 10 minutes.
        /// </summary>
        /// <returns>Global Totals for Actual and Yesterday Data.</returns>
        public static async Task<GlobalData> GetGlobalDataAsync()
        {
            var request = new RestRequest(
                $"{ALL_ENDPOINT}",
                Method.GET,
                DataFormat.Json);

            IRestResponse response = await Client.ExecuteGetAsync(request).ConfigureAwait(false);

            if (response.IsSuccessful && response.StatusCode.HasFlag(HttpStatusCode.OK))
            {
                JObject jsonObject = JObject.Parse(response.Content);
                return jsonObject.ToObject<GlobalData>();
            }

            throw new Exception("No data found. Please check if https://disease.sh is available.");
        }

        #endregion Methods
    }
}