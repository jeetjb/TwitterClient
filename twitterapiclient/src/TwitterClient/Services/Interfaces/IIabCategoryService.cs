namespace TwitterClient.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TwitterClient.Entities;

    /// <summary>
    /// IabCategory Service
    /// </summary>
    /// <seealso cref="TwitterClient.Services.BaseService" />
    public interface IIabCategoryService : IApiService
    {
        /// <summary>
        /// Get Iab categories asynchronous.
        /// </summary>
        /// <returns>
        /// A <see cref="IabCategory" /> representing newly created instance of IabCategory.
        /// </returns>
        Task<IEnumerable<IabCategory>> GetIabCategoriesAsync();
    }
}