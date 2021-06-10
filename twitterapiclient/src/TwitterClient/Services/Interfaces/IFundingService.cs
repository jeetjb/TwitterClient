namespace TwitterClient.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TwitterClient.Entities;

    /// <summary>
    /// Funding service
    /// </summary>
    /// <seealso cref="TwitterClient.Services.BaseService" />
    public interface IFundingService : IApiService
    {
        /// <summary>
        /// get funding instruments asynchronous.
        /// </summary>
        /// <returns>
        /// A <see cref="FundingInstrument" /> representing newly created instance of FundingInstrument.
        /// </returns>
        Task<IEnumerable<FundingInstrument>> GetFundingInstrumentsAsync();
    }
}