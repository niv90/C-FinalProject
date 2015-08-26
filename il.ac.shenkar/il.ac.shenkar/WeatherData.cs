using System;

namespace il.ac.shenkar
{
    /// <summary>
    /// An abstract class that define a Weather vairables.
    /// </summary>
    public abstract class WeatherData : IWeatherDataService
    {

        #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        protected Location location;
        protected Cloud cloud;
        protected Humidity humidity;
        protected LastUpdate lastupdate;
        protected Wind wind;
        protected Temperature temperature;
        protected SunRise sunrise;
        protected SunSet sunset;

        #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// Will print all the details of the Country weather.
        /// </summary>
        virtual public void PrintAllDetails()
        {
            Console.WriteLine(
               "The weather of " + GetLocation() + " is:\n" +
               "SunRise is: " + GetSunRise() + "\n" +
               "SunSet is: " + GetSunSet() + "\n" +
               "Temperature is: " + GetTemperature() + " Celsius\n" +
               "Humidity is: " + GetHumidity() + "\n" +
               "Wind Speed is: " + GetSpeed() + " direction to: " + GetDirection() + "\n" +
               "Clouds is: " + GetCloud() + "\n" +
               "Last update for this weather is: " + Getlastupdate());
        }

        /// <summary>
        /// Default constructor that initialize all the instance variable 
        /// </summary>
        public WeatherData()
        {
            location = new Location();
            sunrise = new SunRise();
            sunset = new SunSet();
            cloud = new Cloud();
            humidity = new Humidity();
            lastupdate = new LastUpdate();
            wind = new Wind();
            temperature = new Temperature();
        }

        /// <summary>
        /// Get the location.
        /// </summary>
        /// <returns>Return the value of the location.</returns>
        public virtual String GetLocation()
        {
            return location.Country;
        }

        /// <summary>
        /// Get the value of the clouds.
        /// </summary>
        /// <returns>Return the value of the clouds.</returns>
        public virtual String GetCloud()
        {
            return cloud.Clouds;
        }

        /// <summary>
        /// Get the value of the sunrise.
        /// </summary>
        /// <returns>Return the value of the sunrise.</returns>
        public virtual String GetSunRise()
        {
            return sunrise.Sunrise;
        }

        /// <summary>
        /// Get the value of the sunset.
        /// </summary>
        /// <returns>Return the value of the sunset.</returns>
        public virtual String GetSunSet()
        {
            return sunset.Sunset;
        }

        /// <summary>
        /// Get the value of the humidity.
        /// </summary>
        /// <returns>Return the value of the humidity.</returns>
        public virtual String GetHumidity()
        {
            return humidity.Humitidy;
        }

        /// <summary>
        /// Get the value of the last update time.
        /// </summary>
        /// <returns>Return the value of the last update time.</returns>
        public virtual String Getlastupdate()
        {
            return lastupdate.Update;
        }

        /// <summary>
        /// Get the value of the wind speed.
        /// </summary>
        /// <returns>Return the value of the wind speed.</returns>
        public virtual double GetSpeed()
        {
            return wind.Speed;
        }

        /// <summary>
        /// Get the value of the wind direction.
        /// </summary>
        /// <returns>Return the value of the wind direction.</returns>
        public virtual String GetDirection()
        {
            return wind.Direction;
        }

        /// <summary>
        /// Get the value of the temperature.
        /// </summary>
        /// <returns>Return the value of the temperature.</returns>
        public virtual double GetTemperature()
        {
            return temperature.Celsius;
        }

        /// <summary>
        /// A virtual method that get the weather object of a chosen country.
        /// </summary>
        /// <param name="location">Location requested by user to get service.</param>
        /// <returns>return a WeatherData object with all the params. </returns>
        virtual public WeatherData getWeatherData(Location location)
        {
            throw new NotImplementedException();
        }
    }
}

