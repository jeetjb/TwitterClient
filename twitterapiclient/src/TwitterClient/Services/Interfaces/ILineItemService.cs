namespace TwitterClient.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TwitterClient.Entities;

    /// <summary>
    /// LineItem Service
    /// </summary>
    /// <seealso cref="TwitterClient.Services.BaseService" />
    public interface ILineItemService : IApiService
    {
        /// <summary>
        /// Creates the LineItem asynchronous.
        /// </summary>
        /// <param name="lineItem">The LineItem.</param>
        /// <returns>
        /// A <see cref="Task" /> representing newly created instance of LineItem.
        /// </returns>
        Task<LineItem> CreateLineItemAsync(Parameters lineItem);

        /// <summary>
        /// Bulks the create LineItem asynchronous.
        /// </summary>
        /// <param name="bulkParameters">The bulk parameters.</param>
        /// <returns>
        /// LineItems
        /// </returns>
        Task<IEnumerable<LineItem>> BulkCreateLineItemAsync(IEnumerable<BulkParameters> bulkParameters);
    }
}