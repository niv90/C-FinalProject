using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace il.ac.shenkar
{
    class Location
    {
      private  String country;

        public Location()
        {
           
        }
        public Location(String location)
        {
            country = location;
        }
        public String Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
            }
        }
    }
}
