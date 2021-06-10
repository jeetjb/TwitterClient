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
    internal class FundingService : BaseService, IFundingService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FundingService" /> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="tokenSecret">The token secret.</param>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="isSandBoxRequest">if set to <c>true</c> [is sand box request].</param>
        internal FundingService(string accessToken, string tokenSecret, string consumerKey, string consumerSecret, string accountId, bool isSandBoxRequest = false)
            : base(accessToken, tokenSecret, consumerKey, consumerSecret, accountId, isSandBoxRequest)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<FundingInstrument>> GetFundingInstrumentsAsync()
        {
            HttpResponseMessage response;
            string result = string.Empty;
            var param = new Parameters();
            var res = new List<FundingInstrument>();
            do
            {
                param = new Parameters();
                param = SetCursorInParam(param, result);

                response = await RequestAsync(HttpMethod.Get, Constants.GetFundingUrl, param);
                result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new ApiOAuthException();
                    }

                    var errorObject = JsonConvert.DeserializeObject<ErrorObject>(result);
                    throw new ApiException(errorObject);
                }

                res.AddRange(JsonConvert.DeserializeObject<IEnumerable<FundingInstrument>>(JObject.Parse(result)["data"].ToString()));
            }
            while (IsNextPageExists(result));

            return res;
        }
    }
}
