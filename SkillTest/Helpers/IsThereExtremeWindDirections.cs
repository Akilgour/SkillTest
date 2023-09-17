namespace Mma.Common.Helpers
{
    using Mma.Common.models;

    public class IsThereExtremeWindDirections
    {
        public static bool Resolve(WindData windData)
        {
            
            // The average wind direction shall not be included
            // for variable winds when the total variation in direction over the previous ten - minute period
            //   is 180 degrees or more
            // or
            //   where it is not possible to report a average direction
            // e.g.when a thunderstorm passes over the aerodrome.
            // The wind should be reported as variable
            // and no reference should be made to the two extreme directions between which the wind has varied.


            var variationInDirection = windData.MaximumWindDirection - windData.MinimumWindDirection;

            if (variationInDirection >= 180)
            {
                return true;
            }

            if (windData.AverageWindDirection is null)
            {
                return true;
            }
            return false;
        }
    }
}