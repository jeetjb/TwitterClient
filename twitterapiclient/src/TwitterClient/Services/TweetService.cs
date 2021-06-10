namespace TwitterClient.Services
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TwitterClient.Entities;
    using TwitterClient.Entities.Response;
    using TwitterClient.Exceptions;
    using TwitterClient.Helpers;
    using TwitterClient.Services.Interfaces;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <inheritdoc/>
    internal class TweetService : BaseService, ITweetService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TweetService" /> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="tokenSecret">The token secret.</param>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="isSandBoxRequest">if set to <c>true</c> [is sand box request].</param>
        internal TweetService(string accessToken, string tokenSecret, string consumerKey, string consumerSecret, string accountId, bool isSandBoxRequest = false)
            : base(accessToken, tokenSecret, consumerKey, consumerSecret, accountId, isSandboxRequest: isSandBoxRequest)
        {
        }

        /// <inheritdoc/>
        public async Task<TweetsResponseModel> GetTweetsAsync(string cursor, string tweetIds)
        {
            HttpResponseMessage response;
            var param = new Parameters();
            param["tweet_type"] = "PUBLISHED";
            param["timeline_type"] = "ALL";

            if (!string.IsNullOrEmpty(cursor))
            {
                param["cursor"] = cursor;
            }
            else if (!string.IsNullOrEmpty(tweetIds))
            {
                param["tweet_ids"] = tweetIds;
            }

            response = await RequestAsync(HttpMethod.Get, Constants.GetTweetsUrl, param);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    throw new ApiOAuthException();
                }

                var errorObject = JsonConvert.DeserializeObject<ErrorObject>(result);
                throw new ApiException(errorObject);
            }

            var res = new TweetsResponseModel();
            res.Tweets = JsonConvert.DeserializeObject<IEnumerable<Tweet>>(JObject.Parse(result)["data"].ToString());
            var next = JObject.Parse(result)["next_cursor"];
            if (!string.IsNullOrEmpty(result) && next != null && !string.IsNullOrEmpty(next.ToString()))
            {
                res.Cursor = JObject.Parse(result)["next_cursor"].ToString();
            }

            return res;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PromotedTweet>> PostPromotedTweetsAsync(string lineItemId, string tweetIds)
        {
            var param = new Parameters();
            if (!string.IsNullOrEmpty(lineItemId))
            {
                param["line_item_id"] = lineItemId;
            }

            if (!string.IsNullOrEmpty(tweetIds))
            {
                param["tweet_ids"] = tweetIds;
            }

            var response = await RequestAsync(HttpMethod.Post, Constants.PostPromotedTweetsUrl, param);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ApiOAuthException();
                }

                var errorObject = JsonConvert.DeserializeObject<ErrorObject>(result);
                throw new ApiException(errorObject);
            }

            var res = JsonConvert.DeserializeObject<IEnumerable<PromotedTweet>>(JObject.Parse(result)["data"].ToString());

            return res;
        }
    }
}
