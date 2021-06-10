namespace TwitterClient.Entities
{
    /// <summary>
    /// A single campaign.
    /// </summary>
    public class IabCategory
    {
        /// <summary>
        /// Gets or sets the resource name of the campaign.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Newtonsoft.Json.JsonPropertyAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the timestamp when the campaign was last updated. Assigned by the system.
        /// </summary>
        /// <value>
        /// The update time.
        /// </value>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        [Newtonsoft.Json.JsonPropertyAttribute("parent_id")]
        public string ParentId { get; set; }
    }
}
