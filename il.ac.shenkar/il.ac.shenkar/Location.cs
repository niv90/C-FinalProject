using System;

namespace il.ac.shenkar
{
    /// <summary>
    /// This class describes the country that the user ask for weather.
    /// </summary>
    public class Location
    {
        private  String country;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Location(){ }

        /// <summary>
        /// Constructor that sets the country.
        /// </summary>
        /// <param name="location">Location requested by user to get service.</param>
        public Location(String location)
        {
            country = location;
        }

        /// <summary>
        /// Gets and Sets the country value.
        /// </summary>
        public String Country
        {
            get
            {
                return country;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Wrong value for country");
                }
                else
                {
                    country = value;
                }
            }
        }
    }
}
