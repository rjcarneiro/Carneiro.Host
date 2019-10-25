namespace Carneiro.Host
{
    /// <summary>
    /// Generic Background Settings
    /// </summary>
    public class GenericBackgroundSettings
    {
        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        /// <value>
        /// The timeout.
        /// </value>
        public GenericBackgroundTimeoutSettings Timeout { get; set; } = new GenericBackgroundTimeoutSettings();

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => Timeout.ToString();
    }
}