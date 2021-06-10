namespace TwitterClient.Helpers
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The get targeting URL
        /// </summary>
        public const string GetTargetingUrl = "targeting_criteria/";

        /// <summary>
        /// The batch post targeting URL
        /// </summary>
        public const string BatchPostTargetingUrl = "batch/accounts/{account_id}/targeting_criteria";

        /// <summary>
        /// The batch post targeting URL
        /// </summary>
        public const string PostTargetingUrl = "accounts/{account_id}/targeting_criteria";

        /// <summary>
        /// The post campaigns URL
        /// </summary>
        public const string PostCampaignsUrl = "accounts/{account_id}/campaigns";

        /// <summary>
        /// The batch post campaigns URL
        /// </summary>
        public const string BatchPostCampaignsUrl = "batch/accounts/{account_id}/campaigns";

        /// <summary>
        /// The get funding URL
        /// </summary>
        public const string GetFundingUrl = "accounts/{account_id}/funding_instruments";

        /// <summary>
        /// The get iab category URL
        /// </summary>
        public const string GetIabCategoryUrl = "iab_categories";

        /// <summary>
        /// The post line items URL
        /// </summary>
        public const string PostLineItemsUrl = "accounts/{account_id}/line_items";

        /// <summary>
        /// The batch post line items URL
        /// </summary>
        public const string BatchPostLineItemsUrl = "batch/accounts/{account_id}/line_items";

        /// <summary>
        /// The get tweets URL
        /// </summary>
        public const string GetTweetsUrl = "accounts/{account_id}/tweets";

        /// <summary>
        /// The post promoted tweets URL
        /// </summary>
        public const string PostPromotedTweetsUrl = "accounts/{account_id}/promoted_tweets";
    }
}
