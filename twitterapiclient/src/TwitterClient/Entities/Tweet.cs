namespace TwitterClient.Entities
{
    /// <summary>
    /// A tweet.
    /// </summary>
    public class Tweet
    {
        /// <summary>
        /// Gets or sets the tweet text.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Newtonsoft.Json.JsonPropertyAttribute("full_text")]
        public string Text { get; set; }

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
        public long TweetId { get; set; }
    }
}
