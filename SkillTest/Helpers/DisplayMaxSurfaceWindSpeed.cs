namespace Mma.Common.Helpers
{
    using Mma.Common.models;

    public static class DisplayMaxSurfaceWindSpeed
    {
        public static string Resolve(WindData windData)
        {
            if (windData.MaximumWindSpeed == null)
            {
                return "//";
            }
            return $"{windData.MaximumWindSpeed:00}";
        }
    }
}