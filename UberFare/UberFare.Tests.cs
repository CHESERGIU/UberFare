using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace UberFare
{
    public class UberFareTests
    {
        [Fact]
        public void DayTimeFareForShortDistances()
        {
            int distanceInKm = 0;
            int hour = 0;
            Assert.Equal(5, Program.CalculateUberFare(distanceInKm, hour));
        }
    }
}
