namespace TwitterClient.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using TwitterClient.Entities;
    using TwitterClient.Exceptions;
    using TwitterClient.Helpers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Entry point API for Twitter requests
    /// </summary>
    internal abstract class BaseService
    {
        private readonly string _twitterBaseUrl = "https://ads-api.twitter.com/9/";
        private readonly string _twitterSandboxBaseUrl = "https://ads-api-sandbox.twitter.com/9/";
        private Tokens _tokens;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService" /> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="accessTokenSecret">The access token secret.</param>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="isSandboxRequest">if set to <c>true</c> [is sandbox request].</param>
        public BaseService(string accessToken, string accessTokenSecret, string consumerKey, string consumerSecret, string accountId = "", bool isSandboxRequest = false)
        {
            _tokens = new Tokens();
            _tokens.AccessToken = accessToken;
            _tokens.AccessTokenSecret = accessTokenSecret;
            _tokens.ConsumerKey = consumerKey;
            _tokens.ConsumerSecret = consumerSecret;
            AccountId = accountId;
            if (isSandboxRequest)
            {
                BaseUrl = _twitterSandboxBaseUrl;
            }
            else
            {
                BaseUrl = _twitterBaseUrl;
            }
        }

        /// <summary>
        /// Gets or sets the base URL.
        /// </summary>
        /// <value>
        /// The base URL.
        /// </value>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        public string AccountId { get; set; }

        /// <summary>
        /// Determines whether [is next page exists] [the specified result].
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>
        ///   <c>true</c> if [is next page exists] [the specified result]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNextPageExists(string result)
        {
            return JObject.Parse(result)["next_cursor"] != null &&
                   !string.IsNullOrEmpty(JObject.Parse(result)["next_cursor"].ToString());
        }

        /// <summary>
        /// Sets the cursor in parameter.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <param name="result">The result.</param>
        /// <returns>params</returns>
        public static Parameters SetCursorInParam(Parameters param, string result)
        {
            if (!string.IsNullOrEmpty(result) && JObject.Parse(result)["next_cursor"] != null && !string.IsNullOrEmpty(JObject.Parse(result)["next_cursor"].ToString()))
            {
                param["cursor"] = JObject.Parse(result)["next_cursor"].ToString();
            }

            return param;
        }

        /// <summary>
        /// Requests the specified type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="type">The type.</param>
        /// <param name="urlFragment">The URL fragment.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// response
        /// </returns>
        /// <exception cref="ApiException">api exception</exception>
        public async Task<HttpResponseMessage> RequestAsync(HttpMethod type, string urlFragment, Parameters parameters)
        {
            Uri uri = GetUri(type, urlFragment, parameters);
            using (var client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(type, uri))
                {
                    if (type == HttpMethod.Post)
                    {
                        var content = new StringContent(parameters.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");
                        request.Content = content;
                    }

                    OAuthHelper.Sign(request, _tokens, parameters);
                    var response = await client.SendAsync(request);
                    return response;
                }
            }
        }

        /// <summary>
        /// Requests the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="urlFragment">The URL fragment.</param>
        /// <param name="bulkParameters">The bulk parameters.</param>
        /// <returns>
        /// response
        /// </returns>
        /// <exception cref="ApiException">api exception</exception>
        public async Task<HttpResponseMessage> BulkRequestAsync(HttpMethod type, string urlFragment, IEnumerable<BulkParameters> bulkParameters)
        {
            var parameters = new Parameters();
            Uri uri = GetUri(type, urlFragment, parameters);
            using (var client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage(type, uri))
                {
                    if (type == HttpMethod.Post)
                    {
                        var content = new StringContent(JsonConvert.SerializeObject(bulkParameters), Encoding.UTF8, "application/json");
                        request.Content = content;
                    }

                    OAuthHelper.Sign(request, _tokens, parameters);
                    var response = await client.SendAsync(request);
                    return response;
                }
            }
        }

        /// <summary>
        /// Gets the URI.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="urlFragment">The URL fragment.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>the urk</returns>
        /// <exception cref="Exception">
        /// Invalid request type or request type not supported
        /// or
        /// </exception>
        private Uri GetUri(HttpMethod type, string urlFragment, Parameters parameters)
        {
            string baseUrl = BaseUrl + urlFragment;
            if (urlFragment.ToUpperInvariant().StartsWith("HTTP", StringComparison.InvariantCulture))
            {
                baseUrl = urlFragment;
            }

            if (baseUrl.Contains("{account_id}"))
            {
                baseUrl = baseUrl.Replace("{account_id}", AccountId);
            }

            switch (type.ToString().ToUpperInvariant())
            {
                case "POST":
                    return new Uri(baseUrl);

                case "GET":
                    if (parameters == null || parameters.Count == 0)
                    {
                        return new Uri(baseUrl);
                    }

                    if (!baseUrl.Contains("?"))
                    {
                        baseUrl += "?";
                    }
                    else if (!baseUrl.EndsWith("&", StringComparison.InvariantCulture))
                    {
                        baseUrl += "&";
                    }

                    return new Uri(baseUrl + parameters.ToString());

                default:
                    return null;
            }
        }
    }
}