using System;
using System.Collections.Generic;

namespace CabinetSystem
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class InvalidTicketException : ApplicationException
    {
        public InvalidTicketException(string message)
            : base(message)
        {
        }
    }

    public class Cabinet
    {
        #region constructor
        public Cabinet(int totalBoxCountNumber)
        {
            m_RemainingEmptyBoxCount = totalBoxCountNumber;
            m_Box = new Dictionary<Ticket, Bag>();          
        }        

        #endregion

        public bool IsFull()
        {
            return m_RemainingEmptyBoxCount == 0;
        }

        public Ticket Store( Bag bag )
        {
            if ( IsFull() )
            {
                return null;
            }

            Ticket ticket = new Ticket();

            m_Box.Add(ticket,bag);

            m_RemainingEmptyBoxCount--;

            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (!m_Box.ContainsKey(ticket))
                return null;

            Bag returnBag = m_Box[ticket];
            
            m_Box.Remove(ticket);

            m_RemainingEmptyBoxCount++;

            return returnBag;
        }

        private int m_RemainingEmptyBoxCount;

        public int RemainingEmptyBoxCount
        {
            get { return m_RemainingEmptyBoxCount; }
        }

        private Dictionary<Ticket, Bag> m_Box;     
    }
}

