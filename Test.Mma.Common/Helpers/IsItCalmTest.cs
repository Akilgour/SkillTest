using Mma.Common.Helpers;
using Mma.Common.models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Mma.Common.Helpers
{
    internal class IsItCalmTest
    {
        [Theory]
        [TestCase(0 )]
        [TestCase(0.1 )]
        [TestCase(0.9 )]
        public void It_is_calm_wind_speed_less_than_one_knot(double? averageWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
               AverageWindSpeed = averageWindSpeed,
            };
            //Act
            var result = IsItCalm.Resolve(data);
            //Assert
            Assert.True(result);
        }

        [Theory]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void It_is_calm_wind_speed_one_knot_or_more(double? averageWindSpeed)
        {
            //Arrange
            var data = new WindData
            {
                AverageWindSpeed = averageWindSpeed,
            };
            //Act
            var result = IsItCalm.Resolve(data);
            //Assert
            Assert.False(result);
        }
    }
}
