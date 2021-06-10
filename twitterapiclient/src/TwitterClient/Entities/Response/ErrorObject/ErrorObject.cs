namespace TwitterClient.Entities.Response
{
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Error Object
    /// </summary>
    public class ErrorObject
    {
        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        [JsonProperty("errors")]
#pragma warning disable CA2227 // Collection properties should be read only
        public List<ErrorContent> Errors { get; set; }

        /// <summary>
        /// Gets or sets the operation errors.
        /// </summary>
        /// <value>
        /// The operation errors.
        /// </value>
        [JsonProperty("operation_errors")]
#pragma warning disable CA2227 // Collection properties should be read only
        public List<List<ErrorContent>> OperationErrors { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (Errors != null && Errors.Any())
            {
                return JsonConvert.SerializeObject(Errors);
            }

            if (OperationErrors != null && OperationErrors.Any())
            {
                var groupError = new List<ErrorContent>();
                var errors = OperationErrors.Where(x => x.Any());
                foreach (var elem in errors)
                {
                    var errObj = new ErrorContent();
                    errObj.Message = string.Empty;
                    foreach (var item in elem)
                    {
                        if (string.IsNullOrEmpty(errObj.Message) && !string.IsNullOrEmpty(item.Message))
                        {
                            errObj.Message = item.Message;
                        }
                        else if (!string.IsNullOrEmpty(item.Message))
                        {
                            errObj.Message = errObj.Message + ", " + item.Message;
                        }
                    }

                    groupError.Add(errObj);
                }

                return JsonConvert.SerializeObject(groupError);
            }

            return string.Empty;
        }
    }
}
