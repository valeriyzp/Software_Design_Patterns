namespace PP_Lab2.Patterns
{
    class AmericanMetric
    {
        public double FeetHeight { get; set; }
        public double PoundWeight { get; set; }

        public AmericanMetric(double feetHeight, double poundWeight)
        {
            FeetHeight = feetHeight;
            PoundWeight = poundWeight;
        }
    }

    interface IMetric
    {
        public double getHeight();
        public double getWeight();
    }

    class AmericanToUkrainianMetricAdapter : IMetric
    {
        private AmericanMetric _AmericanMetric { get; set; }

        public AmericanToUkrainianMetricAdapter(AmericanMetric americanMetric)
        {
            _AmericanMetric = americanMetric;
        }

        public double getHeight()
        {
            return _AmericanMetric.FeetHeight / 3.2808;
        }

        public double getWeight()
        {
            return _AmericanMetric.PoundWeight / 2.2046;
        }
    }
}
