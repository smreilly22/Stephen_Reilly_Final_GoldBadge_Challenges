using _05_Grettings_Challenge;
using _06_Green_Plan_Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlan_Console
{
    public class GreenPlanProgramUI
    {

        private GreenPlanRepo _greenRepo = new GreenPlanRepo();

        public void Run()
        {
            SeedContent();
            Menu();
        }
        public void Menu()
        {
            bool continueRun = true;

            while (continueRun)
            {
                Console.Clear();
                Console.WriteLine("Please enter a number: \n" +
                    "1. Display List \n" +
                    "2. Get Car By Type \n" +
                    "3. Add Car To List \n" +
                    "4. Update Car Info  \n" +
                    "5. Remove Car From List \n" +
                    "6. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        DisplayCarList();
                        break;
                    case "2":
                      GetCarByType();
                        break;
                    case "3":
                        AddCarToList();
                        break;
                    case "4":
                        UpdateCarInfo();
                        break;
                    case "5":
                        RemoveCarFromList();
                        break;
                    case "6":
                    case "e":
                        continueRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1-7.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void DisplayCarList()
        {
            Console.Clear();
            DisplayAllCars();
            Anykey();


        }

        //GetCarByType

        private void GetCarByType()
        {
            Console.Clear();
            
            GreenPlan.CarType car = new GreenPlan.CarType();
            Console.WriteLine("Please enter the Car Type you Like to see: \n" +
                "1. Hybrid \n" +
                "2. Electric \n" +
                "3. Gas ");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    car = GreenPlan.CarType.Hybrid;
                    break;
                case "2":
                    car = GreenPlan.CarType.Electric;
                    break;
                case "3":
                    car = GreenPlan.CarType.Gas;
                    break;

            }
            List<GreenPlan> list = _greenRepo.GetPlanByCarType(car);
            foreach(GreenPlan cars in list)
            {
                DisplayCarInfo(cars);
            }
            Anykey();
        }

        

        //AddCarToList

        private void AddCarToList()
        {
            Console.Clear();
            GreenPlan car = new GreenPlan();

            Console.WriteLine("Please enter the type of car: \n" +
                "1. Hybrid \n" +
                "2. Electric \n" +
                "3. Gas");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    car.Type = GreenPlan.CarType.Hybrid;
                    break;
                case "2":
                    car.Type = GreenPlan.CarType.Electric;
                    break;
                case "3":
                    car.Type = GreenPlan.CarType.Gas;
                    break;


            }

            Console.WriteLine("Please enter the make of car: ");
            car.Make = Console.ReadLine();

            Console.WriteLine("Please enter the model of car: ");
            car.Model = Console.ReadLine();

            if (_greenRepo.AddCarToList(car))
            {
                Console.WriteLine("You have successfully added car!");
            }
            else
            {
                Console.WriteLine("Did not add car");
            }
            Anykey();
        }

        //UpdateCarInfo

        private void UpdateCarInfo()
        {
            Console.Clear();
            Console.WriteLine("Update Car");
            DisplayAllCars();
            
            Console.WriteLine("Please enter CarID: ");
            int id = Int32.Parse(Console.ReadLine());
            Console.Clear();
            GreenPlan newCar = new GreenPlan();
            Console.WriteLine("Please enter the type of car: \n" +
                "1. Hybrid \n" +
                "2. Electric \n" +
                "3. Gas");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    newCar.Type = GreenPlan.CarType.Hybrid;
                    break;
                case "2":
                    newCar.Type = GreenPlan.CarType.Electric;
                    break;
                case "3":
                    newCar.Type = GreenPlan.CarType.Gas;
                    break;


            }
            Console.WriteLine("Please enter Make: ");
            newCar.Make = Console.ReadLine();

            Console.WriteLine("Please enter Model: ");
            newCar.Model = Console.ReadLine();

            if(_greenRepo.UpdateCarPlan(newCar, id))
            {
                Console.WriteLine("Successfully Updated");
            }
            else
            {
                Console.WriteLine("Did not Update");
            }
            Anykey();
        }

        //RemoveCarFromList

        private void RemoveCarFromList()
        {
            Console.Clear();
            DisplayAllCars();

            Console.WriteLine("Which car plan you like to remove?");
            Console.Write("Car ID: ");
            
            int targetID = Int32.Parse(Console.ReadLine());
            GreenPlan carDelete = _greenRepo.GetPlanByID(targetID);
            if (carDelete != null)
            {
                Console.WriteLine("Do you want to remove car: Y or N?");
                string userInput = Console.ReadLine();


                switch (userInput)
                {
                    case "Y":
                    case "y":
                    case "yes":
                        if (_greenRepo.RemovePlan(carDelete))
                        {
                            Console.WriteLine($"{carDelete.CarID} is deleted from list");

                        }
                        break;
                    case "N":
                    case "n":
                    case "no":
                        Console.WriteLine("Did not delete plan");
                        break;


                }
            }
            else
            {
                Console.WriteLine("Not a valid Id");
            }

            
            
                
            
            
            Anykey();
        }


        private void DisplayCarInfo(GreenPlan car)
        {
            Console.WriteLine($" CarID: {car.CarID} \n" +
                $" Car Make: {car.Make} \n" +
                $" Car Model: {car.Model} \n" +
                $" Car type: {car.Type} \n" +
                $" Car Incentives: {car.GetsIncentives} ");
            Console.WriteLine("");
        }

        private void DisplayAllCars()
        {
            List<GreenPlan> carList = _greenRepo.GetAllPlans();
            foreach(GreenPlan car in carList)
            {
                DisplayCarInfo(car);
            }
        }

        private void Anykey()
        {
            Console.WriteLine("Please press any key to continue");
            Console.ReadKey();
        }

        private void SeedContent()
        {
            GreenPlan car1 = new GreenPlan(GreenPlan.CarType.Gas, "Ford", "Edge");
            GreenPlan car2 = new GreenPlan(GreenPlan.CarType.Electric, "Telsa", "Model-X");
            GreenPlan car3 = new GreenPlan(GreenPlan.CarType.Hybrid, "Ford", "Fussion");

            _greenRepo.AddCarToList(car1);
            _greenRepo.AddCarToList(car2);
            _greenRepo.AddCarToList(car3);

        }



    }
}
