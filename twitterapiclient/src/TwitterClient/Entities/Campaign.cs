namespace TwitterClient.Entities
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A single campaign.
    /// </summary>
    public class Campaign
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

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
        [JsonProperty("reasons_not_servable")]
#pragma warning disable CA2227 // Collection properties should be read only
        public List<string> ReasonsNotServable { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Campaign"/> is servable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if servable; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("servable")]
        public bool? Servable { get; set; }

        /// <summary>
        /// Gets or sets the effective status.
        /// </summary>
        /// <value>
        /// The effective status.
        /// </value>
        [JsonProperty("effective_status")]
        public string EffectiveStatus { get; set; }

        /// <summary>
        /// Gets or sets the daily budget amount local micro.
        /// </summary>
        /// <value>
        /// The daily budget amount local micro.
        /// </value>
        [JsonProperty("daily_budget_amount_local_micro")]
        public long? DailyBudgetAmountLocalMicro { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the funding instrument identifier.
        /// </summary>
        /// <value>
        /// The funding instrument identifier.
        /// </value>
        [JsonProperty("funding_instrument_id")]
        public string FundingInstrumentId { get; set; }

        /// <summary>
        /// Gets or sets the duration indays.
        /// </summary>
        /// <value>
        /// The duration indays.
        /// </value>
        [JsonProperty("duration_in_days")]
        public int? DurationIndays { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [standard delivery].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [standard delivery]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("standard_delivery")]
        public bool? StandardDelivery { get; set; }

        /// <summary>
        /// Gets or sets the total budget amount local micro.
        /// </summary>
        /// <value>
        /// The total budget amount local micro.
        /// </value>
        [JsonProperty("total_budget_amount_local_micro")]
        public long? TotalBudgetAmountLocalMicro { get; set; }

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
        /// Gets or sets the frequency cap.
        /// </summary>
        /// <value>
        /// The frequency cap.
        /// </value>
        [JsonProperty("frequency_cap")]
        public decimal? FrequencyCap { get; set; }

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
    }
}