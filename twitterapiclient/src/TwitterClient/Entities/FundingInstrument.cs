namespace TwitterClient.Entities
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A single campaign.
    /// </summary>
    public class FundingInstrument
    {
        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Gets or sets the reasons not servable.
        /// </summary>
        /// <value>
        /// The reasons not servable.
        /// </value>
        [JsonProperty("reasons_not_able_to_fund")]
#pragma warning disable CA2227 // Collection properties should be read only
        public List<string> ReasonsNotAbleToFund { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Gets or sets the daily budget amount local micro.
        /// </summary>
        /// <value>
        /// The daily budget amount local micro.
        /// </value>
        [JsonProperty("funded_amount_local_micro")]
        public long? FundedAmountLocalMicro { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the credit_limit_local_micro.
        /// </summary>
        /// <value>
        /// The credit_limit_local_micro.
        /// </value>
        [JsonProperty("credit_limit_local_micro")]
        public long? CreditLimitLocalMicro { get; set; }

        /// <summary>
        /// Gets or sets the credit_limit_local_micro.
        /// </summary>
        /// <value>
        /// The credit_limit_local_micro.
        /// </value>
        [JsonProperty("credit_remaining_local_micro")]
        public long? CreditRemainingLocalMicro { get; set; }

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
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Campaign"/> is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if deleted; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [able to fund].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [able to fund]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("able_to_fund")]
        public bool? AbleToFund { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the account identifier.
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the io header.
        /// </summary>
        /// <value>
        /// The io header.
        /// </value>
        [JsonProperty("io_header")]
        public object IoHeader { get; set; }
    }
}
