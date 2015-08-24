using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace il.ac.shenkar
{
    class Cloud
    {
        private String clouds;

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
                    Console.WriteLine("Wrong cloud");
                }
                else
                {
                    clouds = value;
                }
            }

        }

    }
}
