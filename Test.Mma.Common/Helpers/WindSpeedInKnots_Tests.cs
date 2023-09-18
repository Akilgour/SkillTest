namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using NUnit.Framework;

    public class WindSpeedInKnots_Tests
    {
        [Theory]
        [TestCase(1, 1)]
        [TestCase(1.1, 1)]
        [TestCase(1.5, 2)]
        [TestCase(1.9, 2)]
        [TestCase(50, 50)]
        [TestCase(50.4, 50)]
        [TestCase(99, 99)]
        public void value_is_rounded_to_there_nearest_knot(double? speedInKnots, double expected)
        {
            //Arrange
            //Act
            var result = WindSpeedInKnots.Resolve(speedInKnots);
            //Assert
            Assert.That(expected, Is.EqualTo(result));
        }
    }
}