namespace Mma.Common.Helpers
{
    using System;

    public class WindSpeedInKnots
    {
        /// <summary>
        /// The surface wind average speed and maximum speed shall be rounded to the nearest knot in the METAR.Surface wind speed is reported between 01 and 99 knots.
        /// </summary>
        /// <param name="windInKnots"></param>
        public static double Resolve(double? windInKnots) =>
               Math.Round(windInKnots.Value, 0);
       
    }
}