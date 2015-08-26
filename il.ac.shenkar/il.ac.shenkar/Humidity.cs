using System;

namespace il.ac.shenkar
{
    /// <summary>
    /// This class describes the state of the humidity.
    /// </summary>
    public class Humidity
    {
        private String humidity;

        /// <summary>
        /// Gets and Sets the humidity value.
        /// </summary>
        public String Humitidy
        {
            get
            {
                return humidity;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Wrong value for humidity");
                }
                else
                {
                    humidity = value + "%";
                }
                
            }
        }
    }
}
