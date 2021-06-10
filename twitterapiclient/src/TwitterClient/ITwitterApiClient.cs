namespace TwitterClient
{
    using TwitterClient.Services.Interfaces;

    /// <summary>
    /// Twitter Api Client Interface
    /// </summary>
    public interface ITwitterApiClient
    {
        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="accessToken">The access token.</param>
        /// <returns>
        /// IApiService
        /// </returns>
        TEntity GetService<TEntity>()
            where TEntity : IApiService;
    }
}