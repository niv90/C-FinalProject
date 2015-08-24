using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace il.ac.shenkar
{
    class Humidity
    {
        private String humidity;

        public String Humitidy
        {
            get
            {
                return humidity;
            }
            set
            {
                humidity = value + "%";
            }
        }
    }
}
