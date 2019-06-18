namespace UberFare
{
    public class Ride
    {
        private readonly int distanceInKm;
        private readonly int hour;
        private readonly Client[] passenger = new Client[] { };        
        private readonly decimal[] daytimePrices = { 5, 8, 6 };
        private readonly decimal[] nighttimePrices = { 7, 10, 8 };
        private readonly int Travels;              

        public Ride(int distanceInKm, int hour, params Client[] passenger)
        {
            this.distanceInKm = distanceInKm;
            this.hour = hour;            
            for (int i = 0; i < passenger.Length; i++)
                this.Travels = passenger[i].Travels;            
        }

        public decimal CalculateUberFare()
        {
            if (Travels > 10)
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

        public decimal GetPricePerPerson()
        {            
            return CalculateUberFare() / 2;
        }

        public decimal GetRewardPricePerKm()
        {
            if (Client.Fidelity10(Travels))
                    return GetPrices(hour)[2] * (decimal)0.7;
                else if (Client.Fidelity20(Travels))
                    return GetPrices(hour)[1] * (decimal)0.5;

            return GetPrices(hour)[0];
        }

        
    }
}
