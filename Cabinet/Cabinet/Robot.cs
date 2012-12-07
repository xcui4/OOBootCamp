using System.Collections.Generic;

namespace CabinetSystem
{
    public class Robot
    {
        private readonly List<Cabinet> _cabinets;
        public void AddCabinet(Cabinet cabinet)
        {
            _cabinets.Add(cabinet);
        }

        public Robot()
        {
            _cabinets = new List<Cabinet>();
        }

        public bool HasEmptyBox
        {
            get
            {
                foreach (Cabinet cabinet in _cabinets)
                {
                    if (cabinet.HasEmptyBox)
                    {
                        return true;
                    }
                }
                return false;
            } 
        
        }

        public object Store(Bag bag)
        {
            foreach (Cabinet cabinet in _cabinets)
            {
                if (cabinet.HasEmptyBox)
                {
                    return cabinet.Store(bag);
                }
            }
            throw new NoBoxAvailableException("");
        }
    }
}