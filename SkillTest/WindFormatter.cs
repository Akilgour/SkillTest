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
            var result = new StringBuilder();

            result.Append($"{DisplayAverageSurfaceWindDirection.Resolve(windData)}");
            result.Append($"{windData.AverageWindSpeed:00}");
            result.Append("KT");
            
            return result.ToString();
        }
    }
}
