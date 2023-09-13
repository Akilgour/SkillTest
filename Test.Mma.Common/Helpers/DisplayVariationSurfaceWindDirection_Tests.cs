namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using global::Mma.Common.models;
    using NUnit.Framework;

    internal class Display_variation_surface_wind_direction_tests
    {
        [TestCase(null, null, "///V///")]
        [TestCase(200, null, "200V///")]
        [TestCase(null, 300, "///V300")]
        [TestCase(10, 20, "010V020")]
        [TestCase(15, 1, "015V001")]
        [TestCase(2, 25, "002V025")]
        [TestCase(100, 350, "100V350")]
        public void Wind_variation_is_correct(double? minimumWindDirection, double? maximumWindDirection, string expected)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
            };
            //Act
            var result = DisplayVariationSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}