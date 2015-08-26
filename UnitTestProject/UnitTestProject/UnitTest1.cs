using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using il.ac.shenkar;
using System.Diagnostics;
using System.Net;

namespace UnitTestProject
{
    /// <summary>
    /// Class that test the major Class and Methods in WeatherData using TDD methodology.
    /// </summary>
    [TestClass]
    public class UnitTest1
    {

        IWeatherDataService service = 
        WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
        WeatherData weatherdata;

        /// <summary>
        /// This method check if the web service is support the Const value.
        /// </summary>
        [TestMethod]
        public void TestConstFactory()
        {
            Assert.IsNotNull(service);
        }

        /// <summary>
        /// Check that the temperature of london is between -15.5 to 45.5.
        /// </summary>
        [TestMethod]
        public void TestGetTemperature()
        {
            double celsius = 15.5;
            weatherdata = service.getWeatherData(new Location("london"));
            Assert.AreEqual(celsius, weatherdata.GetTemperature(), delta: 30);
        }

        /// <summary>
        /// Assert 1. Equal wrong country to a null.
        /// Assert 2. Check that we got a a values from the site.
        /// </summary>
        [TestMethod]
        public void TestGetWeatherData()
        {
            WeatherData wd1 = service.getWeatherData(new Location("London"));
            WeatherData wd2 = service.getWeatherData(new Location("nullnull"));
            Assert.AreEqual(null, wd2.GetSunRise());
            Assert.IsNotNull(wd1.GetSunRise());
        }

        /// <summary>
        /// Disconnect the internet in order to throw an excetion ( WebException )
        /// and check if there is a fail.
        /// </summary>
        [TestMethod]
        public void TestXMLInternet()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "ipconfig";
            info.Arguments = "/release"; // or /release if you want to disconnect
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(info);
            p.WaitForExit();

            WeatherData wd1 = service.getWeatherData(new Location("London"));

            info.Arguments = "/renew";
             p = Process.Start(info);

            Assert.AreEqual(null,wd1.GetSunRise());
        }
    }
}
