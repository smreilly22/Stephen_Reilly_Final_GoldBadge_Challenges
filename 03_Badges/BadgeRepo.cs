using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgeRepo
    {
      
        private Dictionary<int , List<string>> _badgeDictionary = new Dictionary<int , List<string>>();
        private int _badgeID = 1000;
   

        //Add to the Dictionary<>

        public bool CreateDictionary(List<string> doors)
        {
            int startingCount = _badgeDictionary.Count();
            
            _badgeDictionary.Add(_badgeID, doors);
            if(_badgeDictionary.Count > startingCount)
            {
                _badgeID++;
                return true;
            }
            return false;
            

        }

        


        //Read

        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeDictionary;
        }

        public List<string> GetBadgeDoorByID(int id)
        {
            return _badgeDictionary[id];
        }


        

        //Update

        public bool AddDoorToBadge(string door, int id)
        {
             var doors = _badgeDictionary[id];
            if (doors != null)
            {
                doors.Add(door);

                return true;
            }
            else
            {
                return false;
            }
        }

        //Remove
         public bool RemoveDoorFromBadge(string door, int id)
        {
            var doors = _badgeDictionary[id];
            if(doors != null)
            {
                doors.Remove(door);

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
