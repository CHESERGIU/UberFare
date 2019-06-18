namespace TaxiFare
{
    public class Ride
    {
        private readonly int distanceInKm;
        private readonly int hour;
        private readonly decimal[] daytimePrices = { 5, 8, 6 };
        private readonly decimal[] nighttimePrices = { 7, 10, 8 };
        private readonly int Travels;              

        public Ride(int distanceInKm, int hour, params Client[] passenger)
        {
            this.distanceInKm = distanceInKm;
            this.hour = hour;
            foreach (var client in passenger)
                Travels = client.Travels;
        }

        public decimal CalculateFare()
        {
            if (Travels > 10)
            {
                return distanceInKm * GetRewardPricePerKm();
            }

            return distanceInKm * GetPricePerKm();
        }

        public decimal GetPricePerKm()
        {
            return IsLongDistance(distanceInKm) ? GetPrices(hour)[2] :
                IsMediumDistance(distanceInKm) ? GetPrices(hour)[1] : GetPrices(hour)[0];
        }

        public decimal GetPricePerPerson()
        {            
            return CalculateFare() / 2;
        }

        public decimal GetRewardPricePerKm()
        {
            if (Client.Fidelity10(Travels))
                    return GetPrices(hour)[2] * (decimal)0.7;
            if (Client.Fidelity20(Travels))
                return GetPrices(hour)[1] * (decimal)0.5;

            return GetPrices(hour)[0];
        }

        decimal[] GetPrices(int h)
        {
            return IsDayTime(h) ? daytimePrices : nighttimePrices;
        }

        bool IsDayTime(int h) => 8 <= h && h < 21;

        bool IsLongDistance(int Km) => Km > 60;

        bool IsMediumDistance(int Km) => Km > 20;
    }
}
