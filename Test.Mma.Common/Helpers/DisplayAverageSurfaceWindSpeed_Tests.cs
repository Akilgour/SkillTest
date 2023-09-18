

namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using global::Mma.Common.models;
    using NUnit.Framework;

    [TestFixture]
    internal class Display_average_surface_wind_speed_tests
    {
        [TestCase(null, "//")]
        [TestCase(10, "10")]
        [TestCase(15.1, "15")]
        [TestCase(15.9, "16")]
        [TestCase(3, "03")]
        public void Average_wind_speed_is_correct(double? speed, string expected)
        {
            //Arrange
            var data = new WindData
            {
                AverageWindSpeed = speed,
               
            };
            //Act
            var result = DisplayAverageSurfaceWindSpeed.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase(100)]
        [TestCase(101)]
        [TestCase(500)]
        public void Average_wind_speed_is_is_100_knots_or_more_the_wind_speed_should_be_encoded_as_P99(double? averageWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
                AverageWindSpeed = averageWindSpeed,
            };
            //Act
            var result = DisplayAverageSurfaceWindSpeed.Resolve(data);
            //Assert
            Assert.That("P99", Is.EqualTo(result));
        }
    }
}
