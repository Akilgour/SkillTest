namespace Mma.Common
{
    using System.Text;
    using Mma.Common.Helpers;
    using Mma.Common.models;

    public interface IWindFormatter
    {
        string FormatWind(WindData windData);
    }

    public class WindFormatter : IWindFormatter
    {
        public string FormatWind(WindData windData)
        {
            if(IsItCalm.Resolve(windData))
            {
                return "00000KT";
            }

            var result = new StringBuilder();

 

            result.Append($"{DisplayAverageSurfaceWindDirection.Resolve(windData)}");
            result.Append($"{DisplayAverageSurfaceWindSpeed.Resolve(windData)}");
            result.Append($"{DisplayMaxSurfaceWindSpeed.Resolve(windData)}");
            result.Append("KT");
            result.Append($"{DisplayVariationSurfaceWindDirection.Resolve(windData)}");
            
            
            return result.ToString();
        }
    }
}
