namespace Carneiro.Host
{
    /// <summary>
    /// Generic Background Timeout Settings
    /// </summary>
    public class GenericBackgroundTimeoutSettings
    {
        /// <summary>
        /// Determines the minimum of the parameters.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        public int Min { get; set; } = 1;

        /// <summary>
        /// Determines the maximum of the parameters.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        public int Max { get; set; } = 5;

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Min: {Min} seconds Max: {Max} seconds";
    }
}