using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace il.ac.shenkar
{
     class WeatherDataServiceFactory
    {
        public static String OPEN_WEATHER_MAP = "OPEN_WEATHER_MAP";

        public static WeatherData getWeatherDataService(string str)
        {
            WeatherData wd = null;

            if (str.Equals("OPEN_WEATHER_MAP"))              //factory 
            {
                 wd = WeatherData.Instance();
            }
            //exception

            return wd;
        }

    }
}
