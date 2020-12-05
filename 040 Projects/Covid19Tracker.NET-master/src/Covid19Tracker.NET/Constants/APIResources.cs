// <copyright file="APIResources.cs" company="Egbakou, Kodjo Laurent (egbakou)">
// https://github.com/egbakou/Covid19Tracker.NET
// </copyright>

namespace Covid19Tracker.Constants
{
    /// <summary>
    /// Defines the <see cref="APIResources" />.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:Fields should be private", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "RCS1102:Make class static.", Justification = "<Pending>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "<Pending>")]
    public class APIResources
    {
        #region Fields

        /// <summary>
        /// Defines the ALL_ENDPOINT.
        /// </summary>
        public static string ALL_ENDPOINT = "all";

        /// <summary>
        /// Defines the API_BASE_URI.
        /// </summary>
        public static string API_BASE_URI = "https://disease.sh/v2/";

        /// <summary>
        /// Defines the CONTINENTS_ENDPOINT.
        /// </summary>
        public static string CONTINENTS_ENDPOINT = "continents";

        /// <summary>
        /// Defines the COUNTRIES_ENDPOINT.
        /// </summary>
        public static string COUNTRIES_ENDPOINT = "countries";

        #endregion Fields
    }
}