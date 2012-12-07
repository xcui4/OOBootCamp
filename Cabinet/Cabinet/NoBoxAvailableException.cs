using System;

namespace CabinetSystem
{
    public class NoBoxAvailableException : ApplicationException
    {
        public NoBoxAvailableException(string message)
            :base(message)
        {
            
        }

    }
}