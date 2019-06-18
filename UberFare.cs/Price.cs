namespace UberFare
{
    public class Price
    {
        private readonly int distanceInKm;
        private readonly int hour;
        private readonly Clients passenger;
        private readonly decimal[] daytimePrices = { 5, 8, 6 };
        private readonly decimal[] nighttimePrices = { 7, 10, 8 };   

        public Price(int distanceInKm, int hour, Clients passenger)
        {
            this.distanceInKm = distanceInKm;
            this.hour = hour;
            this.passenger = passenger;
        }

        public decimal CalculateUberFare()
        {
            if(passenger.Travels > 10)
            {
                return distanceInKm * GetRewardPricePerKm();
            }

            return distanceInKm * GetPricePerKm();
        }

        public decimal GetPricePerKm()
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

        public decimal GetPricePerPerson() => CalculateUberFare() / passenger.Riders;

        public decimal GetRewardPricePerKm()
        {            
            if (Clients.Fidelity10(passenger.Travels))
                return GetPrices(hour)[2]*(decimal)0.7;
            else if (Clients.Fidelity20(passenger.Travels))
                return GetPrices(hour)[1] * (decimal)0.5;
            return GetPrices(hour)[0];
        }

        
    }
}
