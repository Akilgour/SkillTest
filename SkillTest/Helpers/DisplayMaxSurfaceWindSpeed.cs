namespace Mma.Common.Helpers
{
    using Mma.Common.models;

    public static class DisplayMaxSurfaceWindSpeed
    {
        public static string Resolve(WindData windData)
        {
            if (windData.AverageWindSpeed == windData.MaximumWindSpeed)
            {
                return "";
            }

            //The maximum wind (gust) within the last 10 minutes shall be reported only
            //if it exceeds the average speed by 10 knots or more
            if ((windData.MaximumWindSpeed - windData.AverageWindSpeed) < 10)
            {
                return "";
            }

            if (WindSpeedMaxKnots.Resolve(windData.MaximumWindSpeed))
            {
                return "P99";
            }

            return $"{WindSpeedInKnots.Resolve(windData.MaximumWindSpeed):00}";
        }
    }
}