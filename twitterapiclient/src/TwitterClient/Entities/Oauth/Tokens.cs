namespace TwitterClient.Entities
{
    /// <summary>
    /// Twitter OAuth tokens
    /// </summary>
    public class Tokens
    {
        /// <summary>
        /// Gets or sets the consumer key.
        /// </summary>
        /// <value>
        /// The consumer key.
        /// </value>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the consumer secret.
        /// </summary>
        /// <value>
        /// The consumer secret.
        /// </value>
        public string ConsumerSecret { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the access token secret.
        /// </summary>
        /// <value>
        /// The access token secret.
        /// </value>
        public string AccessTokenSecret { get; set; }
    }
}
