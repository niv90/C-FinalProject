using System;

namespace il.ac.shenkar
{
    /// <summary>
    /// This class describes the state of the Sunrise.
    /// </summary>
    public class SunSet
    {
        private String sunset;

        /// <summary>
        /// Gets and Sets the sunset value.
        /// </summary>
        public String Sunset
        {
            get
            {
                return sunset;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Wrong value for sunset");
                }
                else
                {
                    sunset = value;
                }

            }
        }
    }
}
