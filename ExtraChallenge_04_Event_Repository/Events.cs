using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class Events
    {
        public enum EventType { Bowling, Concert, AmusementPark, Golf }
        
        public Events() { }

        public Events(EventType type, int numberOfPeople, DateTime date, double totalPerPerson) 
        { 

            Type = type;
            NumberOfPeople = numberOfPeople;
            Date = date;
            TotalPerPerson = totalPerPerson;

        }

        public int EventID { get; set; }

        public EventType Type { get; set; }

        public int NumberOfPeople { get; set; }

        public DateTime Date { get; set; }

        public double TotalPerPerson { get; set; }

        public double TotalCostEvent
        {
            get
            {
                return NumberOfPeople * TotalPerPerson;
            }
        }




    }
}
