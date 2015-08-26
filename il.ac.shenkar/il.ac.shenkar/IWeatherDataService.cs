
namespace il.ac.shenkar
{
    /// <summary>
    /// The interface creates a union of three main departments,
    ///  in order to allow the user to use the library,
    ///  he needs to call a method defined in the interface.
    /// </summary>
    public interface IWeatherDataService
    {
        /// <summary>
        /// A virtual method that get the weather object of a chosen country.
        /// </summary>
        /// <param name="location">Location requested by user to get service.</param>
        /// <returns>return a WeatherData object with all the params. </returns>
        WeatherData getWeatherData(Location location); 
    }
}



