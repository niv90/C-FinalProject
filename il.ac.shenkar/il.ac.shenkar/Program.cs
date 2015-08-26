using System;

namespace il.ac.shenkar
{
    class Program
    {
        static void Main(string[] args)
        {
                 IWeatherDataService service = WeatherDataServiceFactory.getWeatherDataService(
                 WeatherDataServiceFactory.WORLD_WEATHER_ONLINE);
                 WeatherData wd = service.getWeatherData(new Location("London"));
                 wd.PrintAllDetails();
         }
    }
}
