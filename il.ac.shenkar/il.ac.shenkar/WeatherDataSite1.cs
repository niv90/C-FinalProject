using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Net;

namespace il.ac.shenkar
{
    /// <summary>
    /// A class that inheritance from WeatherData and implemetns IWeatherDataService.
    /// This class create an object in WeatherData type.
    /// </summary>
    public class WeatherDataSite1 : WeatherData, IWeatherDataService
    {
        private static WeatherDataSite1 weatherdata;
        private WeatherDataSite1() : base() { }

        /// <summary>
        /// A method that implements the singleton Design Pattern that creates
        ///  only 1 object.
        /// </summary>
        /// <returns>return a WeatherData object in type of WeatherDatasite1</returns>
        public static WeatherDataSite1 Instance()
        {
            if (weatherdata == null)
            {
                weatherdata = new WeatherDataSite1();
            }
            return weatherdata;
        }

        /// <summary>
        /// A virtual method that get the weather object of a chosen country.
        /// </summary>
        /// <param name="location">Location requested by user to get service.</param>
        /// <returns>return a WeatherData object with all the params. </returns>
        public override WeatherData getWeatherData(Location location)
        {
            WeatherDataSite1 wd = new WeatherDataSite1();
            
            try
            {
                wd.location.Country = location.Country;
                XMLFunction(wd, location);
            }
           catch(WeatherDataServiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return wd;
        }

        /// <summary>
        /// This function parsing the xml from the REStful Web Service site
        ///  and set all the values.
        /// </summary>
        /// <param name="wd">The WeatherData object. </param>
        /// <param name="location">The requested location</param>
        public void XMLFunction(WeatherDataSite1 wd, Location location)
        {
            String URLString = "http://api.openweathermap.org/data/2.5/weather?q=" + location.Country + "&mode=xml";
            string xml;
            using (WebClient client = new WebClient())
            {
                try
                {
                    xml = client.DownloadString(URLString);// xml url to string
                }
                catch (WebException)
                {
                    throw new WeatherDataServiceException("There is not internet connection");
                }
            }
            try
            {
                XDocument ob = XDocument.Parse(xml);                 //A linq to xml that get all the values from the site
            var weather = from x in ob.Descendants("current")
                          select new
                          {
                              City = x.Descendants("city").Attributes("name").First().Value,
                              Sun = x.Descendants("sun").Attributes("rise").First().Value,
                              Set = x.Descendants("sun").Attributes("set").First().Value,
                              Tempat = x.Descendants("temperature").Attributes("value").First().Value,
                              Cloud = x.Descendants("clouds").Attributes("name").First().Value,
                              Humidity = x.Descendants("humidity").Attributes("value").First().Value,
                              Speed = x.Descendants("speed").Attributes("value").First().Value,
                              Direction = x.Descendants("direction").Attributes("code").First().Value,
                              Update = x.Descendants("lastupdate").Attributes("value").First().Value,
                          };

                //Get all the values from the linq vairables and set 
                //them into the WeatherData service values.
                foreach (var data in weather)
            {
                wd.location.Country = data.City;
                wd.sunrise.Sunrise = data.Sun;
                wd.sunset.Sunset = data.Set;
                wd.lastupdate.Update = data.Update;
                wd.temperature.Celsius = Double.Parse(data.Tempat);
                wd.cloud.Clouds = data.Cloud;
                wd.humidity.Humitidy = data.Humidity;
                wd.wind.Speed = Double.Parse(data.Speed);
                wd.wind.Direction = data.Direction;
            }            wd.temperature.KelvinToCelsius();
        }             catch(XmlException )
            {
                throw new WeatherDataServiceException("Wrong Country");
            }
            catch (WebException )
            {
                throw new WeatherDataServiceException("There is not internet connection");
            }
        }
    }
}
