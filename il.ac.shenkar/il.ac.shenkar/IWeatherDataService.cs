using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace il.ac.shenkar
{
    interface IWeatherDataService
    {
        WeatherData getWeatherData(Location location); 
        
    }
}
