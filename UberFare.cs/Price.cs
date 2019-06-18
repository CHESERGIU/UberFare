using System;
using System.Collections.Generic;
using System.Text;

namespace UberFare
{
    public class Price
    {
        private readonly int distanceInKm;
        private readonly int hour;        

        public static decimal CalculateUberFare(int distanceInKm, int hour)
        {
            return distanceInKm * GetPricePerKm(distanceInKm, GetPrices(hour));
        }

        private static decimal[] GetPrices(int hour)
        {
            decimal[] daytimePrices = { 5, 8, 6 };
            decimal[] nighttimePrices = { 7, 10, 8 };        
            return IsDayTime(hour) ? daytimePrices : nighttimePrices;
        }

        private static bool IsDayTime(int hour) => 8 <= hour && hour < 21;

        private static decimal GetPricePerKm(int distanceInKm, decimal[] prices)
        {
            if (IsLongDistance(distanceInKm))
                return prices[2];
            else if (IsMediumDistance(distanceInKm))
                return prices[1];
            return prices[0];
        }

        private static bool IsLongDistance(int distanceInKm) => distanceInKm > 60;

        private static bool IsMediumDistance(int distanceInKm) => distanceInKm > 20;
    }
}
