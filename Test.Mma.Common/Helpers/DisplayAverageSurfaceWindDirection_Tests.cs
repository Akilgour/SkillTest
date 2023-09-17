namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using global::Mma.Common.models;
    using NUnit.Framework;

    [TestFixture]
    public class Display_average_surface_wind_direction_tests
    {
        [Theory]
        [TestCase(10, 20, 15, 0, "015")]
        [TestCase(10, 20, 15, 1, "015")]
        [TestCase(10, 20, 15, 2, "015")]
        [TestCase(10, 20, 15, 3, "015")]
        [TestCase(10, 30, 20, 0, "020")]
        [TestCase(10, 30, 20, 1, "020")]
        [TestCase(10, 30, 20, 2, "020")]
        [TestCase(10, 30, 20, 3, "020")]
        [TestCase(10, 40, 25, 0, "025")]
        [TestCase(10, 40, 25, 1, "025")]
        [TestCase(10, 40, 25, 2, "025")]
        [TestCase(10, 40, 25, 3, "025")]
        [TestCase(10, 50, 30, 0, "030")]
        [TestCase(10, 50, 30, 1, "030")]
        [TestCase(10, 50, 30, 2, "030")]
        [TestCase(10, 50, 30, 3, "030")]
        [TestCase(10, 60, 35, 0, "035")]
        [TestCase(10, 60, 35, 1, "035")]
        [TestCase(10, 60, 35, 2, "035")]
        [TestCase(10, 60, 35, 3, "035")]
        [TestCase(10, 70, 40, 0, "040")]
        [TestCase(10, 70, 40, 1, "040")]
        [TestCase(10, 70, 40, 2, "040")]
        [TestCase(10, 70, 40, 3, "040")]
        [TestCase(20, 80, 50, 0, "050")]
        [TestCase(20, 80, 50, 1, "050")]
        [TestCase(20, 80, 50, 2, "050")]
        [TestCase(20, 80, 50, 3, "050")]
        public void Average_wind_direction_is_shown_as_varation_is_60_degrees_or_less_and_wind_speed_3_knots_or_less(double? minimumWindDirection, double? maximumWindDirection, double? averageWindDirection, double? averageWindSpeed, string expected)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
                AverageWindDirection = averageWindDirection,
                AverageWindSpeed = averageWindSpeed,
            };
            //Act
            var result = DisplayAverageSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Theory]
        [TestCase(10, 20, 15, 3.1)]
        [TestCase(10, 20, 15, 4)]
        [TestCase(10, 30, 20, 3.1)]
        [TestCase(10, 30, 20, 4)]
        [TestCase(10, 40, 25, 3.1)]
        [TestCase(10, 40, 25, 4)]
        [TestCase(10, 50, 30, 3.1)]
        [TestCase(10, 50, 30, 4)]
        [TestCase(10, 60, 35, 3.1)]
        [TestCase(10, 60, 35, 4)]
        [TestCase(10, 70, 40, 3.1)]
        [TestCase(10, 70, 40, 4)]
        [TestCase(20, 80, 50, 3.1)]
        [TestCase(20, 80, 50, 4)]
        public void Average_wind_direction_is_VRB_as_varation_is_60_degrees_or_less_and_wind_speed_more_than_3_knots(double? minimumWindDirection, double? maximumWindDirection, double? averageWindDirection, double? averageWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
                AverageWindDirection = averageWindDirection,
                AverageWindSpeed = averageWindSpeed,
            };
            //Act
            var result = DisplayAverageSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo("VRB"));
        }

        [Theory]
        [TestCase(10, 191, 100, 1, "100")]
        [TestCase(10, 191, 100, 2, "100")]
        [TestCase(10, 191, 100, 3, "100")]
        [TestCase(10, 200, 105, 1, "105")]
        [TestCase(10, 200, 105, 2, "105")]
        [TestCase(10, 200, 105, 3, "105")]
        [TestCase(20, 220, 120, 1, "120")]
        [TestCase(20, 220, 120, 2, "120")]
        [TestCase(20, 220, 120, 3, "120")]
        [TestCase(20, 220, 120, 1, "120")]
        [TestCase(20, 220, 120, 2, "120")]
        [TestCase(20, 220, 120, 3, "120")]
        public void Average_wind_direction_is_VRB_as_varation_is_180_degrees_or_more_and_wind_speed_3_knots_or_less(double? minimumWindDirection, double? maximumWindDirection, double? averageWindDirection, double? averageWindSpeed, string expected)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
                AverageWindDirection = averageWindDirection,
                AverageWindSpeed = averageWindSpeed,
            };
            //Act
            var result = DisplayAverageSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo("VRB"));
        }

        [Theory]
        [TestCase(10, 190, 100, 3.1)]
        [TestCase(10, 190, 100, 4)]
        [TestCase(10, 200, 105, 3.1)]
        [TestCase(10, 200, 105, 4)]
        [TestCase(20, 220, 120, 3.1)]
        [TestCase(20, 220, 120, 4)]
        [TestCase(20, 220, 120, 3.1)]
        [TestCase(20, 220, 120, 4)]
        public void Average_wind_direction_is_VRB_as_varation_is_180_degrees_or_more_and_wind_speed_more_than_3_knots(double? minimumWindDirection, double? maximumWindDirection, double? averageWindDirection, double? averageWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
                AverageWindDirection = averageWindDirection,
                AverageWindSpeed = averageWindSpeed
            };
            //Act
            var result = DisplayAverageSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo("VRB"));
        }

        [Theory]
        [TestCase(10, 71, 3.1)]
        [TestCase(10, 71, 4)]
        [TestCase(10, 80, 3.1)]
        [TestCase(10, 80, 4)]
        [TestCase(10, 189, 3.1)]
        [TestCase(10, 189, 4)]
        public void Average_wind_direction_is_VRB_as_varation_is_between_60_180_degrees_and_wind_speed_more_than_3_knots(double? minimumWindDirection, double? maximumWindDirection, double? averageWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
                AverageWindSpeed = averageWindSpeed
            };
            //Act
            var result = DisplayAverageSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo("VRB"));
        }

        [Theory]
        [TestCase(10, 71, 2)]
        [TestCase(10, 71, 3)]
        [TestCase(10, 80, 2)]
        [TestCase(10, 80, 3)]
        [TestCase(10, 189, 2)]
        [TestCase(10, 189, 3)]
        public void Average_wind_direction_is_VRB_as_varation_is_between_60_180_degrees_and_wind_speed_is_3_knots_or_less(double? minimumWindDirection, double? maximumWindDirection, double? averageWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
                AverageWindSpeed = averageWindSpeed
            };
            //Act
            var result = DisplayAverageSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo("VRB"));
        }

        [Theory]
        [TestCase(10, 190)]
        [TestCase(10, 200)]
        [TestCase(20, 220)]
        public void Extreme_wind_as_varation_is_180_degrees_or_more(double? minimumWindDirection, double? maximumWindDirection)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
            };
            //Act
            var result = DisplayAverageSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo("VRB"));

        }

        [Theory]
        [TestCase(10, 71)]
        [TestCase(10, 80)]
        [TestCase(10, 189)]
        public void Not_extreme_wind_as_varation_is_less_than_180_degrees_and_average_wind_direction_known(double? minimumWindDirection, double? maximumWindDirection)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
                AverageWindDirection = 1,
            };
            //Act
            var result = DisplayAverageSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo("VRB"));
        }

        [Test]
        public void Extreme_wind_as_average_direction_not_Know()
        {
            //Arrange
            var data = new WindData
            {
                AverageWindDirection = null,
            };
            //Act
            var result = DisplayAverageSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo("VRB"));
        }
    }
}