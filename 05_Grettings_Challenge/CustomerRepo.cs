using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Grettings_Challenge
{
    public class CustomerRepo
    {

        private List<Customers> _customerDirectory = new List<Customers>();

        //Add

        public bool AddCustomerToEmailList(Customers customer)
        {
            int startingCount = _customerDirectory.Count;
            _customerDirectory.Add(customer);

            if(_customerDirectory.Count() > startingCount)
            {
                return true;
            }
            return false;
        }



        //Read

        public List<Customers> GetAllCustomers()
        {
            return _customerDirectory;
        }

        public Customers GetCustomerByName( string name)
        {
            return _customerDirectory.Where(d => d.FullName == name).SingleOrDefault();
        }

        public List<Customers> GetByCustomerType(Customers.CustomerType customer)
        {
            return _customerDirectory.Where(d => d.Type == customer).ToList();
        }



        //Update

        public bool UpdateCustomer(string originalName, Customers newCustomer)
        {
            Customers oldCustomer = GetCustomerByName(originalName);
            if(oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.Type = newCustomer.Type;
                

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete

        public bool RemoveCustomer(Customers existingCustomer)
        {
            bool deleteCustomer = _customerDirectory.Remove(existingCustomer);
            return deleteCustomer;
        }
        

    }

    
}
