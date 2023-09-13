namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using global::Mma.Common.models;
    using NUnit.Framework;

    [TestFixture]
    public class Display_average_surface_wind_direction_tests
    {

        [TestCase(null, "///")]
        [TestCase(10, "010")]
        [TestCase(15, "015")]
        [TestCase(350, "350")]
        public void Average_wind_direction_is_correct(double? direction, string expected)
        {
            //Arrange
            var data = new WindData
            {
                AverageWindDirection = direction,
            };
            //Act
            var result = DisplayAverageSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}