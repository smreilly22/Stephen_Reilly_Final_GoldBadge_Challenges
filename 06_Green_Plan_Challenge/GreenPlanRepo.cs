using _06_Green_Plan_Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _06_Green_Plan_Challenge.GreenPlan;

namespace _05_Grettings_Challenge
{
    public class GreenPlanRepo
    {
        private List<GreenPlan> _greenRepo = new List<GreenPlan>();

        private int _id = 1;
        //Create

        public bool AddCarToList(GreenPlan greenPlan)
        {
            int startingCount = _greenRepo.Count;
            greenPlan.CarID = _id;
            _greenRepo.Add(greenPlan);

            if(_greenRepo.Count() > startingCount)
            {
                _id++;
                return true;
            }
            return false;


        }


        //Read

        public List<GreenPlan> GetAllPlans()
        {
            return _greenRepo;
        }

        public GreenPlan GetCarByMake(string make)
        {
            return _greenRepo.Where(d => d.Make == make).SingleOrDefault();
        }

        //Read CarType

        public List<GreenPlan> GetPlanByCarType(CarType carType)
        {
            return _greenRepo.Where(d => d.Type == carType).ToList();
        }

        public GreenPlan GetPlanByID(int id)
        {
            return _greenRepo.Where(d => d.CarID == id).SingleOrDefault();
        }

        //Update


        public bool UpdateCarPlan(GreenPlan newPlan, int id)
        {
            GreenPlan oldPlan = GetPlanByID(id);
            if(oldPlan != null)
            {
                if(newPlan.Make != null)
                {   
                    oldPlan.Make = newPlan.Make;
                }
                if(newPlan.Model != null)
                {
                    oldPlan.Model = newPlan.Model;
                }
                oldPlan.Type = newPlan.Type;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Remove

        public bool RemovePlan(GreenPlan existingPlan)
        {
            bool deletePlan = _greenRepo.Remove(existingPlan);
            return deletePlan;
        }
    }
}
