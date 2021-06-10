namespace TwitterClient.Entities
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A single campaign.
    /// </summary>
    public class TargetingCriteria
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>
        /// The manufacturer.
        /// </value>
        [JsonProperty("manufacturer")]
        public string Manufacturer { get; set; }

        /// <summary>
        /// Gets or sets the targeting value.
        /// </summary>
        /// <value>
        /// The targeting value.
        /// </value>
        [JsonProperty("targeting_value")]
        public string TargetingValue { get; set; }

        /// <summary>
        /// Gets or sets the type of the os.
        /// </summary>
        /// <value>
        /// The type of the os.
        /// </value>
        [JsonProperty("os_type")]
        public string OsType { get; set; }

        /// <summary>
        /// Gets or sets the type of the targeting.
        /// </summary>
        /// <value>
        /// The type of the targeting.
        /// </value>
        [JsonProperty("targeting_type")]
        public string TargetingType { get; set; }

        /// <summary>
        /// Gets or sets the country_code.
        /// </summary>
        /// <value>
        /// The country_code.
        /// </value>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the Location.
        /// </summary>
        /// <value>
        /// The type of the Location.
        /// </value>
        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the locale.
        /// </summary>
        /// <value>
        /// The locale.
        /// </value>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the genre.
        /// </summary>
        /// <value>
        /// The genre.
        /// </value>
        [JsonProperty("genre")]
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets the locales.
        /// </summary>
        /// <value>
        /// The locales.
        /// </value>
        [JsonProperty("locales")]
#pragma warning disable CA2227 // Collection properties should be read only
        public List<Locale> Locales { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
