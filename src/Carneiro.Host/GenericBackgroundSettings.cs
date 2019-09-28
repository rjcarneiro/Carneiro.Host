namespace Carneiro.Host
{
    public class GenericBackgroundSettings
    {
        public GenericBackgroundTimeoutSettings Timeout { get; set; } = new GenericBackgroundTimeoutSettings();

        public override string ToString() => Timeout.ToString();
    }
}