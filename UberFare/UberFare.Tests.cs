using TaxiFare;
using Xunit;

namespace TaxiFareTests
{
    public class TaxiFareTests
    {
        [Fact]
        public void DayTimeFareForShortDistances()
        {
            var passenger = new Client("Ion", 1);
            var price = new Ride(1, 8, passenger);
            const int result = 5;
            var actual = price.CalculateFare();

            Assert.Equal(result, actual);
        }
        [Fact]
        public void DayTimeFareForMediumDistances()
        {
            var passenger = new Client("Ion", 1);
            var price = new Ride(21, 8, passenger);
            const int result = 168;
            Assert.Equal(result, price.CalculateFare());
        }
        [Fact]
        public void DayTimeFareForLongDistances()
        {
            var passenger = new Client("Ion", 1);
            var price = new Ride(100, 8, passenger);
            const int result = 600;
            Assert.Equal(result, price.CalculateFare());
        }
        [Fact]
        public void NightTimeFareForShortDistances()
        {
            var passenger = new Client("Ion", 1);
            var price = new Ride(1, 21, passenger);
            const int result = 7;
            Assert.Equal(result, price.CalculateFare());
        }
        [Fact]
        public void NightTimeFareForMediumDistances()
        {
            var passenger = new Client("Ion", 1);
            var price = new Ride(21, 21, passenger);
            const int result = 210;
            Assert.Equal(result, price.CalculateFare());
        }
        [Fact]
        public void NightTimeFareForLongDistances()
        {
            var passenger = new Client("Ion", 1);
            var price = new Ride(100, 21, passenger);
            const int result = 800;
            Assert.Equal(result, price.CalculateFare());
        }
        [Fact]
        public void CheckNightTimeFareForLongDistances()
        {
            var passenger = new Client("Ion", 1);
            var price = new Ride(100, 21, passenger);
            const int result = 8;
            Assert.Equal(result, price.GetPricePerKm());
        }
        [Fact]
        public void SplitBillForNightTimeFareForLongDistances()
        {
            var passenger = new Client("Ion", 2);
            var price = new Ride(100, 21, passenger);
            const decimal result = 400;
            Assert.Equal(result, price.GetPricePerPerson());
        }
        [Fact]
        public void RewardPriceToFidelRiders_ForNightTimeFareForLongDistances()
        {
            var passenger = new Client("Ion", 15);
            var price = new Ride(100, 21, passenger);
            const decimal rewardPrice = (decimal)5.6;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            const decimal result = 560;
            Assert.Equal(result, price.CalculateFare());
        }
        [Fact]
        public void RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            var passenger = new Client("Ion", 15);
            var price = new Ride(1, 8, passenger);
            const decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            const decimal result = (decimal)4.2;
            Assert.Equal(result, price.CalculateFare());
        }
        [Fact]
        public void SplitBill_RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            var Ion = new Client("Ion", 15);
            var Maria = new Client("Maria", 12);
            var passenger = new[] { Ion, Maria };

            var price = new Ride(10, 8, passenger);
            const decimal pricePerKm = 5;
            Assert.Equal(pricePerKm, price.GetPricePerKm());
            const decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            const decimal result = 42;
            Assert.Equal(result, price.CalculateFare());

        }
        [Fact]
        public void Change_SplitBill_RewardPriceToFidelRiders_ForDayTimeFareForShortDistances()
        {
            var Ion = new Client("Ion", 15);
            var Maria = new Client("Maria", 12);
            var passenger = new[] { Ion, Maria };

            var price = new Ride(10, 8, passenger);
            const decimal splitBill = 21;
            Assert.Equal(splitBill, price.GetPricePerPerson());
            const decimal rewardPrice = (decimal)4.2;
            Assert.Equal(rewardPrice, price.GetRewardPricePerKm());
            const decimal result = 42;
            Assert.Equal(result, price.CalculateFare());
        }
    }
}
