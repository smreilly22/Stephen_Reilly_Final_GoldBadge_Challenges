using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Green_Plan_Challenge
{
    public class GreenPlan
    {
        public enum CarType { Hybrid, Electric, Gas}

        public GreenPlan() { }
        public GreenPlan(CarType carType, string make, string model)
        {
            Type = carType;
            Make = make;
            Model = model;
        }

        public int CarID { get; set; }


        public CarType Type { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string GetsIncentives
        {
            get
            {
                if(Type == CarType.Hybrid || Type == CarType.Electric)
                {
                    return "Gets the Green Incentives";
                }
                else
                {
                    return "No Incentives at this time";
                }
            }
        }
    }
}
