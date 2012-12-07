using System;

namespace CabinetSystem
{
    public class WrongTicketException : ApplicationException
    {
        public WrongTicketException(string message)
            : base(message)
        {
        }
    }
}