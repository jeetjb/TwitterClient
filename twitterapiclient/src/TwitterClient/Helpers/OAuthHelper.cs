namespace TwitterClient.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography;
    using System.Text;
    using TwitterClient.Entities;

    /// <summary>
    /// OAuthHelper
    /// </summary>
    public static class OAuthHelper
    {
        /// <summary>
        /// Signs a web request by adding signed OAuth Authorisation header
        /// </summary>
        /// <param name="request">The WebRequest object to add OAuth header to</param>
        /// <param name="tokens">Twitter OAuth API Parameters</param>
        /// <param name="parameters">The parameters.</param>
        public static void Sign(HttpRequestMessage request, Tokens tokens, Parameters parameters)
        {
            parameters = parameters ?? new Parameters();

            if (request == null || tokens == null)
            {
                throw new ArgumentNullException(request == null ? nameof(request) : nameof(tokens));
            }

            if (request.RequestUri.Query.Contains("?"))
            {
                string query = request.RequestUri.Query.Substring(1);
                foreach (string queryParameter in query.Split('&'))
                {
                    string[] kvp = queryParameter.Split('=');
                    if (!parameters.ContainsKey(kvp[0]))
                    {
                        try
                        {
                            parameters.Add(kvp[0], kvp[1]);
                        }
#pragma warning disable CA1031 // Do not catch general exception types
                        catch
                        {
                        }
#pragma warning restore CA1031 // Do not catch general exception types
                    }
                }
            }

            parameters.Add("oauth_version", "1.0");
            parameters.Add("oauth_nonce", GetNonce());
            parameters.Add("oauth_timestamp", GetTimeStamp());
            parameters.Add("oauth_signature_method", "HMAC-SHA1");
            parameters.Add("oauth_consumer_key", tokens.ConsumerKey);
            parameters.Add("oauth_consumer_secret", tokens.ConsumerSecret);

            if (!string.IsNullOrEmpty(tokens.AccessToken))
            {
                parameters.Add("oauth_token", tokens.AccessToken);
            }

            if (!string.IsNullOrEmpty(tokens.AccessTokenSecret))
            {
                parameters.Add("oauth_token_secret", tokens.AccessTokenSecret);
            }

            // Add signaure
            parameters.Add("oauth_signature", GetSignature(request, parameters, tokens));

            // Append OAuth header
            request.Headers.Add("Authorization", GetOAuth(parameters));
        }

        #region Helper Methods

        /// <summary>
        /// Get the timestamp for the signature
        /// </summary>
        /// <returns>timestanp</returns>
        private static string GetTimeStamp()
        {
            // UNIX time of the current UTC time
            TimeSpan span = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(span.TotalSeconds, CultureInfo.CurrentCulture).ToString(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Get a nonce
        /// </summary>
        /// <returns>GUID</returns>
        private static string GetNonce()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        /// <summary>
        /// Generates the signature.
        /// @see https://dev.twitter.com/oauth/overview/creating-signatures
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="tokens">The tokens.</param>
        /// <returns>signature</returns>
        private static string GetSignature(HttpRequestMessage request, Parameters parameters, Tokens tokens)
        {
            string signatureBaseString = GetSignatureBaseString(request, parameters);

            // Create our hash key
            string key = string.Format(
                CultureInfo.InvariantCulture,
                "{0}&{1}",
                Parameters.StringEncode(tokens.ConsumerSecret),
                Parameters.StringEncode(tokens.AccessTokenSecret));

            // Generate the hash
#pragma warning disable CA5350 // Do Not Use Weak Cryptographic Algorithms
            using (HMACSHA1 hmacsha1 = new HMACSHA1(Encoding.UTF8.GetBytes(key)))
#pragma warning restore CA5350 // Do Not Use Weak Cryptographic Algorithms
            {
                byte[] signatureBytes = hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(signatureBaseString));
                return Convert.ToBase64String(signatureBytes);
            }
        }

        /// <summary>
        /// Generates the sigature base string
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>string</returns>
        private static string GetSignatureBaseString(HttpRequestMessage request, Parameters parameters)
        {
            StringBuilder parameterString = new StringBuilder();

            string[] secretParameters = new string[]
            {
                "oauth_consumer_secret",
                "oauth_token_secret",
                "oauth_signature"
            };

            // Loop through an ordered set of parameters
            // excluding any secret oauth parameters
            foreach (var item in from p in parameters
                                  where !secretParameters.Contains(p.Key)
                                  orderby p.Key, p.Value
                                  select p)
            {
                if (parameterString.Length > 0)
                {
                    parameterString.Append("&");
                }

                string value = Parameters.Parse(item.Value);

                parameterString.Append(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}={1}",
                        Parameters.StringEncode(item.Key),
                        Parameters.StringEncode(value)));
            }

            // Join output
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}&{1}&{2}",
                request.Method.ToString().ToUpper(CultureInfo.InvariantCulture),
                Parameters.StringEncode(NormalizeUrl(request.RequestUri)),
                Parameters.StringEncode(parameterString.ToString()));
        }

        /// <summary>
        /// Returns a string representation of OAuth header
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>string</returns>
        private static string GetOAuth(Parameters parameters)
        {
            List<string> output = new List<string>();
            foreach (string key in new string[]
            {
                "oauth_consumer_key",
                "oauth_nonce",
                "oauth_signature",
                "oauth_signature_method",
                "oauth_timestamp",
                "oauth_token",
                "oauth_version"
            })
            {
                if (parameters.ContainsKey(key))
                {
                    output.Add(string.Format(CultureInfo.InvariantCulture, "{0}=\"{1}\"", Parameters.StringEncode(key), Parameters.StringEncode(parameters[key])));
                }
            }

            return string.Format(CultureInfo.InvariantCulture, "OAuth {0}", string.Join(", ", output.ToArray()));
        }

        /// <summary>
        /// Normalizes the URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>url</returns>
        private static string NormalizeUrl(Uri url)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}://{1}{2}", url.Scheme, url.Host, url.AbsolutePath);
        }

        #endregion
    }
}
