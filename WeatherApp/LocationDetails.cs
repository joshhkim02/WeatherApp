using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Root
    {
        public string Key { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public AdministrativeArea AdministrativeArea { get; set; }
        public TimeZone TimeZone { get; set; }
        public GeoPosition GeoPosition { get; set; }
    }

    public class AdministrativeArea
    {
        public string ID { get; set; }
        public string EnglishName { get; set; }
    }

    public class TimeZone
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class GeoPosition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
