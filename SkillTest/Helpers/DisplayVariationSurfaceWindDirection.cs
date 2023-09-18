namespace Mma.Common.Helpers
{
    using Mma.Common.models;

    public static class DisplayVariationSurfaceWindDirection
    {
        public static string Resolve(WindData windData)
        {
            if (IsThereExtremeWindDirections.Resolve(windData))
            {
                return "";
            }

            // AK I am not 100% sure on where there -or- and -and- are in this sentance.
            // So I would go find a product owner, and just have a chat

            // Variations in wind direction shall be reported only when
            //      the total variation in direction over the previous ten - minute period is 60 degrees or more
            //  or
            //      but less than 180 degrees
            //  and the average wind speed is greater than 3 knots.

            var variationInDirection = windData.MaximumWindDirection - windData.MinimumWindDirection;

            if (variationInDirection >= 60 && variationInDirection < 180)
            {
                if (windData.AverageWindSpeed > 3)
                {
                    var minimumWindDirection = $"{RoundDegreesDown.Resolve(windData.MinimumWindDirection):000}";
                    var maximumWindDirection = $"{RoundDegreesDown.Resolve(windData.MaximumWindDirection):000}";

                    return $"{minimumWindDirection}V{maximumWindDirection}";
                }
            }

            return "";
        }
    }
}