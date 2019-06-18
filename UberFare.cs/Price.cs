namespace UberFare
{
    public class Price
    {
        private readonly int distanceInKm;
        private readonly int hour;
        private readonly decimal[] daytimePrices = { 5, 8, 6 };
        private readonly decimal[] nighttimePrices = { 7, 10, 8 };
        private readonly int riders;
        private readonly int travels = 0;
        
        public Price(int distanceInKm, int hour, int riders, int travels)
        {
            this.distanceInKm = distanceInKm;
            this.hour = hour;
            this.riders = riders;
            this.travels = travels;
        }

        public decimal CalculateUberFare()
        {
            if(travels > 10)
                return distanceInKm * GetRewardPricePerKm();
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

        public decimal GetPricePerPerson() => CalculateUberFare() / riders;

        public decimal GetRewardPricePerKm()
        {            
            if (Fidelity10(travels))
                return GetPrices(hour)[2]*(decimal)0.7;
            else if (Fidelity20(travels))
                return GetPrices(hour)[1] * (decimal)0.5;
            return GetPrices(hour)[0];
        }

        private bool Fidelity20(int Travels) => Travels >= 20 ? true : false;

        private bool Fidelity10(int Travels) => Travels >= 10 && Travels < 20 ? true : false;
    }
}
