namespace Carneiro.Host
{
    public class GenericBackgroundTimeoutSettings
    {
        public int Min { get; set; } = 1;
        public int Max { get; set; } = 5;

        public override string ToString() => $"Min: {Min} seconds Max: {Max} seconds";
    }
}