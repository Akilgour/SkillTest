namespace Mma.Common.Helpers
{
    using Mma.Common.models;

    public static class DisplayMaxSurfaceWindSpeed
    {
        public static string Resolve(WindData windData)
        {
            if(windData.AverageWindSpeed == windData.MaximumWindSpeed)
            {
                return "";
            }
          
            if ((  windData.MaximumWindSpeed- windData.AverageWindSpeed) < 10)
            {
                return "";
            }
           
            return $"{windData.MaximumWindSpeed:00}";
        }
    }
}