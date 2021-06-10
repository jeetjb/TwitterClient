namespace TwitterClient.Enums
{
    /// <summary>
    /// Objective
    /// </summary>
#pragma warning disable CA1008 // Enums should have zero value
    public enum Objective
#pragma warning restore CA1008 // Enums should have zero value
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores
        /// <summary>
        /// The reach
        /// </summary>
        REACH = 1,

        /// <summary>
        /// The video views
        /// </summary>
        VIDEO_VIEWS = 2,

        /// <summary>
        /// The preroll views
        /// </summary>
        PREROLL_VIEWS = 3,

        /// <summary>
        /// The application installs
        /// </summary>
        APP_INSTALLS = 4,

        /// <summary>
        /// The website clicks
        /// </summary>
        WEBSITE_CLICKS = 5,

        /// <summary>
        /// The engagements
        /// </summary>
        ENGAGEMENTS = 6,

        /// <summary>
        /// The followers
        /// </summary>
        FOLLOWERS = 7,

        /// <summary>
        /// The application engagements
        /// </summary>
        APP_ENGAGEMENTS = 8
#pragma warning restore CA1707 // Identifiers should not contain underscores
}
}
