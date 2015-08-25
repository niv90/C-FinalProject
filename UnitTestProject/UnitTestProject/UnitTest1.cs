using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using il.ac.shenkar;
using System.Diagnostics;
using System.Net;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

        IWeatherDataService service = 
        WeatherDataServiceFactory.getWeatherDataService(WeatherDataServiceFactory.OPEN_WEATHER_MAP);
        WeatherData weatherdata;

        [TestMethod]
        public void TestGetLocation()
        {
            weatherdata = service.getWeatherData(new Location("london"));
            Assert.AreEqual("london", weatherdata.GetLocation());
        }
        [TestMethod]
        public void TestConstFactory()
        {
            Assert.IsNotNull(service);
        }
        [TestMethod]
        public void TestGetTemperature()
        {
            double celsius = 15.5;
            weatherdata = service.getWeatherData(new Location("london"));
            Assert.AreEqual(celsius, weatherdata.GetTemperature(), delta: 30);
        }
        [TestMethod]
        public void TestGetWeatherData()
        {
            WeatherData wd1 = service.getWeatherData(new Location("London"));
            WeatherData wd2 = service.getWeatherData(new Location("nullnull"));
            Assert.AreEqual(null, wd2.GetSunRise());
            Assert.IsNotNull(wd1.GetSunRise());
        }
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
