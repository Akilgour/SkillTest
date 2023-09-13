

namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using global::Mma.Common.models;
    using NUnit.Framework;

    [TestFixture]
    internal class Display_Average_Surface_WindSpeed_Test
    {
        [TestCase(null, "//")]
        [TestCase(10, "10")]
        [TestCase(15, "15")]
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
    }
}
