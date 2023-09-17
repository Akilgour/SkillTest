namespace Mma.Common.Helpers
{
    using Mma.Common.models;
    using System.Security.Cryptography;

    public static class DisplayAverageSurfaceWindDirection
    {
        public static string Resolve(WindData windData)
        {
            if (IsThereExtremeWindDirections.Resolve(windData))
            {
                return "VRB";
            }

            // AK I am not 100% sure on where there -or- and -and- are in this sentance.
            // So I would go find a product owner, and just have a chat

            //The average wind direction shall NOT be included
            //for variable winds when the total variation in direction over the previous ten - minute period
            //  is 60 degrees or more
            //or
            //    but less than 180 degrees
            //and the wind speed is 3 knots or less; the wind in this case shall be reported as variable.

            var variationInDirection = windData.MaximumWindDirection - windData.MinimumWindDirection;

            if (variationInDirection <= 60 || variationInDirection > 180)
            {
                if (windData.AverageWindSpeed <= 3)
                {
                    return $"{windData.AverageWindDirection:000}"; ;
                }
            }
            return "VRB";
             
        }
    }
}