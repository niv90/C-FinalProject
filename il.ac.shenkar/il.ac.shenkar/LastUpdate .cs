using System;

namespace il.ac.shenkar
{
    /// <summary>
    /// This class describes the last update of the service.
    /// </summary>
    public class LastUpdate
    {
        private String update;

        /// <summary>
        /// Gets and Sets the update value.
        /// </summary>
        public String Update
        {
            get
            {
                return update;
            }
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Wrong value for update");
                }
                else
                {
                    update = value;
                }

            }
        }
    }
}
