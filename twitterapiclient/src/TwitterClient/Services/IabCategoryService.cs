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
    internal class IabCategoryService : BaseService, IIabCategoryService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IabCategoryService" /> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="tokenSecret">The token secret.</param>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        /// <param name="isSandBoxRequest">if set to <c>true</c> [is sand box request].</param>
        internal IabCategoryService(string accessToken, string tokenSecret, string consumerKey, string consumerSecret, bool isSandBoxRequest = false)
            : base(accessToken, tokenSecret, consumerKey, consumerSecret, isSandboxRequest: isSandBoxRequest)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IabCategory>> GetIabCategoriesAsync()
        {
            HttpResponseMessage response;
            string result = string.Empty;
            var param = new Parameters();
            var res = new List<IabCategory>();
            do
            {
                param = new Parameters();
                param = SetCursorInParam(param, result);

                response = await RequestAsync(HttpMethod.Get, Constants.GetIabCategoryUrl, param);
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

                res.AddRange(JsonConvert.DeserializeObject<IEnumerable<IabCategory>>(JObject.Parse(result)["data"].ToString()));
            }
            while (IsNextPageExists(result));

            return res;
        }
    }
}
