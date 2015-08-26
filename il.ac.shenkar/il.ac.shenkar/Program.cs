using System;

namespace il.ac.shenkar
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            if (x==0)
            {
                IWeatherDataService service1 = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
                 WeatherData wd1 = service1.getWeatherData(new Location("London"));
                 wd1.PrintAllDetails();
               Console.WriteLine( wd1.GetCloud());
            }

            if(x==1)
            {
                IWeatherDataService service = WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.WORLD_WEATHER_ONLINE);
                WeatherData wd = service.getWeatherData(new Location("LONDON"));
                wd.PrintAllDetails();
                Console.WriteLine(wd.GetCloud());
            }
        }
    }
}
