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
            decimal pricePerKm = IsMediumDistance(distanceInKm) ? 8 : 5;
            return distanceInKm * pricePerKm;
        }

        private static bool IsMediumDistance(int distanceInKm)
        {
            return distanceInKm > 20;
        }
    }
}
