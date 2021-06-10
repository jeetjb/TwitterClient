namespace TwitterClient.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Encapsulates GET/POST parameter functionality
    /// </summary>
    public class Parameters : Dictionary<string, object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters"/> class.
        /// </summary>
        public Parameters()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameters"/> class.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <param name="value">The value.</param>
        public Parameters(string field, object value)
            : base()
        {
            this.Add(field, value);
        }

        /// <summary>
        /// Parses objects into URL escaped strings
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>encoded url</returns>
        public static string StringEncode(object obj)
        {
            string result = Uri.EscapeDataString(Parse(obj));

            // These characters are not escaped by EscapeDataString()
            result = result
                .Replace("(", "%28")
                .Replace(")", "%29")
                .Replace("$", "%24")
                .Replace("!", "%21")
                .Replace("*", "%2A")
                .Replace("'", "%27");

            // Tilde gets escaped but is a reserved character and is thus allowed.
            // @see https://dev.twitter.com/oauth/overview/percent-encoding-parameters
            result = result.Replace("%7E", "~");
            return result;
        }

        /// <summary>
        /// Parses object into strings
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>parse to string</returns>
        public static string Parse(object obj)
        {
            string result = string.Empty;
            if (obj != null)
            {
                switch (obj.GetType().FullName)
                {
                    case "System.Boolean":
                        result = string.Format(CultureInfo.InvariantCulture, "{0}", obj).ToLower();
                        break;
                    case "System.DateTime":
                        result = string.Format(CultureInfo.InvariantCulture, "{0}", ((DateTime)obj).Ticks);
                        break;
                    default:
                        result = string.Format(CultureInfo.InvariantCulture, "{0}", obj);

                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Returns a URL/Formbody representation of the parameters
        /// </summary>
        /// <returns>joined string</returns>
        public override string ToString()
        {
            List<string> output = new List<string>();
            foreach (string key in this.Keys)
            {
                output.Add(string.Format(CultureInfo.InvariantCulture, "{0}={1}", StringEncode(key), StringEncode(this[key])));
            }

            return string.Join("&", output.ToArray());
        }
    }
}
