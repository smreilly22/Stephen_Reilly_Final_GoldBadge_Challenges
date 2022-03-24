using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1;

namespace _04_Event_Console
{
    public class EventProgramUI
    {

        private EventRepo _eventRepo = new EventRepo();

        public void Run()
        {

            SeedContent();
            Menu();

        }

        public void Menu()
        {
            bool continueToRun = true;

            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please enter a number: \n" +
                    "1. Display All Events \n" +
                    "2. Display Events By Cost \n" +
                    "3. Display Total Cost Of All Events \n" +
                    "4. Add Event \n" +
                    "5. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayEvents();
                        break;
                    case "2":
                        DisplayEventCost();
                        break;
                    case "3":
                        DisplayTotalCost();
                        break;
                    case "4":
                        AddEventToList();
                        break;
                    case "5":
                    case "e":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1-4");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void DisplayEvents()
        {
            DisplayAllEvents();
            AnyKey();
        }

        private void DisplayEventCost()
        {
            Console.Clear();

            Events.EventType eventType = new Events.EventType();
            Console.WriteLine("Please enter the type of event: \n" +
                "1. Amusement park \n" +
                "2. Bowling \n" +
                "3. Concert \n" +
                "4. Golf");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    eventType = Events.EventType.AmusementPark;
                    break;
                case "2":
                    eventType = Events.EventType.Bowling;
                    break;
                case "3":
                    eventType = Events.EventType.Concert;
                    break;
                case "4":
                    eventType = Events.EventType.Golf;
                    break;
            }

            List<Events> eventList = _eventRepo.GetEventByType(eventType);
            foreach(Events events in eventList)
            {
                TypeCost(events);
            }
            AnyKey();
        }

        private void DisplayTotalCost()
        {
            CostInfor();
            AnyKey();
        }

        private void AddEventToList()
        {
            Console.Clear();
            Events newEvent = new Events();

            Console.WriteLine("Please enter the type of event: \n" +
                "1. Amusement park \n" +
                "2. Bowling \n" +
                "3. Concert \n" +
                "4. Golf");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    newEvent.Type = Events.EventType.AmusementPark;
                    break;
                case "2":
                    newEvent.Type = Events.EventType.Bowling;
                    break;
                case "3":
                    newEvent.Type = Events.EventType.Concert;
                    break;
                case "4":
                    newEvent.Type = Events.EventType.Golf;
                    break;
            }

            Console.WriteLine("Please date of event(yyyy/mm/dd): ");
            newEvent.Date = Convert.ToDateTime(Console.ReadLine());


            Console.WriteLine("Please enter the Number Of People attending: ");
            newEvent.NumberOfPeople = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the Total Cost Per Person: ");
            newEvent.TotalPerPerson = double.Parse(Console.ReadLine());

            if (_eventRepo.AddToDirectory(newEvent))
            {
                Console.WriteLine("Event added successfully!");
            }
            else
            {
                Console.WriteLine("Not add event");
            }
            AnyKey();

            


        }

        

        private void DisplayEventInfo(Events events)
        {
            Console.WriteLine($" EventID: {events.EventID} " +
                $" Event: {events.Type} \n" +
                $" Number Of People: {events.NumberOfPeople} \n" +
                $" Date: {events.Date.ToShortDateString()} \n" +
                $" Cost Per Person: ${events.TotalPerPerson} \n" +
                $" Total Cost of Event: ${events.TotalCostEvent} ");
            Console.WriteLine("");
        }

        private void CostInfor()
        {
            double revenue = 0;
            List<Events> eventLIst = _eventRepo.GetAllEvents();
            foreach(Events events in eventLIst)
            {
                revenue += events.TotalCostEvent;
            }
            Console.WriteLine($"Total cost of all events is ${revenue} \n" +
                $"From {eventLIst.Count()}");
        }

        private void IndividualCost()
        {
            
            double revenue = 0;
            List<Events> eventList = _eventRepo.GetAllEvents();
            foreach(Events events in eventList)
            {
                revenue = events.TotalCostEvent;
                Console.WriteLine($"The total cost of {events.Type} is ${revenue}.");
            }
        }

        private void TypeCost(Events eventType)
        {
            Console.WriteLine($" EventType: {eventType.Type} \n" +
                $" TotalCost: {eventType.TotalCostEvent}");

        }

        private void DisplayAllEvents()
        {
            List<Events> eventList = _eventRepo.GetAllEvents();
            foreach(Events events in eventList)
            {
                DisplayEventInfo(events);
            }
        }



        private void AnyKey()
        {
            Console.WriteLine("Please press any key to continue");
            Console.ReadKey();
        }

        private void SeedContent()
        {
            Events event1 = new Events(Events.EventType.Concert, 45, new DateTime(2021, 11, 13), 35.50);
            Events event2 = new Events(Events.EventType.Bowling, 20, new DateTime(2022, 01, 06), 10.50);
            Events event3 = new Events(Events.EventType.Golf, 10, new DateTime(2021, 10, 11), 25.50);
            Events event4 = new Events(Events.EventType.AmusementPark, 25, new DateTime(2021, 08, 11), 40.50);
            

            _eventRepo.AddToDirectory(event4);
            _eventRepo.AddToDirectory(event3);
            _eventRepo.AddToDirectory(event2);
            _eventRepo.AddToDirectory(event1);

            
        }

    }
}
