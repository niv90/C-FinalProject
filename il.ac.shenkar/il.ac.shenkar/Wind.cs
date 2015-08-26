using System;

namespace il.ac.shenkar
{
    /// <summary>
    /// This class describes the state of the wind speed and direction.
    /// </summary>
    public class Wind
    {
        private double speed;
        private String direction;

        /// <summary>
        /// Gets and Sets the speed value.
        /// </summary>
        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value >= 0)
                {
                    speed = value;
                }
                else
                {
                    Console.WriteLine("Wrong speed");
                }

            }
        }

        /// <summary>
        /// Gets and Sets the direction value.
        /// </summary>
        public String Direction
        {
            get
            {
                return direction;
            }
            set
            {
                if(value == null)
                {
                    Console.WriteLine("Wrong direction");
                }
                else
                {
                    direction = value;
                }
            }
        }
    }
}
