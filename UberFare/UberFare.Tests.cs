using Xunit;

namespace UberFare
{
    public class UberFareTests
    {
        [Fact]
        public void DayTimeFareForShortDistances()
        {
            Client passenger = new Client("Ion", 1);
            var price = new Ride(1, 8, passenger);
            int result = 5;
            var actual = price.CalculateUberFare();

            Assert.Equal(result, actual);
        }
        [Fact]
        public void DayTimeFareForMediumDistances()
        {
            Client passenger = new Client("Ion", 1);
            var price = new Ride(21, 8, passenger);
            int result = 168;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void DayTimeFareForLongDistances()
        {
            Client passenger = new Client("Ion", 1);
            var price = new Ride(100, 8, passenger);
            int result = 600;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void NightTimeFareForShortDistances()
        {
            Client passenger = new Client("Ion", 1);
            var price = new Ride(1, 21, passenger);
            int result = 7;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void NightTimeFareForMediumDistances()
        {
            Client passenger = new Client("Ion", 1);
            var price = new Ride(21, 21, passenger);
            int result = 210;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void NightTimeFareForLongDistances()
        {
            Client passenger = new Client("Ion", 1);
            var price = new Ride(100, 21, passenger);
            int result = 800;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void CheckNightTimeFareForLongDistances()
        {
            Client passenger = new Client("Ion", 1);
            var price = new Ride(100, 21, passenger);
            int result = 8;
            Assert.Equal(result, price.GetPricePerKm());
        }
        [Fact]
        public void SplitBillForNightTimeFareForLongDistances()
        {
            Client passenger = new Client("Ion", 2);
            var price = new Ride(100, 21, passenger);
            decimal result = 400;
            Assert.Equal(result, price.GetPricePerPerson());
        }
        [Fact]
        public void RewardPriceToFidelRiders_ForNightTimeFareForLongDistances()
        {
            Client passenger = new Client("Ion", 15);
            var price = new Ride(100, 21, passenger);
            decimal rewardPrice = (decimal)5.6;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = 560;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            Client passenger = new Client("Ion", 15);
            var price = new Ride(1, 8, passenger);
            decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = (decimal)4.2;
            Assert.Equal(result, price.CalculateUberFare());
        }
        [Fact]
        public void SplitBill_RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            Client Ion = new Client("Ion", 15);
            Client Maria = new Client("Maria", 12);
            Client[] passenger = new Client[] { Ion, Maria };

            Ride price = new Ride(10, 8, passenger);
            decimal pricePerKm = 5;
            Assert.Equal(pricePerKm, price.GetPricePerKm());
            decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = (decimal)42;
            Assert.Equal(result, price.CalculateUberFare());

        }
        [Fact]
        public void Chage_SplitBill_RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            Client Ion = new Client("Ion", 15);
            Client Maria = new Client("Maria", 12);
            Client[] passenger = new Client[] { Ion, Maria };

            var price = new Ride(10, 8, passenger);
            decimal splitBill = 21;
            Assert.Equal(splitBill, price.GetPricePerPerson());
            decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            decimal result = (decimal)42;
            Assert.Equal(result, price.CalculateUberFare());
        }
    }
}
