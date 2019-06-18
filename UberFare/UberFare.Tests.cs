using Xunit;

namespace UberFare
{
    public class UberFareTests
    {
        [Fact]
        public void DayTimeFareForShortDistances()
        {
            Clients passenger = new Clients("Ion", 1, 1);
            var price = new Price(1, 8, passenger);
            int result = 5;            
            var actual = price.CalculateUberFare();

            Assert.Equal(result, actual);
        }
        [Fact]
        public void DayTimeFareForMediumDistances()
        {
            Clients passenger = new Clients("Ion", 1, 1);
            var price = new Price(21, 8, passenger);
            int result = 168;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void DayTimeFareForLongDistances()
        {
            Clients passenger = new Clients("Ion", 1, 1);
            var price = new Price(100, 8, passenger);
            int result = 600;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void NightTimeFareForShortDistances()
        {
            Clients passenger = new Clients("Ion", 1, 1);
            var price = new Price(1, 21, passenger);
            int result = 7;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void NightTimeFareForMediumDistances()
        {
            Clients passenger = new Clients("Ion", 1, 1);
            var price = new Price(21, 21, passenger);
            int result = 210;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void NightTimeFareForLongDistances()
        {
            Clients passenger = new Clients("Ion", 1, 1);
            var price = new Price(100, 21, passenger);
            int result = 800;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void CheckNightTimeFareForLongDistances()
        {
            Clients passenger = new Clients("Ion", 1, 1);
            var price = new Price(100, 21, passenger);
            int result = 8;
            Assert.Equal(result, price.GetPricePerKm());
        }
        [Fact]
        public void SplitBillForNightTimeFareForLongDistances()
        {
            Clients passenger = new Clients("Ion", 4, 1);
            var price = new Price(100, 21, passenger);
            decimal result = 200;
            Assert.Equal(result, price.GetPricePerPerson());
        }
        [Fact]
        public void RewardPriceToFidelRiders_ForNightTimeFareForLongDistances()
        {
            Clients passenger = new Clients("Ion", 2, 15);
            var price = new Price(100, 21, passenger);
            decimal rewardPrice = (decimal)5.6;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = 560;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            Clients passenger = new Clients("Ion", 1, 15);
            var price = new Price(1, 8, passenger);
            decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = (decimal)4.2;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void SplitBill_RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            Clients passenger = new Clients("Ion", 2, 15);
            var price = new Price(10, 8, passenger);
            decimal splitBill = 21;
            Assert.Equal(splitBill, price.GetPricePerPerson());
            decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = (decimal)42;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void Chage_SplitBill_RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            var passenger = new Clients("Ion", 2, 15);
            var price = new Price(10, 8, passenger);
            decimal splitBill = 21;
            Assert.Equal(splitBill, price.GetPricePerPerson());
            decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = (decimal)42;
            Assert.Equal(result, price.CalculateUberFare());
        }
    }
}
