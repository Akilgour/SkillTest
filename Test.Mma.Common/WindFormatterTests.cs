namespace Test.Mma.Common
{
    using global::Mma.Common;
    using global::Mma.Common.models;
    using NUnit.Framework;

    [TestFixture]
    public class Wind_formatter_tests
    {
        private IWindFormatter formatter;

        [SetUp]
        public void SetUp()
        {
            formatter = new WindFormatter();
        }

        [TestCase(null, "///25KT")] // AK This test was ///25KY when I got here but that does not match spec?
        [TestCase(10, "01025KT")]
        [TestCase(15, "01025KT")]
        [TestCase(350, "35025KT")]
        public void Average_wind_direction_is_correct(double? direction, string expected)
        {
            //Arrange
            var data = new WindData
            {
                AverageWindDirection = direction,
                AverageWindSpeed = 25,
                MaximumWindSpeed = 28,
                MinimumWindDirection = direction,
                MaximumWindDirection = direction
            };
            //Act
            var result = formatter.FormatWind(data);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase(0)]
        [TestCase(0.1)]
        [TestCase(0.9)]
        public void It_is_calm_wind_speed_less_than_one_knot(double? averageWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
                AverageWindSpeed = averageWindSpeed,
            };
            //Act
            var result = formatter.FormatWind(data);
            //Assert
            Assert.That(result, Is.EqualTo("00000KT"));
        }
 
        //I would put more tests here and test some more real world examples
    }
}