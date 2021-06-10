namespace TwitterClient.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TwitterClient.Entities;
    using TwitterClient.Enums;

    /// <summary>
    /// Targeting service
    /// </summary>
    /// <seealso cref="TwitterClient.Services.BaseService" />
    public interface ITargetingService : IApiService
    {
        /// <summary>
        /// get Targeting criterias asynchronous.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="param">The parameter.</param>
        /// <param name="searchQuery">The search query.</param>
        /// <param name="getAll">if set to <c>true</c> [get all].</param>
        /// <returns>
        /// A <see cref="TargetingCriteria" /> representing newly created instance of Targeting.
        /// </returns>
        Task<IEnumerable<TargetingCriteria>> GetTargetingCriteriasAsync(TargetingType type, Parameters param, string searchQuery, bool getAll = false);

        /// <summary>
        /// Maps the line item targets asynchronous.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns>mapped targets</returns>
        Task<IEnumerable<TargetingCriteria>> MapLineItemTargetsAsync(IEnumerable<BulkParameters> param);

        /// <summary>
        /// Maps the line item target asynchronous.
        /// </summary>
        /// <param name="param">The parameter.</param>
        /// <returns>TargetingCriteria</returns>
        Task<TargetingCriteria> MapLineItemTargetAsync(Parameters param);
    }
}