namespace TwitterClient.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TwitterClient.Entities;

    /// <summary>
    /// Campaign Service
    /// </summary>
    /// <seealso cref="TwitterClient.Services.BaseService" />
    public interface ICampaignService : IApiService
    {
        /// <summary>
        /// Creates the campaign asynchronous.
        /// </summary>
        /// <param name="campaign">The campaign.</param>
        /// <returns>
        /// A <see cref="Task" /> representing newly created instance of Campaign.
        /// </returns>
        Task<Campaign> CreateCampaignAsync(Parameters campaign);

        /// <summary>
        /// Bulks the create campaign asynchronous.
        /// </summary>
        /// <param name="bulkParameters">The bulk parameters.</param>
        /// <returns>
        /// campaigns
        /// </returns>
        Task<IEnumerable<Campaign>> BulkCreateCampaignAsync(IEnumerable<BulkParameters> bulkParameters);
    }
}