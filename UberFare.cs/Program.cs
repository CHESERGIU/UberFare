﻿using System;

namespace UberFare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int distanceInKm = 0;
            int hour = 0;
            Console.WriteLine(CalculateUberFare(distanceInKm, hour));
            Console.ReadLine();
        }

        public static decimal CalculateUberFare(int distanceInKm, int hour)
        {
            decimal pricePerKm = GetPricePerKm(distanceInKm, GetPrices(hour));
            return distanceInKm * pricePerKm;
        }

        private static decimal[] GetPrices(int hour)
        {
            decimal[] daytimePrices = { 5, 8, 6 };
            decimal[] nighttimePrices = { 7, 10, 8 };
            decimal[] prices = IsDayTime(hour) ? daytimePrices : nighttimePrices;
            return prices;
        }

        private static bool IsDayTime(int hour)
        {
            return 8 <= hour && hour < 21;
        }

        private static decimal GetPricePerKm(int distanceInKm, decimal[] prices)
        {
            if (IsLongDistance(distanceInKm))
                return prices[2];
            else if (IsMediumDistance(distanceInKm))
                return prices[1];
            return prices[0];
        }

        private static bool IsLongDistance(int distanceInKm)
        {
            return distanceInKm > 60;
        }

        private static bool IsMediumDistance(int distanceInKm)
        {
            return distanceInKm > 20;
        }
    }
}
