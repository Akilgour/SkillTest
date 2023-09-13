namespace Mma.Common.Helpers
{
    using Mma.Common.models;

    public static class DisplayVariationSurfaceWindDirection
    {
        public static string Resolve(WindData windData)
        {
            var minimumWindDirection = "///";
            var maximumWindDirection = "///";

            if (windData.MinimumWindDirection != null)
            {
                minimumWindDirection = $"{windData.MinimumWindDirection:000}";
            }

            if (windData.MaximumWindDirection != null)
            {
                maximumWindDirection = $"{windData.MaximumWindDirection:000}";
            }

            return $"{minimumWindDirection}V{maximumWindDirection}";
        }
    }
}