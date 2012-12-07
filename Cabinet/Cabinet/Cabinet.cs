using System.Collections;

namespace CabinetSystem
{
    public class Cabinet
    {
        public Cabinet(int boxCapacity)
        {
            m_AvailableBoxCount = boxCapacity;
        }

        public bool HasEmptyBox
        {
            get { return m_AvailableBoxCount > 0; }
          
        }

        public Ticket Store(Bag bag)
        {
            if(m_AvailableBoxCount <= 0)
                throw new NoBoxAvailableException("No Box Available");
            var ticket = new Ticket(bag);
            m_bags.Add(ticket, bag);

            m_AvailableBoxCount--;
            return ticket;
        }

        private int m_AvailableBoxCount;

        public Bag Pick(Ticket myticket)
        {
            Bag returnedBag = null;
            if(m_bags.ContainsKey(myticket))
            {
                returnedBag = (Bag) m_bags[myticket];
                m_bags.Remove(myticket);
                m_AvailableBoxCount++;
                return returnedBag;

            }

            throw new WrongTicketException("Wrong Ticket");
        }

        private Hashtable m_bags = new Hashtable();
    }
}