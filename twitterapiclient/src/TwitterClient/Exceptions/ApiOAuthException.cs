namespace TwitterClient.Exceptions
{
    using System;
    using System.Runtime.Serialization;

#pragma warning disable CA1032

    // Implement standard exception constructors

    /// <summary>
    /// Represents errors occured during API service discovery.
    /// </summary>
    [Serializable]
    public class ApiOAuthException : Exception

    // Implement standard exception constructors
#pragma warning restore CA1032
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiOAuthException"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        public ApiOAuthException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiOAuthException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected ApiOAuthException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}