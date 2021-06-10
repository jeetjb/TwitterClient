namespace TwitterClient.Enums
{
    /// <summary>
    /// Targeting criterias
    /// </summary>
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
    public enum TargetingType
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
    {
        /// <summary>
        /// The locations
        /// </summary>
        locations,

        /// <summary>
        /// The languages
        /// </summary>
        languages,

        /// <summary>
        /// The platforms
        /// </summary>
        platforms,

        /// <summary>
        /// The devices
        /// </summary>
        devices,

        /// <summary>
        /// The platform versions
        /// </summary>
#pragma warning disable CA1707 // Identifiers should not contain underscores
        platform_versions,

        /// <summary>
        /// The network operators
        /// </summary>
        network_operators,

        /// <summary>
        /// The interests
        /// </summary>
        interests,

        /// <summary>
        /// The tv markets
        /// </summary>
        tv_markets,

        /// <summary>
        /// The events
        /// </summary>
        events,

        /// <summary>
        /// The conversations
        /// </summary>
        conversations,

        /// <summary>
        /// The tv shows
        /// </summary>
        tv_shows
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
