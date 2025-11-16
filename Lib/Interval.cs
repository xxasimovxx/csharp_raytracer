namespace Rays
{
    public struct Interval
    {
        public double Min { get; private set; }
        public double Max { get; private set; }
        public double Size { get; private set; }

        public Interval()
        {
            Min = Double.NegativeInfinity;
            Max = Double.PositiveInfinity;
            Size = Max - Min;
        }

        public Interval(double min, double max)
        {
            Min = min;
            Max = max;
            Size = Max - Min;
        }

        public bool Contains(double x)
        {
            return Min <= x && x <= Max;
        }

        public bool Surrounds(double x)
        {
            return Min < x && x < Max;
        }
    }
}
