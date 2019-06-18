using Xunit;

namespace UberFare
{
    public class UberFareTests
    {
        [Fact]
        public void DayTimeFareForShortDistances()
        {
            var price = new Price(1, 8);
            int result = 5;            
            var actual = price.CalculateUberFare(price);

            Assert.Equal(result, actual);
        }
        [Fact]
        public void DayTimeFareForMediumDistances()
        {
            var price = new Price(21, 8);
            int result = 168;
            Assert.Equal(result, price.CalculateUberFare(price));
        }
        [Fact]
        public void DayTimeFareForLongDistances()
        {
            var price = new Price(100, 8);
            int result = 600;
            Assert.Equal(result, price.CalculateUberFare(price));
        }
        [Fact]
        public void NightTimeFareForShortDistances()
        {
            var price = new Price(1, 21);
            int result = 7;
            Assert.Equal(result, price.CalculateUberFare(price));
        }
        [Fact]
        public void NightTimeFareForMediumDistances()
        {
            var price = new Price(21, 21);
            int result = 210;
            Assert.Equal(result, price.CalculateUberFare(price));
        }
        [Fact]
        public void NightTimeFareForLongDistances()
        {
            var price = new Price(100, 21);
            int result = 800;
            Assert.Equal(result, price.CalculateUberFare(price));
        }
    }
}
