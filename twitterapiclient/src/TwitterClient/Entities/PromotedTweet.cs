namespace TwitterClient.Entities
{
    /// <summary>
    /// A promoted tweet.
    /// </summary>
    public class PromotedTweet
    {
        /// <summary>
        /// Gets or sets the tweet text.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Newtonsoft.Json.JsonPropertyAttribute("line_item_id")]
        public string LineItemId { get; set; }

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        /// <value>
        /// The update time.
        /// </value>
        [Newtonsoft.Json.JsonPropertyAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the tweet identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        [Newtonsoft.Json.JsonPropertyAttribute("tweet_id")]
        public string TweetId { get; set; }

        /// <summary>
        /// Gets or sets the approval status.
        /// </summary>
        /// <value>
        /// The approval status.
        /// </value>
        [Newtonsoft.Json.JsonProperty("approval_status")]
        public string ApprovalStatus { get; set; }
    }
}
