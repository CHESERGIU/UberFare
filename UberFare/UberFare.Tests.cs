using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace UberFare
{
    public class UberFareTests
    {
        [Fact]
        public void DayTimeFareForShortDistances()
        {
            int distanceInKm = 1;
            int hour = 8;
            int result = 5;
            Assert.Equal(result, Program.CalculateUberFare(distanceInKm, hour));
        }
        [Fact]
        public void DayTimeFareForMediumDistances()
        {
            int distanceInKm = 21;
            int hour = 8;
            int result = 168;
            Assert.Equal(result, Program.CalculateUberFare(distanceInKm, hour));
        }
        [Fact]
        public void DayTimeFareForLongDistances()
        {
            int distanceInKm = 100;
            int hour = 8;
            int result = 600;
            Assert.Equal(result, Program.CalculateUberFare(distanceInKm, hour));
        }
        [Fact]
        public void NightTimeFareForShortDistances()
        {
            int distanceInKm = 1;
            int hour = 21;
            int result = 7;
            Assert.Equal(result, Program.CalculateUberFare(distanceInKm, hour));
        }
        [Fact]
        public void NightTimeFareForMediumDistances()
        {
            int distanceInKm = 21;
            int hour = 21;
            int result = 210;
            Assert.Equal(result, Program.CalculateUberFare(distanceInKm, hour));
        }
        [Fact]
        public void NightTimeFareForLongDistances()
        {
            int distanceInKm = 100;
            int hour = 21;
            int result = 800;
            Assert.Equal(result, Program.CalculateUberFare(distanceInKm, hour));
        }
    }
}
