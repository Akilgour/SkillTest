namespace Mma.Common.Helpers
{
    using Mma.Common.models;

    public static class IsItCalm
    {
        //  When the wind speed is less than 1 knot, this should be reported as calm

        public static bool Resolve(WindData windData) =>
            windData.AverageWindSpeed < 1;
    }
}