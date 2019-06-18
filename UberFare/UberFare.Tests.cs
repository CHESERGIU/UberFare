using Xunit;

namespace UberFare
{
    public class UberFareTests
    {
        [Fact]
        public void DayTimeFareForShortDistances()
        {
            var price = new Price(1, 8, 1, 1);
            int result = 5;            
            var actual = price.CalculateUberFare();

            Assert.Equal(result, actual);
        }
        [Fact]
        public void DayTimeFareForMediumDistances()
        {
            var price = new Price(21, 8, 1, 1);
            int result = 168;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void DayTimeFareForLongDistances()
        {
            var price = new Price(100, 8, 1, 1);
            int result = 600;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void NightTimeFareForShortDistances()
        {
            var price = new Price(1, 21, 1, 1);
            int result = 7;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void NightTimeFareForMediumDistances()
        {
            var price = new Price(21, 21, 1, 1);
            int result = 210;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void NightTimeFareForLongDistances()
        {
            var price = new Price(100, 21, 1, 1);
            int result = 800;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void CheckNightTimeFareForLongDistances()
        {
            var price = new Price(100, 21, 1, 1);
            int result = 8;
            Assert.Equal(result, price.GetPricePerKm());
        }
        [Fact]
        public void SplitBillForNightTimeFareForLongDistances()
        {
            var price = new Price(100, 21, 4, 1);
            decimal result = 200;
            Assert.Equal(result, price.GetPricePerPerson());
        }
        [Fact]
        public void RewardPriceToFidelRiders_ForNightTimeFareForLongDistances()
        {
            var price = new Price(100, 21, 1, 15);
            decimal rewardPrice = (decimal)5.6;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = 560;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            var price = new Price(1, 8, 1, 15);
            decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = (decimal)4.2;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void SplitBill_RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            var price = new Price(10, 8, 2, 15);
            decimal splitBill = 21;
            Assert.Equal(splitBill, price.GetPricePerPerson());
            decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = (decimal)42;
            Assert.Equal(result, price.CalculateUberFare());
        }
    }
}
