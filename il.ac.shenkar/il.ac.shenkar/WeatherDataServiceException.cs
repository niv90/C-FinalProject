using System;

namespace il.ac.shenkar
{
    /// <summary>
    /// This class describes the special exceptions. 
    /// </summary>
    public class WeatherDataServiceException : ApplicationException
    {
        /// <summary>
        /// A constructor that get a message from throw an exception. 
        /// </summary>
        /// <param name="message">Describes the message of the exception</param>
        public WeatherDataServiceException(String message) : base(message)
        {
            
        }
    }
}