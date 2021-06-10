namespace TwitterClient.Exceptions
{
    using TwitterClient.Entities.Response;
    using System;
    using System.Runtime.Serialization;

#pragma warning disable CA1032

    // Implement standard exception constructors

    /// <summary>
    /// Represents any error returned by twitter API.
    /// </summary>
    [Serializable]
    public class ApiException : Exception

    // Implement standard exception constructors
#pragma warning restore CA1032
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="apiError">Object of type <see cref="ErrorObject"/>.</param>
        public ApiException(ErrorObject apiError)
            : base((apiError != null) ? apiError.ToString() : string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected ApiException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
