using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabinetSystem
{
    public class SmartRobot
    {
        private List<Cabinet> m_Cabinets;

        public SmartRobot(List<Cabinet> cabinets)
        {
            this.m_Cabinets = cabinets;
        }

        public Ticket Store(Bag bag)
        {
            var cabinet = GetCabinetWithMostEmptyBoxes();

            if (cabinet != null)
            {
                return cabinet.Store(bag);
            }

            return null;
        }

        private Cabinet GetCabinetWithMostEmptyBoxes()
        {
            Cabinet interestedCabinet = null;
            int maxRoomCabinetCount = 0;

            foreach (var cabinet in m_Cabinets)
            {
                if (cabinet.RemainingEmptyBoxCount > maxRoomCabinetCount)
                {
                    interestedCabinet = cabinet;
                    maxRoomCabinetCount = cabinet.RemainingEmptyBoxCount;
                }
            }

            return interestedCabinet;
        }

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
