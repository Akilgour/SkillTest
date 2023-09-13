namespace Mma.Common.Helpers
{
    using Mma.Common.models;

    public static class DisplayAverageSurfaceWindDirection
    {
        public static string Resolve(WindData windData)
        {
            if (windData.AverageWindDirection == null)
            {
                return "///";
            }
            return $"{windData.AverageWindDirection:000}";
        }
    }
}