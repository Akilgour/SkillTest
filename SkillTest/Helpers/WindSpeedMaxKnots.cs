namespace Mma.Common.Helpers
{
    public static class WindSpeedMaxKnots
    {
        public static bool Resolve(double? speedInKnots) =>
            speedInKnots >= 100;
    }
}