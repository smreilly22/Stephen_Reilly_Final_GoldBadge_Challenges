using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Challenge
{
    
    public class Claims
    {
        public enum ClaimTypes { Car, House, Theft };

        public Claims() { }

        public Claims( ClaimTypes types, string description, double amount, DateTime dateOfIncident , DateTime dateOfClaim, bool isValid)
        {
            

            Type = types;

            Description = description;

            Amount = amount;

            DateOfIncident = dateOfIncident.Date;

            DateOfClaim = dateOfClaim.Date;

            IsValid = isValid;

        }
        
        
        public int ClaimID { get; set; }

        public ClaimTypes Type { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public DateTime DateOfIncident { get; set; }

        public DateTime DateOfClaim { get; set; }

        public bool IsValid { get; set; }
       
        


       

    }
}
