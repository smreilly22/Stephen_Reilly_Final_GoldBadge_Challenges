using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03_Badges
{
    [TestClass]
    public class UnitTest1
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();

        [TestInitialize]
        public void TestMethod1()
        {
            Badges badge1 = new Badges(new List<string> { "A6", "A8" });
            Badges badge2 = new Badges(new List<string> { "B5", "C7" });
            Badges badge3 = new Badges(new List<string> { "C4", "D5" });

            Dictionary<int, List<string>> badge4 = new Dictionary<int, List<string>>(1000, new List<string>);

            _badgeRepo.CreateDictionary(badge1);
            _badgeRepo.CreateDictionary(badge2);
            _badgeRepo.CreateDictionary(badge3);
        }
        [TestMethod]
        public void AddTest()
        {
            Badges newBadge = new Badges(new List<string> { "E4", "E5" });
            bool addResult = _badgeRepo.CreateDictionary(newBadge);

            Assert.IsTrue(addResult);
            Assert.IsTrue(_badgeRepo.GetAllBadges()[1003].Contains("E4"));
            

        }
        [TestMethod]
        public void AddDoorTest()
        {
            Badges existingBadge = new Badges(new List<string> { "A6", "A8" });
            bool updateDoor = _badgeRepo.AddDoorToBadge("A5", 1000);

            Assert.AreNotEqual(updateDoor, existingBadge);

        }

        [TestMethod]
        public void RemoveDoorTest()
        {
            Badges existingBadge = new Badges(new List<string> { "A6", "A8" });
            bool removeDoor = _badgeRepo.RemoveDoorFromBadge("A8", 1000);

            Assert.AreNotEqual(removeDoor, existingBadge);

        }
    }
}
