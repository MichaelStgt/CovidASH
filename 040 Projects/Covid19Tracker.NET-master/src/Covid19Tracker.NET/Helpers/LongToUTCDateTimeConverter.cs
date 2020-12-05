// <copyright file="LongToUTCDateTimeConverter.cs" company="Egbakou, Kodjo Laurent (egbakou)">
// https://github.com/egbakou/Covid19Tracker.NET
// </copyright>

namespace Covid19Tracker.Helpers
{
    using System;
    using System.Diagnostics;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Custom DateTime JSON serializer/deserializer: see https://blog.kulman.sk/custom-datetime-deserialization-with-json-net/.
    /// </summary>
    public class LongToUTCDateTimeConverter : DateTimeConverterBase
    {
        #region Fields

        /// <summary>
        /// Defines the start.
        /// </summary>
        private static readonly DateTime Start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        #endregion Fields

        #region Methods

        /// <summary>
        /// Reads value from JSON.
        /// </summary>
        /// <param name="reader">JSON reader.</param>
        /// <param name="objectType">Target type.</param>
        /// <param name="existingValue">Existing value.</param>
        /// <param name="serializer">JSON serialized.</param>
        /// <returns>Deserialized DateTime.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return null;
            }

            Debug.WriteLine("{VALUE: " + reader.Value + "}");
            return Start.AddMilliseconds((long)reader.Value).ToLocalTime();
        }

        /// <summary>
        /// Writes value to JSON.
        /// </summary>
        /// <param name="writer">JSON writer.</param>
        /// <param name="value">Value to be written.</param>
        /// <param name="serializer">JSON serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - Start).TotalMilliseconds + "000");
        }

        #endregion Methods
    }
}