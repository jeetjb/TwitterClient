namespace TwitterClient.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    /// Locale.
    /// </summary>
    public class Locale
    {
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
