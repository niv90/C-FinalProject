using System;

namespace il.ac.shenkar
{
    /// <summary>
    /// A factory class for choose a REStful Web Service.
    /// </summary>
    public class WeatherDataServiceFactory
    {
        /// <summary>
        /// Choose the www.openweathermap.com REStful Web Service.
        /// </summary>
        public static String OPEN_WEATHER_MAP = "OPEN_WEATHER_MAP";

        /// <summary>
        /// Choose the www.worldweatheronline.com REStful Web Service.
        /// </summary>
        public static String WORLD_WEATHER_ONLINE = "WORLD_WEATHER_ONLINE";

        /// <summary>
        /// This method get from the user the web service that he want
        /// to create an object, and create a singleton object.
        /// </summary>
        /// <param name="str">The desired service.</param>
        /// <returns>Return an object from the type of the chosen REStful Web Service.</returns>
        public static WeatherData getWeatherDataService(string str)
        {
            WeatherData wd = null;

            if (str.Equals("OPEN_WEATHER_MAP"))               
            {
                 wd = WeatherDataSite1.Instance();
            }
            else if (str.Equals("WORLD_WEATHER_ONLINE"))             
            {
                wd = WeatherDataSite2.Instance();
            }

            return wd;
        }

    }
}
