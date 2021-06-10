namespace TwitterClient.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TwitterClient.Entities;
    using TwitterClient.Entities.Response;
    using TwitterClient.Enums;
    using TwitterClient.Exceptions;
    using TwitterClient.Helpers;
    using TwitterClient.Services.Interfaces;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <inheritdoc/>
    internal class TargetingService : BaseService, ITargetingService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TargetingService" /> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="tokenSecret">The token secret.</param>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="isSandBoxRequest">if set to <c>true</c> [is sand box request].</param>
        internal TargetingService(string accessToken, string tokenSecret, string consumerKey, string consumerSecret, string accountId, bool isSandBoxRequest = false)
            : base(accessToken, tokenSecret, consumerKey, consumerSecret, accountId, isSandBoxRequest)
        {
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TargetingCriteria>> GetTargetingCriteriasAsync(TargetingType type, Parameters param, string searchQuery, bool getAll = false)
        {
            if (param == null)
            {
                throw new ArgumentNullException(nameof(param));
            }

            if (type == TargetingType.events)
            {
                if (!param.ContainsKey("event_types") || string.IsNullOrEmpty(param["event_types"].ToString()))
                {
                    throw new ArgumentException("'event_type' parameter is required for EVENTS targeting type.");
                }
            }

            if (type == TargetingType.tv_shows)
            {
                if (!param.ContainsKey("locale") || string.IsNullOrEmpty(param["locale"].ToString()))
                {
                    throw new ArgumentException("'locale' parameter is required for TV_SHOWS targeting type.");
                }
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                param["q"] = searchQuery;
            }

            var paramBackup = param;

            HttpResponseMessage response;
            string result = string.Empty;
            var res = new List<TargetingCriteria>();
            do
            {
                param = paramBackup;
                param = SetCursorInParam(param, result);

                response = await RequestAsync(HttpMethod.Get, Constants.GetTargetingUrl + type, param);
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

                res.AddRange(JsonConvert.DeserializeObject<IEnumerable<TargetingCriteria>>(JObject.Parse(result)["data"].ToString()));
            }
            while (getAll && IsNextPageExists(result));

            return res;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TargetingCriteria>> MapLineItemTargetsAsync(IEnumerable<BulkParameters> parameters)
        {
            foreach (var param in parameters)
            {
                if (param.OperationType == null || string.IsNullOrEmpty(param.OperationType.ToString()))
                {
                    throw new ArgumentException("'operation_type' parameter is required for bulk target mapping.");
                }

                if (param.Params == null || string.IsNullOrEmpty(param.Params.ToString()))
                {
                    throw new ArgumentException("'params' parameter is required for bulk target mapping.");
                }
            }

            var response = await BulkRequestAsync(HttpMethod.Post, Constants.BatchPostTargetingUrl, parameters);
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

            var res = JsonConvert.DeserializeObject<IEnumerable<TargetingCriteria>>(JObject.Parse(result)["data"].ToString());

            return res;
        }

        /// <summary>
        /// Maps the line item target asynchronous.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns>
        /// TargetingCriteria
        /// </returns>
        public async Task<TargetingCriteria> MapLineItemTargetAsync(Parameters param)
        {
            var response = await RequestAsync(HttpMethod.Post, Constants.PostTargetingUrl, param);
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

            var res = JsonConvert.DeserializeObject<TargetingCriteria>(JObject.Parse(result)["data"].ToString());

            return res;
        }
    }
}
