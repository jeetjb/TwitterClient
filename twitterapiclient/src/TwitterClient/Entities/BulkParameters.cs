namespace TwitterClient.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    /// BulkParameters
    /// </summary>
    public class BulkParameters
    {
        /// <summary>
        /// Gets or sets the type of the operation.
        /// </summary>
        /// <value>
        /// The type of the operation.
        /// </value>
        [JsonProperty("operation_type")]
        public string OperationType { get; set; }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>
        /// The parameters.
        /// </value>
        [JsonProperty("params")]
        public object Params { get; set; }
    }
}
