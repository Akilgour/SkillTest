namespace Mma.Common.Helpers
{
    using Mma.Common.models;

    public static class DisplayAverageSurfaceWindSpeed
    {
        public static string Resolve(WindData windData)
        {
            if (windData.AverageWindSpeed == null)
            {
                return "//";
            }

            if (WindSpeedMaxKnots.Resolve(windData.AverageWindSpeed))
            {
                return "P99";
            }

            return $"{WindSpeedInKnots.Resolve(windData.AverageWindSpeed):00}";
        }
    }
}