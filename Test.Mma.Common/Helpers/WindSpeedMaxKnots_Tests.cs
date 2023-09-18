namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using NUnit.Framework;

    internal class WindSpeedMaxKnots_Tests
    {
        [Theory]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(99)]
        public void value_is_less_than_100_knots_return_false(double? speedInKnots)
        {
            //Arrange
            //Act
            var result = WindSpeedMaxKnots.Resolve(speedInKnots);
            //Assert
            Assert.False(result);
        }

        [Theory]
        [TestCase(100)]
        [TestCase(101)]
        [TestCase(500)]
        public void value_is_100_knots_or_more_return_true(double? speedInKnots)
        {
            //Arrange
            //Act
            var result = WindSpeedMaxKnots.Resolve(speedInKnots);
            //Assert
            Assert.True(result);
        }
    }
}