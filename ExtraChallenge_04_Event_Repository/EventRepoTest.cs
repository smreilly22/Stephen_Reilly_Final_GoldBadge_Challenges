using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class EventRepoTest

    {
        private EventRepo _repo = new EventRepo();

        [TestInitialize]
        public void Arrange()
        {
            Events event1 = new Events( Events.EventType.Concert, 78, new DateTime(2022, 01, 04), 30.50d);
            Events event2 = new Events(Events.EventType.Bowling, 25, new DateTime(2021, 12, 13), 10.50d);
            Events event3 = new Events(Events.EventType.AmusementPark, 60, new DateTime(2021, 08, 15), 20.30);
            Events event4 = new Events(Events.EventType.Golf, 2, new DateTime(2021, 10, 12), 40.50);

            _repo.AddToDirectory(event1);
            _repo.AddToDirectory(event2);
            _repo.AddToDirectory(event3);
            _repo.AddToDirectory(event4);

        }

        [TestMethod]
        public void AddEventTest()
        {
            Events newEvent = new Events();
            bool wasAdded = _repo.AddToDirectory(newEvent);

            Assert.IsTrue(wasAdded);
            Assert.IsTrue(_repo.AddToDirectory(newEvent));
        }
            

        
            [TestMethod]
       
        public void ShouldDisplayTest()
        {
            Events newEvent = new Events(Events.EventType.Bowling, 78, new DateTime(2022, 03, 04), 17.50);

            EventRepo eventRepo = new EventRepo();

            eventRepo.AddToDirectory(newEvent);
            List<Events> eventList = eventRepo.GetAllEvents();

            
            bool repoHasEvent = eventList.Contains(newEvent);
            

            Assert.IsTrue(repoHasEvent);
        }

       
    }
}
