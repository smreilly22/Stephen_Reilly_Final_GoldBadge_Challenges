using _03_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesConsole
{
    public class BadgesUi
    {

        private BadgeRepo _badgeRepo = new BadgeRepo();


        public void Run()
        {
            SeedBadges();
            Menu();
        }

        public void Menu()
        {
            bool continuetoRun = true;
            while (continuetoRun)
            {
                Console.Clear();

                Console.WriteLine("Please enter the number: \n" +
                    "1. List All Badges \n" +
                    "2. Add A Badge \n" +
                    "3. Update A Badge \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ListAllBadges();
                        break;
                    case "2":
                        //AddABadge();
                        break;
                    case "3":
                        //UpdageABadge();
                        break;
                    case "4":
                    case "e":
                        continuetoRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1-3");
                        break;
                        
                }

            }
        }

        private void ListAllBadges()
        {
            DisplayAllBadge();
        }
        
        private void DisplayBadgeInfo()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.GetAllBadges();
            foreach (var badge in badgeDictionary)
            {
                
            }

        }
        private void DisplayAllBadge()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.GetAllBadges();
            foreach ( KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                Console.WriteLine("Key = {0}, Value = {1}", badge.Key, badge.Value);
            }

        }
        private void AnyKey()
        {
            Console.WriteLine("Please press any button to continue");
            Console.Clear();
        }

        private void SeedBadges()
        {
            Badges badge1 = new Badges(new List<string> { "A6", "A8" });
            Badges badge2 = new Badges(new List<string> { "B5", "C7" });
            Badges badge3 = new Badges(new List<string> { "C4", "D5" });

            _badgeRepo.CreateDictionary(badge1);
            _badgeRepo.CreateDictionary(badge2);
            _badgeRepo.CreateDictionary(badge3);
        }

    }
}
