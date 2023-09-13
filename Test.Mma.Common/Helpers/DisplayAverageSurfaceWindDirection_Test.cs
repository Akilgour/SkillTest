namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using global::Mma.Common.models;
    using NUnit.Framework;

    [TestFixture]
    public class Display_Average_Surface_Wind_Direction_Test
    {

        [TestCase(null, "///")]
        [TestCase(10, "010")]
        [TestCase(15, "015")]
        [TestCase(350, "350")]
        public void Average_wind_direction_is_correct(double? direction, string expected)
        {
            var data = new WindData
            {
                AverageWindDirection = direction,
            };

            var result = DisplayAverageSurfaceWindDirection.Resolve(data);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}