using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class EventRepo
    {
        
        private List<Events> _eventRepo = new List<Events>();
        private int _eventID = 1;
        

        //Create

        public bool AddToDirectory(Events events)
        {
            int startingCount = _eventRepo.Count();
            events.EventID = _eventID;
            _eventRepo.Add(events);

            if(_eventRepo.Count() > startingCount)
            {
                _eventID++;
                return true;
            }
            else
            {
                return false;
            }

        }

        //Read

        public List<Events> GetAllEvents()
        {
            return _eventRepo;
        }

        public List<Events> GetEventByType(Events.EventType eventType)
        {
            return _eventRepo.Where(d => d.Type == eventType).ToList();
        }

        //Update
        

        //Remove


    }
}
