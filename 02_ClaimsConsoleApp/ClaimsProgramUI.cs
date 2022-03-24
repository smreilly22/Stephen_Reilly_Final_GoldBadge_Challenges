using Claims_Challenge;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsConsoleApp
{
    public class ClaimsProgramUI
    {
        private ClaimRepo _claimsRepo = new ClaimRepo();

        public void Run()
        {
            SeedClaims();
            Menu();
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Please enter the number of the option you would like to select: \n" +
                    "1. See All Claims \n" +
                    "2. Take Care Of Claim \n" +
                    "3. Enter A New Claim \n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfClaim();
                        break;
                    case "3":
                        EnterANewClaim();
                        break;
                    case "4":
                    case "e":
                        continueToRun = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number between 1-3.");
                        Console.ReadKey();
                        break;
                        
                }


            }
        }

        //SeeAllClaims
        private void SeeAllClaims()
        {
            Console.Clear();
            DispalyHeader();
            DisplayAllClaims();
            AnyKey();
        }

        //TakeCareOfClaims

        private void TakeCareOfClaim()
        {
            Console.Clear();
            DispalyHeader();
            DisplayAllClaims();
            Console.Write("Please enter ClaimID: ");
            string id = Console.ReadLine();
            Claims claim = _claimsRepo.GetClaimByID(Int32.Parse(id));

            if(claim != null)
            {
                DisplayAClaim(claim);
            
            

                Console.WriteLine("Do you want to remove claim? Press Y or N:  ");
                string input = Console.ReadLine();

            
                switch (input)
                {
                    case "Y":
                    case "y":
                    case "yes":
                        _claimsRepo.RemoveClaim(claim);
                        Console.WriteLine("Successfully deleted claim.");
                        AnyKey();
                            
                        break;
                    case "N":
                    case "n":
                    case "no":
                        AnyKey();
                        break;
                    default:
                        Console.WriteLine("Please enter Y or N");
                        break;
                }
                
            }
            else
            {
                Console.WriteLine("There is no claimID by that number.");
                AnyKey();
            }



        }

        //EnterANewClaim

        private void EnterANewClaim()
        {
            Console.Clear();

            Claims claim = new Claims();

            Console.WriteLine("Enter Claim Type: \n" +
                "1.Car \n" +
                "2.House \n" +
                "3.Theft");
            string claimType = Console.ReadLine();
            switch (claimType)
            {
                case "1":
                    claim.Type = Claims.ClaimTypes.Car;
                    break;
                case "2":
                    claim.Type = Claims.ClaimTypes.House;
                    break;
                case "3":
                    claim.Type = Claims.ClaimTypes.Theft;
                    break;
            }

            Console.WriteLine("Enter Description: ");
            claim.Description = Console.ReadLine();

            Console.WriteLine("Enter Amount: ");
            claim.Amount = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Date Of Incident(yyyy/mm/dd): ");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter Date Of Claim(yyyy/mm/dd: ");
            claim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter if claim was within a month of incident( true or false): ");

            switch (Console.ReadLine().ToLower())
            {
                case "true":
                case "yes":
                    Console.WriteLine("This claim is valid");
                    break;

                case "false":
                case "no":
                    Console.WriteLine("Did not put in the claim on time.");
                     break;
            }

            if (_claimsRepo.AddClaim(claim))
            {

                Console.WriteLine("Added to report was a success.");
                AnyKey();

            }

            else
            {
                Console.WriteLine("Did not add to report");
                AnyKey();
            }
        }

        private void DispalyHeader()
        {
            Console.WriteLine(String.Format("{0, -10} {1,-10}  {2,0} {3, 8} {4, 16} {5, 12} {6, 8} ", "ClaimID", "ClaimType", "Description", "Amount", "DateOfIncident", "DateOfClaim", "IsValid"));
            Console.WriteLine("");
        }

        //DisplayClaim
        private void DisplayClaim(Claims claim)
        {
            
            
            Console.WriteLine(String.Format("{0, -10} {1,-10}  {2,0} {3, 8} {4, 16} {5, 12} {6, 8}", (claim.ClaimID), (claim.Type), (claim.Description), (claim.Amount), (claim.DateOfIncident.ToShortDateString()), (claim.DateOfClaim.ToShortDateString()), (claim.IsValid)));
            Console.WriteLine("");

        }

        //DisplayAllClaims
        private void DisplayAllClaims()
        {
            List<Claims> claimsTable = _claimsRepo.GetAllClaims();
            foreach(Claims claims in claimsTable)
            {
                
             
                DisplayClaim(claims);
            }

        }

        //DisplayAClaim

        private void DisplayAClaim(Claims claim)
        {
            Console.WriteLine($"ClaimID: {claim.ClaimID} \n" +
                $"Type: {claim.Type} \n" +
                $"Description: {claim.Description} \n" +
                $"Amount: ${claim.Amount} \n" +
                $"DateOfAccident: {claim.DateOfIncident} \n" +
                $"DateOfClaim: {claim.DateOfClaim} \n" +
                $"IsValid: {claim.IsValid}");
        }

        //AnyKey
        private void AnyKey()
        {
            
            Console.WriteLine("Please press any key to continue");
            Console.ReadKey();
        }

        //SeedClaims

        private void SeedClaims()
        {
            Claims claims1 = new Claims( Claims.ClaimTypes.Theft, "Stolen Couch", 230.23d, new DateTime(2015, 05, 10), new DateTime(2015, 06, 05), true);
            Claims claims2 = new Claims( Claims.ClaimTypes.House, "House Fire", 400.09d, new DateTime(2018, 07, 02), new DateTime(2018, 09, 23), false);
            Claims claims3 = new Claims( Claims.ClaimTypes.Car, "Steering Gone", 500.08d, new DateTime(2020, 08, 06), new DateTime(2020, 08, 07), true);
            Claims claims4 = new Claims( Claims.ClaimTypes.House, "Broken Door", 200.07d, new DateTime(2021, 07, 04), new DateTime(2021, 09, 07), false);

            _claimsRepo.AddClaim(claims1);
            _claimsRepo.AddClaim(claims2);
            _claimsRepo.AddClaim(claims3);
            _claimsRepo.AddClaim(claims4);
        }
    }
}
