namespace TwitterClient.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// tweets.
    /// </summary>
    public class TweetsResponseModel
    {
        /// <summary>
        /// Gets or sets the tweets.
        /// </summary>
        /// <value>
        /// The tweets.
        /// </value>
        public IEnumerable<Tweet> Tweets { get; set; }

        /// <summary>
        /// Gets or sets the cursor.
        /// </summary>
        /// <value>
        /// The cursor.
        /// </value>
        public string Cursor { get; set; }
    }
}
