namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using global::Mma.Common.models;
    using NUnit.Framework;

    public class Display_max_surface_wind_speed_Tests
    {
        [TestCase(null, "")]
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

        [TestCase(10)]
        [TestCase(15)]
        [TestCase(3)]
        [TestCase(20)]
        [TestCase(30)]
        public void Max_wind_speed_is_not_show_as_same_as_average(double? maximumWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
                AverageWindSpeed = maximumWindSpeed,
                MaximumWindSpeed = maximumWindSpeed,
            };
            //Act
            var result = DisplayMaxSurfaceWindSpeed.Resolve(data);
            //Assert
            Assert.IsEmpty(result);

        }

        [TestCase(1, 15, "15")]
        [TestCase(2, 15, "15")]
        [TestCase(5, 15, "15")]
        [TestCase(9, 20, "20")]
        [TestCase(10, 20, "20")]
        [TestCase(6, 30, "30")]
        [TestCase(10, 30, "30")]
        [TestCase(20, 30, "30")]
        public void Max_wind_speed_is_show_as_it_execeeds_the_average_by_10_knots_or_more(double averageWindSpeed, double? maximumWindSpeed, string expected)
        {
            //Arrange
            var data = new WindData
            {
                AverageWindSpeed = averageWindSpeed,
                MaximumWindSpeed = maximumWindSpeed,
            };
            //Act
            var result = DisplayMaxSurfaceWindSpeed.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(6, 15)]
        [TestCase(14, 15)]
        [TestCase(11, 20)]
        [TestCase(15, 20)]
        [TestCase(21, 30)]
        [TestCase(25, 30)]
        public void Max_wind_speed_not_show_as_it__does_not_execeed_the_average_by_10_knots_or_more(double averageWindSpeed, double? maximumWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
                AverageWindSpeed = averageWindSpeed,
                MaximumWindSpeed = maximumWindSpeed,
            };
            //Act
            var result = DisplayMaxSurfaceWindSpeed.Resolve(data);
            //Assert
            Assert.IsEmpty(result);
        }
    }
}