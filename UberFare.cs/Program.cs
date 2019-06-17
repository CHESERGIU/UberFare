using System;

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
            decimal pricePerKm = 5;
            if (IsLongDistance(distanceInKm))
                pricePerKm = 6;
            else if (IsMediumDistance(distanceInKm))
                pricePerKm = 8;
            return distanceInKm * pricePerKm;
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
