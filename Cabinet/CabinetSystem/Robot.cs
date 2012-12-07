using System.Collections.Generic;
using CabinetSystem;

namespace CabinetSystem
{
    public class Robot
    {
        public Robot()
        {
            m_Cabinets = new List<Cabinet>();
        }

        public Robot( List<Cabinet> cabinetList)
        {
            m_Cabinets = cabinetList;
        }

        public Ticket Store(Bag bag)
        {
            foreach(Cabinet cabinet in m_Cabinets)
            {
                if (!cabinet.IsFull())
                {
                    return cabinet.Store(bag);
                }
            }
            return null;
        }

        private List<Cabinet> m_Cabinets;

        public Bag Pick(Ticket ticket)
        {
            Bag targetBag = null;
            foreach (var cabinet in m_Cabinets)
            {
                var bag = cabinet.Pick(ticket);
                if (bag != null)
                {
                    targetBag = bag;
                    break;
                }
            }

            if (targetBag == null)
                throw new InvalidTicketException("Invalid Ticket");
            return targetBag;
        }

    }
}