using System;

namespace il.ac.shenkar
{
    /// <summary>
    /// This class describes the state of the clouds.
    /// </summary>
    public class Cloud
    {
        private String clouds;

        /// <summary>
        /// Gets and Sets the cloud value.
        /// </summary>
        public String Clouds
        {
            get
            {
                return clouds;
            }
            set
            {
                if(value == null)
                {
                    Console.WriteLine("Wrong value for cloud");
                }
                else
                {
                    clouds = value;
                }
            }

        }

    }
}
