using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Grettings_Challenge
{
    public class Customers
    {
        public enum CustomerType { Potential, Current, Past }

        public Customers() { }

        public Customers(string firstName, string lastName, CustomerType type) 
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
            
        }

        public CustomerType Type { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email 
        {
            get
            {
                if (Type == CustomerType.Current)
                {
                    return "Thank you for being a customer! Have a coupon!";
                }
                else if (Type == CustomerType.Past)
                {
                    return "We miss you! Hope you are doing well! We have a lot of great things happening";

                }
                else
                {
                    return "Hi! We have the lowest insurance rates out there! Contact us for more information";
                }
            }
        }



       



    }
}
