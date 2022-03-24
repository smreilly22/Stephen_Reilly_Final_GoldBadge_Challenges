using _05_Grettings_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _06_Green_Plan_Challenge
{
    [TestClass]
    
        
    public class GreenPlanRepoTest1
    {

            private GreenPlanRepo _greenRepo = new GreenPlanRepo();




            [TestInitialize]
        public void Arrange()
        {
                GreenPlan car1 = new GreenPlan(GreenPlan.CarType.Gas,"Honda", "Accord");
                GreenPlan car2 = new GreenPlan(GreenPlan.CarType.Hybrid, "Ford", "Fussion");
                GreenPlan car3 = new GreenPlan(GreenPlan.CarType.Electric, "Telsa", "Model-X");

                _greenRepo.AddCarToList(car1);
            _greenRepo.AddCarToList(car2);
            _greenRepo.AddCarToList(car3);

            




        }
        [TestMethod]
        public void ShouldAddTest()
        {
            GreenPlan car4 = new GreenPlan(GreenPlan.CarType.Electric, "Volkswagen", "Passat");
            bool addResult = _greenRepo.AddCarToList(car4);

            Assert.IsTrue(addResult);
            Assert.IsTrue(_greenRepo.AddCarToList(car4));

        }

        [TestMethod]
        public void ShouldDisplayTest()
        {
            GreenPlan car = new GreenPlan();

            GreenPlanRepo repo = new GreenPlanRepo();

            repo.AddCarToList(car);

            List<GreenPlan> carList = repo.GetAllPlans();

            bool repoHasCar = carList.Contains(car);

            Assert.IsTrue(repoHasCar);

        }

        [TestMethod]
        public void ShouldUpdateTest()
        {
            GreenPlan updateGreenPlan = new GreenPlan(GreenPlan.CarType.Gas, "Volkswagen", "Passat");
            bool updateREsult = _greenRepo.UpdateCarPlan(updateGreenPlan, 4);
            Assert.AreNotEqual(updateREsult, updateGreenPlan);
        }
        [TestMethod]
        public void RemoveTest()
        {
            GreenPlan car = new GreenPlan(GreenPlan.CarType.Hybrid, "Ford", "MegaEngine");
            _greenRepo.AddCarToList(car);

            Assert.IsTrue(_greenRepo.RemovePlan(car));
            Assert.IsFalse(_greenRepo.GetAllPlans().Contains(car));
        }
    }
    

}
