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
            return $"{windData.AverageWindSpeed:00}";
        }
    }
}