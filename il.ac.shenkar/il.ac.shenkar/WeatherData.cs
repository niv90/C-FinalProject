using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace il.ac.shenkar
{
    class WeatherData : IWeatherDataService
    {
        private static WeatherData weatherdata;
        private Location location; 
        private Cloud cloud;
        private Humidity humidity;
        private LastUpdate lastupdate;
        private Wind wind;
        private Temperature temperature;
        private SunRise sunrise;
        private SunSet sunset;
        private XMLParser xmlparser;


        private WeatherData()
        {
            location = new Location();
            xmlparser = new XMLParser();
            sunrise = new SunRise();
            sunset = new SunSet();
            cloud = new Cloud();
            humidity = new Humidity();
            lastupdate = new LastUpdate();
            wind = new Wind();
            temperature = new Temperature();
        }
      

        public static WeatherData Instance()
        {
            if (weatherdata == null)
            {
                weatherdata = new WeatherData();
            }
            return weatherdata;
        }

        public String GetLocation()
        {
            return location.Country;
        }
        public String GetCloud()
        {
            return cloud.Clouds;
        }
        public String GetSunRise()
        {
            return sunrise.DateTime;
        }
        public String GetSunSet()
        {
            return sunset.Date;
        }
        public String GetHumidity()
        {
            return humidity.Humitidy;
        }
        public String Getlastupdate()
        {
            return lastupdate.Update;
        }
        public double GetSpeed()
        {
            return wind.Speed;
        }
        public String GetDirection()
        {
            return wind.Direction;
        }
        public double GetTemperature()
        {
            return temperature.Celsius;
        }

        public void PrintAllDetails()
        {
            
           Console.WriteLine(
                "The weather of " + GetLocation() + " is:\n" +
                "SunRise is: " + GetSunRise() + "\n" +
                "SunSet is: " + GetSunSet() + "\n" +
                "Temperature is: " + GetTemperature() + " Celsius\n" +
                "Humidity is: " + GetHumidity() + "\n" +
                "Wind Speed is: " + GetSpeed() + " direction to: " + GetDirection() + "\n" +
                "Clouds is: " + GetCloud()+ "\n" +
                "Last update for this weather is: " + GetCloud());
    }

        public WeatherData getWeatherData(Location location) 
        {
             WeatherData wd = new WeatherData();
            wd.location.Country = location.Country;
            XMLFunction(wd,location);
            //throw new NotImplementedException();
            return wd;
        }

        

        public void XMLFunction(WeatherData wd,Location location)
        {
     
            String URLString = "http://api.openweathermap.org/data/2.5/weather?q="+location.Country+"&mode=xml";
            XmlTextReader reader = new XmlTextReader(URLString);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                                              //Console.Write("11111" + reader.Name);

                        switch (reader.Name)
                        {
                             
                              case "sun":
                                {
                                    reader.MoveToNextAttribute();
                                    wd.sunrise.DateTime = reader.Value;
                                    reader.MoveToNextAttribute();
                                    wd.sunset.Date = reader.Value;
                                    //Console.WriteLine("  " +sunrise.DateTime + " \n" + sunset.Date);
                                    break;
                                }
                            case "temperature":
                                {
                                    reader.MoveToNextAttribute();
                                    wd.temperature.Celsius = Double.Parse(reader.Value);
                                   // Console.WriteLine("  " + temperature.Celsius);
                                    break;
                                }
                            case "clouds":
                                {
                                    reader.MoveToNextAttribute();
                                    reader.MoveToNextAttribute();
                                    wd.cloud.Clouds = reader.Value;
                                   // Console.WriteLine("  " + cloud.Clouds);
                                    break;
                                }
                            case "humidity":
                                {
                                    reader.MoveToNextAttribute();
                                    wd.humidity.Humitidy = reader.Value;
                                   // Console.WriteLine("  " + humidity.Humitidy);
                                    break;
                                }
                            case "lastupdate":
                                {
                                    reader.MoveToNextAttribute();
                                    wd.lastupdate.Update = reader.Value;
                                   // Console.WriteLine("  " + lastupdate.Update);
                                    break;
                                }
                            case "speed":
                                {
                                    reader.MoveToNextAttribute();
                                    wd.wind.Speed = Double.Parse(reader.Value);
                                  //  Console.WriteLine("  " + wind.Speed);
                                    break;
                                }
                            case "direction":
                                {
                                    reader.MoveToNextAttribute();
                                    reader.MoveToNextAttribute();
                                    reader.MoveToNextAttribute();
                                    wind.Direction = reader.Value;
                                   // Console.WriteLine("  " + wind.Direction);
                                    break;
                                }

                        }
                       // while (reader.MoveToNextAttribute()) // Read the attributes.
                                                             // Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                          //  Console.WriteLine(reader.Name);
                       // Console.WriteLine("333333");
                        break;
         
                }
            }





        }


    }
   
   
}
