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
            Assert.Equal(5, Program.CalculateUberFare(distanceInKm, hour));
        }
    }
}
