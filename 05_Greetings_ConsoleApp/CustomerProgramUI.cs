using _05_Grettings_Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greetings_ConsoleApp
{
    public class CustomerProgramUI
    {

        private CustomerRepo _repo = new CustomerRepo();

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
                    "1. DisplayAllCustomers \n" +
                    "2. AddCustomer \n" +
                    "3. UpdateCusomter \n" +
                    "4. RemoveCustomer \n" +
                    "5. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayAllCustomers();
                        break;
                    case "2":
                        AddCustomer();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        RemoveCustomer();
                        break;
                    case "5":
                    case "e":
                        continueRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1-4");
                        Console.ReadKey();
                        break;
                }
            }



        }

        //AddCustomer

        private void AddCustomer()
        {
            Console.Clear();

            Customers customer = new Customers();

            Console.Write("Please enter First Name: ");
            customer.FirstName = Console.ReadLine();

            Console.Write("Please enter Last name:  ");
            customer.LastName = Console.ReadLine();

            Console.WriteLine("Please enter Customer type: \n" +
                "1. Potential \n" +
                "2. Current \n" +
                "3. Past");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    customer.Type = Customers.CustomerType.Potential;
                    break;
                case "2":
                    customer.Type = Customers.CustomerType.Current;
                    break;
                case "3":
                    customer.Type = Customers.CustomerType.Past;
                    break;


            }
            if (_repo.AddCustomerToEmailList(customer))
            {
                Console.WriteLine("You have added Customer to List!");
                
            }
            else
            {
                Console.WriteLine("Did not add Customer");
            }
            AnyKey();
            
        }

        //DispalyAllCustomers
        private void DisplayAllCustomers()
        {
            Console.Clear();
            DisplayHeader();
            DisplayAllCustomersInfo();
            AnyKey();

        }

       //UpdateCustomer

        private void UpdateCustomer()
        {
            Console.Clear();

            DisplayAllCustomers();

            Console.WriteLine("Pleae enter Full Name of Customer you like to update: ");
            string name = Console.ReadLine();

            Console.Clear();
            Customers existingCustomer = new Customers();
            if(existingCustomer != null)
            {


                Console.Write("Enter the First Name: ");
                string nameInput = Console.ReadLine();
                if(nameInput != "")
                {
                    existingCustomer.FirstName = nameInput;
                }

                Console.Write("Enter the Last Name: ");
                string lastInput = Console.ReadLine();
                if(lastInput != "")
                {
                    existingCustomer.LastName = lastInput;
                }

                Console.WriteLine("Enter Customer Type: \n" +
                    "1. Potential \n" +
                    "2. Current \n" +
                    "3. Past");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        existingCustomer.Type = Customers.CustomerType.Potential;
                        break;
                    case "2":
                        existingCustomer.Type = Customers.CustomerType.Current;
                        break;
                    case "3":
                        existingCustomer.Type = Customers.CustomerType.Past;
                        break;

                }
                if(_repo.UpdateCustomer(name, existingCustomer))
                {
                    Console.WriteLine("Successfully updated!");
                }
                else
                {
                    Console.WriteLine("Did not updated");
                }
                
            }
            else
            {
                Console.WriteLine("No customer by that name found");
            }

            AnyKey();

            

        }

        //RemoveCustomer
        private void RemoveCustomer()
        {
            Console.Clear();
            DisplayAllCustomers();

            Console.WriteLine("Please enter Full Name you like to remove: ");
            string name = Console.ReadLine();
            Customers customer = _repo.GetCustomerByName(name);
            
            if(customer != null)
            {
                DisplayCustomerInfo(customer);

                Console.WriteLine("Do you want to remove customer? Press Y or N");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "y":
                    case "Y":
                    case "yes":
                        _repo.RemoveCustomer(customer);
                        Console.WriteLine($"You successfully removed {customer.FullName}");
                        AnyKey();
                        break;
                    case "n":
                    case "N":
                    case "no":
                        Console.WriteLine("Did not remove customer");
                        AnyKey();
                        break;
                    default:
                        Console.WriteLine("Please enter Y or N");
                        break;

                }

            }
            else
            {
                Console.WriteLine("Not a valid customer");
                AnyKey();
            }
        }

        private void DisplayHeader()
        {
            Console.WriteLine(String.Format("{0, -10} {1, -10} {2, -10} {3, 10}", "FirstName", "LastName", "CustomerType", "Email"));
            Console.WriteLine("");
        }


        private void DisplayCustomerInfo(Customers customer)
        {
            
            Console.WriteLine(String.Format("{0, -10} {1, -10} {2, -10} {3, 10}", (customer.FirstName), (customer.LastName), (customer.Type), (customer.Email)));
            Console.WriteLine("");
            

        }

        private void DisplayAllCustomersInfo()
        {
            List<Customers> customerList = _repo.GetAllCustomers();
            foreach(Customers customers in customerList)
            {
                
                DisplayCustomerInfo(customers);
            }
            
        }

        private void AnyKey()
        {
            Console.WriteLine("Please press any key to continue.");
            Console.ReadKey();
        }

        private void SeedContent()
        {
            Customers customer1 = new Customers("Ryan", "May", Customers.CustomerType.Current);
            Customers customer2 = new Customers("John", "Molehill", Customers.CustomerType.Past);
            Customers customer3 = new Customers("Dennis", "Tooley", Customers.CustomerType.Potential);

            _repo.AddCustomerToEmailList(customer1);
            _repo.AddCustomerToEmailList(customer2);
            _repo.AddCustomerToEmailList(customer3);
        }
    }
}
