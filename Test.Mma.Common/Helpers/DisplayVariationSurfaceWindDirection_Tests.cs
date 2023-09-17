namespace Test.Mma.Common.Helpers
{
    using global::Mma.Common.Helpers;
    using global::Mma.Common.models;
    using NUnit.Framework;

    internal class Display_variation_surface_wind_direction_tests
    {
        [TestCase(null, null )]
        [TestCase(10, 20 )]
        [TestCase(10, 30 )]
        [TestCase(10, 40 )]
        [TestCase(10, 50 )]
        [TestCase(10, 60 )]
        [TestCase(10, 70 )]
        [TestCase(20, 80 )]
        public void Wind_Variation_is_empty_as_varation_is_60_degrees_or_less(double? minimumWindDirection, double? maximumWindDirection )
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
            Assert.IsEmpty(result );
        }

        [TestCase(10, 190)]
        [TestCase(10, 200)]
        [TestCase(20, 220)]
        public void Wind_Variation_is_empty_as_varation_is_180_degrees_or_more(double? minimumWindDirection, double? maximumWindDirection)
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
            Assert.IsEmpty(result);
        }

        [TestCase(10, 71, null)]
        [TestCase(10, 71, 0)]
        [TestCase(10, 71, 1)]
        [TestCase(10, 71, 2)]
        [TestCase(10, 71, 3)]
        [TestCase(10, 80, null)]
        [TestCase(10, 80, 0)]
        [TestCase(10, 80, 1)]
        [TestCase(10, 80, 2)]
        [TestCase(10, 80, 3)]
        [TestCase(10, 189, null)]
        [TestCase(10, 189, 0)]
        [TestCase(10, 189, 1)]
        [TestCase(10, 189, 2)]
        [TestCase(10, 189, 3)]
        public void Wind_Variation_is_empty_as_varation_is_between_60_180_degrees_but_average_wind_speed_not_greater_than_3_knots(double? minimumWindDirection, double? maximumWindDirection, double averageWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
                AverageWindSpeed = averageWindSpeed 
            };
            //Act
            var result = DisplayVariationSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.IsEmpty(result);
        }

        [TestCase(10, 71, 3.1, "010V071")]
        [TestCase(10, 71, 4, "010V071")]
        [TestCase(10, 80, 3.1, "010V080")]
        [TestCase(10, 80, 4, "010V080")]
        [TestCase(10, 189, 3.1, "010V189")]
        [TestCase(10, 189, 4, "010V189")]
        [TestCase(300, 360, 4, "300V360")]
        public void Wind_Variation_is_show_as_varation_is_between_60_180_degrees_but_average_wind_speed_is_greater_than_3_knots(double? minimumWindDirection, double? maximumWindDirection, double averageWindSpeed, string expected)
        {
            //Arrange
            var data = new WindData
            {
                MinimumWindDirection = minimumWindDirection,
                MaximumWindDirection = maximumWindDirection,
                AverageWindSpeed = averageWindSpeed,
                AverageWindDirection = 2 // This is needed for IsThereExtremeWindDirections
            };
            //Act
            var result = DisplayVariationSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo(expected));
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
            var result = DisplayVariationSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo(""));

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
            var result = DisplayVariationSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo(""));
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
            var result = DisplayVariationSurfaceWindDirection.Resolve(data);
            //Assert
            Assert.That(result, Is.EqualTo(""));
        }
    }
}