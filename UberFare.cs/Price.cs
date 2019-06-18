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

        public decimal CalculateUberFare(Price price) => distanceInKm * GetPricePerKm(price);

        public decimal GetPricePerKm(Price price)
        {
            if (IsLongDistance(distanceInKm))
                return GetPrices(hour)[2];
            else if (IsMediumDistance(distanceInKm))
                return GetPrices(hour)[1];
            return GetPrices(hour)[0];
        }

        private decimal[] GetPrices(int hour) => IsDayTime(hour) ? daytimePrices : nighttimePrices;

        private bool IsDayTime(int hour) => 8 <= hour && hour < 21;        

        private bool IsLongDistance(int distanceInKm) => distanceInKm > 60;

        private bool IsMediumDistance(int distanceInKm) => distanceInKm > 20;
    }
}
