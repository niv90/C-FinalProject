
namespace il.ac.shenkar
{
    /// <summary>
    /// The interface creates a union of three main departments,
    ///  in order to allow the user to use the library,
    ///  he needs to call a method defined in the interface.
    /// </summary>
    public interface IWeatherDataService
    {
        WeatherData getWeatherData(Location location); 
    }
}



