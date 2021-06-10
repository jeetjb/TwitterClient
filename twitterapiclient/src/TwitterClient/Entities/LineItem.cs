namespace TwitterClient.Entities
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A single LineItem.
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// Gets or sets the type of the bid.
        /// </summary>
        /// <value>
        /// The type of the bid.
        /// </value>
        [JsonProperty("bid_strategy")]
        public string BidStrategy { get; set; }

        /// <summary>
        /// Gets or sets the advertiser user identifier.
        /// </summary>
        /// <value>
        /// The advertiser user identifier.
        /// </value>
        [JsonProperty("advertiser_user_id")]
        public int? AdvertiserUserId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the placements.
        /// </summary>
        /// <value>
        /// The placements.
        /// </value>
        [JsonProperty("placements")]
#pragma warning disable CA2227 // Collection properties should be read only
        public List<string> Placements { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the bid amount local micro.
        /// </summary>
        /// <value>
        /// The bid amount local micro.
        /// </value>
        [JsonProperty("bid_amount_local_micro")]
        public long? BidAmountLocalMicro { get; set; }

        /// <summary>
        /// Gets or sets the automatically select bid.
        /// </summary>
        /// <value>
        /// The automatically select bid.
        /// </value>
        [JsonProperty("automatically_select_bid")]
        public bool? AutomaticallySelectBid { get; set; }

        /// <summary>
        /// Gets or sets the advertiser domain.
        /// </summary>
        /// <value>
        /// The advertiser domain.
        /// </value>
        [JsonProperty("advertiser_domain")]
        public string AdvertiserDomain { get; set; }

        /// <summary>
        /// Gets or sets the target cpa local micro.
        /// </summary>
        /// <value>
        /// The target cpa local micro.
        /// </value>
        [JsonProperty("target_cpa_local_micro")]
        public long? TargetCpaLocalMicro { get; set; }

        /// <summary>
        /// Gets or sets the primary web event tag.
        /// </summary>
        /// <value>
        /// The primary web event tag.
        /// </value>
        [JsonProperty("primary_web_event_tag")]
        public object PrimaryWebEventTag { get; set; }

        /// <summary>
        /// Gets or sets the charge by.
        /// </summary>
        /// <value>
        /// The charge by.
        /// </value>
        [JsonProperty("charge_by")]
        public string ChargeBy { get; set; }

        /// <summary>
        /// Gets or sets the type of the product.
        /// </summary>
        /// <value>
        /// The type of the product.
        /// </value>
        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the duration in days.
        /// </summary>
        /// <value>
        /// The duration in days.
        /// </value>
        [JsonProperty("duration_in_days")]
        public int? DurationInDays { get; set; }

        /// <summary>
        /// Gets or sets the bid unit.
        /// </summary>
        /// <value>
        /// The bid unit.
        /// </value>
        [JsonProperty("bid_unit")]
        public string BidUnit { get; set; }

        /// <summary>
        /// Gets or sets the total budget amount local micro.
        /// </summary>
        /// <value>
        /// The total budget amount local micro.
        /// </value>
        [JsonProperty("total_budget_amount_local_micro")]
        public long? TotalBudgetAmountLocalMicro { get; set; }

        /// <summary>
        /// Gets or sets the objective.
        /// </summary>
        /// <value>
        /// The objective.
        /// </value>
        [JsonProperty("objective")]
        public string Objective { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the entity status.
        /// </summary>
        /// <value>
        /// The entity status.
        /// </value>
        [JsonProperty("entity_status")]
        public string EntityStatus { get; set; }

        /// <summary>
        /// Gets or sets the automatic tweet promotion.
        /// </summary>
        /// <value>
        /// The automatic tweet promotion.
        /// </value>
        [JsonProperty("automatic_tweet_promotion")]
        public object AutomaticTweetPromotion { get; set; }

        /// <summary>
        /// Gets or sets the optimization.
        /// </summary>
        /// <value>
        /// The optimization.
        /// </value>
        [JsonProperty("optimization")]
        public string Optimization { get; set; }

        /// <summary>
        /// Gets or sets the frequency cap.
        /// </summary>
        /// <value>
        /// The frequency cap.
        /// </value>
        [JsonProperty("frequency_cap")]
        public decimal? FrequencyCap { get; set; }

        /// <summary>
        /// Gets or sets the android application store identifier.
        /// </summary>
        /// <value>
        /// The android application store identifier.
        /// </value>
        [JsonProperty("android_app_store_identifier")]
        public string AndroidAppStoreIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the tracking tags.
        /// </summary>
        /// <value>
        /// The tracking tags.
        /// </value>
        [JsonProperty("tracking_tags")]
        public List<string> TrackingTags { get; set; }

        /// <summary>
        /// Gets or sets the ios application store identifier.
        /// </summary>
        /// <value>
        /// The ios application store identifier.
        /// </value>
        [JsonProperty("ios_app_store_identifier")]
        public string IosAppStoreIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the campaign identifier.
        /// </summary>
        /// <value>
        /// The campaign identifier.
        /// </value>
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        /// <summary>
        /// Gets or sets the creative source.
        /// </summary>
        /// <value>
        /// The creative source.
        /// </value>
        [JsonProperty("creative_source")]
        public string CreativeSource { get; set; }

        /// <summary>
        /// Gets or sets the deleted.
        /// </summary>
        /// <value>
        /// The deleted.
        /// </value>
        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}