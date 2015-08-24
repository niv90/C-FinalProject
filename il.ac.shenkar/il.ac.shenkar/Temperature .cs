using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace il.ac.shenkar
{
    class Temperature
    {
        private double celsius;
        public double Celsius
        {
            get
            {
                return celsius;
            }
            set
            {
                celsius = value - 273;       //convert from kelvin to celsius
            }
        }
     
    }
}
