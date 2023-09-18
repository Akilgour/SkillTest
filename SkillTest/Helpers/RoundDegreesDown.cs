namespace Mma.Common.Helpers
{
    using System;

    public static class RoundDegreesDown
    {
        public static double Resolve(double? value)
        {
            if (value % 10 == 5)
            {
                value--;
            }
            return (int)Math.Round((double)value / 10, MidpointRounding.AwayFromZero) * 10;
        }
    }
}