namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using global::Mma.Common.models;
    using NUnit.Framework;

    public class Display_max_surface_wind_speed_Tests
    {
        [TestCase(null, "//")]
        [TestCase(10, "10")]
        [TestCase(15, "15")]
        [TestCase(3, "03")]
        public void Max_wind_speed_is_correct(double? speed, string expected)
        {
            //Arrange
            var data = new WindData
            {
                MaximumWindSpeed = speed,
            };
            //Act
            var result = DisplayMaxSurfaceWindSpeed.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}