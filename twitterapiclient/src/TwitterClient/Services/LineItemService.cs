namespace TwitterClient.Services
{
    using System.Collections.Generic;
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
    internal class LineItemService : BaseService, ILineItemService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineItemService" /> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="tokenSecret">The token secret.</param>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="isSandBoxRequest">if set to <c>true</c> [is sand box request].</param>
        internal LineItemService(string accessToken, string tokenSecret, string consumerKey, string consumerSecret, string accountId, bool isSandBoxRequest = false)
            : base(accessToken, tokenSecret, consumerKey, consumerSecret, accountId, isSandBoxRequest)
        {
        }

        /// <inheritdoc/>
        public async Task<LineItem> CreateLineItemAsync(Parameters param)
        {
            var response = await RequestAsync(HttpMethod.Post, Constants.PostLineItemsUrl, param);
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

            var res = JsonConvert.DeserializeObject<LineItem>(JObject.Parse(result)["data"].ToString());

            return res;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<LineItem>> BulkCreateLineItemAsync(IEnumerable<BulkParameters> param)
        {
            var response = await BulkRequestAsync(HttpMethod.Post, Constants.BatchPostLineItemsUrl, param);
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

            var res = JsonConvert.DeserializeObject<IEnumerable<LineItem>>(JObject.Parse(result)["data"].ToString());

            return res;
        }
    }
}
