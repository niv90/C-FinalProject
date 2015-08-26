using System;

namespace il.ac.shenkar
{
    /// <summary>
    /// This class describes the state of the Sunrise.
    /// </summary>
    public class SunRise
    {
        private String sunrise;
        /// <summary>
        /// Gets and Sets the sunrise value.
        /// </summary>
        public String Sunrise
        {
            get
            {
                return sunrise;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Wrong value for sunrise");
                }
                else
                {
                    sunrise = value;
                }

            }
        }
    }
}
