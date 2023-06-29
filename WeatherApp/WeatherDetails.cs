using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class newRoot
    {
        public List<DailyForecast> DailyForecasts { get; set; }
    }

    public class DailyForecast
    {
        public string Date { get; set; }
        public Temperature Temperature { get; set; }
    }

    public class Maximum
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }

    public class Minimum
    {
        public double Value { get; set; }
        public string Unit { get; set; }
    }

    public class Temperature
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }
}
