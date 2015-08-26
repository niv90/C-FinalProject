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
    public class WeatherDataSite2 : WeatherData, IWeatherDataService
    {
        private String ip { get; set; }
        private static WeatherDataSite2 weatherdata;
        
        //authentication for the RESTFul web service
        private const String key = "7d5967e2ae100a83f53f356a8fa12";  
        private WeatherDataSite2() : base() {}

        /// <summary>
        /// A method that implements the singleton Design Pattern that creates
        ///  only 1 object.
        /// </summary>
        /// <returns>return a WeatherData object in type of WeatherDatasite1</returns>
        public static WeatherDataSite2 Instance()
        {
            if (weatherdata == null)
            {
                weatherdata = new WeatherDataSite2();
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
            WeatherDataSite2 wd = new WeatherDataSite2();

            try
            {
                wd.location.Country = location.Country;
                XMLFunction(wd, location);
            }
            catch (WeatherDataServiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return wd;
        }

        /// <summary>
        /// A virtual method that get the weather object of a chosen country.
        /// </summary>
        /// <param name="wd">The WeatherData object. </param>
        /// <param name="location">Location requested by user to get service.</param>
        /// <returns>return a WeatherData object with all the params. </returns>
        public void XMLFunction(WeatherDataSite2 wd, Location location)
        {
            String URLString = "http://api.worldweatheronline.com/premium/v1/weather.ashx?key=" +
                        key + "&q=" + location.Country + "&num_of_days=1&tp=24&format=xml";
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
                XDocument ob = XDocument.Parse(xml);
                 //A linq to xml that get all the values from the site
                var weather = from x in ob.Descendants("data")
                              select new
                              {
                                  City = x.Descendants("query").First().Value,
                                  Ip = x.Descendants("type").First().Value,
                                  Sun = x.Descendants("sunrise").First().Value,
                                  Set = x.Descendants("sunset").First().Value,
                                  Tempat = x.Descendants("temp_C").First().Value,
                                  Cloud = x.Descendants("cloudcover").First().Value,
                                  Humidity = x.Descendants("humidity").First().Value,
                                  Speed = x.Descendants("windspeedKmph").First().Value,
                                  Direction = x.Descendants("winddir16Point").First().Value,
                                  Update = x.Descendants("date").First().Value,
                              };

                //Get all the values from the linq vairables and set 
                //them into the WeatherData service values.
                foreach (var data in weather)
                {
                    //This restful web service also support an ip search.
                    //this check is to confrim that the user pressed a country.
                    if(data.Ip=="IP") 
                    {
                        throw new XmlException();
                    }
                    wd.location.Country = data.City;
                    wd.sunrise.Sunrise = data.Sun;
                    wd.sunset.Sunset = data.Set;
                    wd.lastupdate.Update = data.Update;
                    wd.temperature.Celsius = Double.Parse(data.Tempat);
                    wd.cloud.Clouds = data.Cloud;
                    wd.humidity.Humitidy = data.Humidity;
                    wd.wind.Speed = Double.Parse(data.Speed);
                    wd.wind.Direction = data.Direction;
                }
            }
            catch (XmlException)
            {

                throw new WeatherDataServiceException("Wrong Country");
            }
            catch (WebException)
            {
                throw new WeatherDataServiceException("There is not internet connection");
            }
            catch (InvalidOperationException ex)
            {
                throw new WeatherDataServiceException(ex.Message);
            }
        }
    }
}
