namespace TwitterClient.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TwitterClient.Entities;

    /// <summary>
    /// Tweet Service
    /// </summary>
    /// <seealso cref="TwitterClient.Services.BaseService" />
    public interface ITweetService : IApiService
    {
        /// <summary>
        /// Get tweets asynchronous.
        /// </summary>
        /// <param name="cursor">The cursor.</param>
        /// <param name="tweetIds">The tweet ids.</param>
        /// <returns>
        /// A <see cref="Tweet" /> instances of Tweet.
        /// </returns>
        Task<TweetsResponseModel> GetTweetsAsync(string cursor, string tweetIds);

        /// <summary>
        /// Posts the promoted tweets asynchronous.
        /// </summary>
        /// <param name="lineItemId">The line item identifier.</param>
        /// <param name="tweetIds">The tweet ids.</param>
        /// <returns>promoted tweets</returns>
        Task<IEnumerable<PromotedTweet>> PostPromotedTweetsAsync(string lineItemId, string tweetIds);
    }
}