namespace TwitterClient.Entities.Response
{
    using Newtonsoft.Json;

    /// <summary>
    /// Error
    /// </summary>
    public class ErrorContent
    {
        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        [JsonProperty("parameter")]
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        [JsonProperty("details")]
        public string Details { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [JsonProperty("value")]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
