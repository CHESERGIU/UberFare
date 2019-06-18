namespace UberFare
{
    public class Price
    {
        private readonly int distanceInKm;
        private readonly int hour;
        private decimal[] daytimePrices = { 5, 8, 6 };
        private decimal[] nighttimePrices = { 7, 10, 8 };

        public Price(int distanceInKm, int hour)
        {
            this.distanceInKm = distanceInKm;
            this.hour = hour;
        }

        public decimal CalculateUberFare(Price price)
        {
            return distanceInKm * GetPricePerKm(distanceInKm, GetPrices(hour));
        }

        private decimal[] GetPrices(int hour)
        {
                    
            return IsDayTime(hour) ? daytimePrices : nighttimePrices;
        }

        private bool IsDayTime(int hour) => 8 <= hour && hour < 21;

        private decimal GetPricePerKm(int distanceInKm, decimal[] prices)
        {
            if (IsLongDistance(distanceInKm))
                return prices[2];
            else if (IsMediumDistance(distanceInKm))
                return prices[1];
            return prices[0];
        }

        private bool IsLongDistance(int distanceInKm) => distanceInKm > 60;

        private bool IsMediumDistance(int distanceInKm) => distanceInKm > 20;
    }
}
