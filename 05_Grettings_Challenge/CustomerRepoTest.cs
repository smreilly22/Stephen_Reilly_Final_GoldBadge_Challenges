using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _05_Grettings_Challenge
{
    [TestClass]
    public class CustomerRepoTest
    {
        private new CustomerRepo _customerRepo = new CustomerRepo();


        [TestInitialize]


        public void Arrange()
        {
            Customers customer1 = new Customers("Stephen", "Reilly", Customers.CustomerType.Potential);
            Customers customer2 = new Customers("Hannah", "Smith", Customers.CustomerType.Current);
            Customers customer3 = new Customers("John", "Adams", Customers.CustomerType.Past);

            _customerRepo.AddCustomerToEmailList(customer1);
            _customerRepo.AddCustomerToEmailList(customer2);
            _customerRepo.AddCustomerToEmailList(customer3);

        }

        [TestMethod]
        public void AddTest()
        {
            Customers customers = new Customers("John", "Walter", Customers.CustomerType.Current);
            bool result = _customerRepo.AddCustomerToEmailList(customers);

            Assert.IsTrue(result);
            Assert.IsTrue(_customerRepo.AddCustomerToEmailList(customers));

        }

        [TestMethod]
        public void DisplayTest()
        {
            Customers customer = new Customers();
            CustomerRepo repo = new CustomerRepo();

            repo.AddCustomerToEmailList(customer);

            List<Customers> customers = repo.GetAllCustomers();

            bool repoHasCustomrs = customers.Contains(customer);

            Assert.IsTrue(repoHasCustomrs);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Customers updateCustomer = new Customers("Stephen", "Reilly", Customers.CustomerType.Past);

            bool updatedResult = _customerRepo.UpdateCustomer("Stephen", updateCustomer);

            Assert.AreNotEqual(updatedResult, updateCustomer);

        }

        [TestMethod]
        public void RemoveTest()
        {
            Customers customer = new Customers("Heath", "Miller", Customers.CustomerType.Past);
            _customerRepo.AddCustomerToEmailList(customer);

            

            Assert.IsTrue(_customerRepo.RemoveCustomer(customer));
            Assert.IsFalse(_customerRepo.GetAllCustomers().Contains(customer));
        }
    }
}
