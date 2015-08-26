
namespace il.ac.shenkar
{
    /// <summary>
    /// This class describes the state of the Temperature.
    /// </summary>
    public class Temperature
    {
        private double celsius;

        /// <summary>
        /// Convert from kelvin to celsius
        /// </summary>
        public void KelvinToCelsius()
        {
            celsius = celsius - 273;
        }

        /// <summary>
        /// Gets and Sets the celsius value.
        /// </summary>
        public double Celsius
        {
            get
            {
                return celsius;
            }
            set
            {
                celsius = value;       
            }
        }
     
    }
}
