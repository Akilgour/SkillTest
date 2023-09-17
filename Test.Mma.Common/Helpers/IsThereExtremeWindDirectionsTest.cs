namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using global::Mma.Common.models;
    using NUnit.Framework;

    internal class IsThereExtremeWindDirectionsTest
    {
        [Theory]
        [TestCase(10, 190)]
        [TestCase(10, 200)]
        [TestCase(20, 220)]
        public void Extreme_wind_as_varation_is_180_degrees_or_more(double? minimumWindDirection, double? maximumWindDirection)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
            };
            //Act
            var result = IsThereExtremeWindDirections.Resolve(data);
            //Assert
            Assert.True(result);
        }

        [Theory]
        [TestCase(10, 71)]
        [TestCase(10, 80)]
        [TestCase(10, 189)]
        public void Not_extreme_wind_as_varation_is_less_than_180_degrees_and_average_wind_direction_known(double? minimumWindDirection, double? maximumWindDirection)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
                AverageWindDirection = 1,
            };
            //Act
            var result = IsThereExtremeWindDirections.Resolve(data);
            //Assert
            Assert.False(result);
        }

        [Test]
        public void Extreme_wind_as_average_direction_not_Know()
        {
            //Arrange
            var data = new WindData
            {
                AverageWindDirection = null,
            };
            //Act
            var result = IsThereExtremeWindDirections.Resolve(data);
            //Assert
            Assert.True(result);
        }

    }
}
