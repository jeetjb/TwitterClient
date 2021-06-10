namespace TwitterClient
{
    using TwitterClient.Services;
    using TwitterClient.Services.Interfaces;

    /// <summary>
    /// Twitter Api Client
    /// </summary>
    public class TwitterApiClient : ITwitterApiClient
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private readonly string _accountId;
        private readonly bool _isSandboxRequest;
        private readonly string _accessToken;
        private readonly string _tokenSecret;

        /// <summary>
        /// Initializes a new instance of the <see cref="TwitterApiClient" /> class.
        /// Initializes access and refresh token to interact with resources which require authorization
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="tokenSecret">The token secret.</param>
        /// <param name="consumerKey">The consumer key.</param>
        /// <param name="consumerSecret">The consumer secret.</param>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="isSandBoxRequest">if set to <c>true</c> [is sand box request].</param>
        public TwitterApiClient(string accessToken, string tokenSecret, string consumerKey, string consumerSecret, string accountId = "", bool isSandBoxRequest = false)
        {
            _accessToken = accessToken;
            _tokenSecret = tokenSecret;
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _accountId = accountId;
            _isSandboxRequest = isSandBoxRequest;
        }

        /// <inheritdoc/>
        public virtual TEntity GetService<TEntity>()
            where TEntity : IApiService
        {
            IApiService apiService = null;
            if (typeof(TEntity) == typeof(ICampaignService))
            {
                apiService = new CampaignService(_accessToken, _tokenSecret, _consumerKey, _consumerSecret, _accountId, _isSandboxRequest);
            }
            else if (typeof(TEntity) == typeof(ILineItemService))
            {
                apiService = new LineItemService(_accessToken, _tokenSecret, _consumerKey, _consumerSecret, _accountId, _isSandboxRequest);
            }
            else if (typeof(TEntity) == typeof(IFundingService))
            {
                apiService = new FundingService(_accessToken, _tokenSecret, _consumerKey, _consumerSecret, _accountId, _isSandboxRequest);
            }
            else if (typeof(TEntity) == typeof(IIabCategoryService))
            {
                apiService = new IabCategoryService(_accessToken, _tokenSecret, _consumerKey, _consumerSecret, _isSandboxRequest);
            }
            else if (typeof(TEntity) == typeof(ITargetingService))
            {
                apiService = new TargetingService(_accessToken, _tokenSecret, _consumerKey, _consumerSecret, _accountId, _isSandboxRequest);
            }
            else if (typeof(TEntity) == typeof(ITweetService))
            {
                apiService = new TweetService(_accessToken, _tokenSecret, _consumerKey, _consumerSecret, _accountId, _isSandboxRequest);
            }

            return (TEntity)apiService;
        }
    }
}