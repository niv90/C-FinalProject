using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace il.ac.shenkar
{
    class Wind
    {
        private double speed;
        private String direction;

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
