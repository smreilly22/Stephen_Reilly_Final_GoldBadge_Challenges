using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Challenges_01
{
    public class MenuProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            SeedMenu();
            Menu();
        }
        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {

                Console.Clear();

                Console.WriteLine("Enter the number of the option you would like: \n" +
                    "1. Show the entire Menu List \n" +
                    "2. Show Basic List\n" +
                    "3. Add Item To Menu\n" +
                    "4. Remove Menu Item\n" + 
                    "5. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowMenuList();
                        break;
                    case "2":
                        ShowBasicMenuInfo();
                        break;
                    case "3":
                        AddItemToMenu();
                        break;
                    case "4":
                       RemoveMenuItem();
                        break;
                    case "5":
                    case "e":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 7.\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;
                        
                }
                    
            }

        }

        private void AddItemToMenu()
        {
            Console.Clear();
            Menu menu = new Menu();
            

            Console.Write("Please enter the name of the item: ");
            menu.MenuName = Console.ReadLine();

          
            Console.Write("Please enter the description of the item: ");
            menu.Description = Console.ReadLine();

            Console.Write("Please enter the price of the item: ");
            menu.Price = double.Parse(Console.ReadLine());


            Console.WriteLine("Please enter ingredient of item: ");
            string ingredientInput = Console.ReadLine();
            if (AddIngredianttoItem(ingredientInput))
            {
                if (AddIngredientLoop(ingredientInput))
                {
                    Console.WriteLine("You added ingredient");
                }
                else
                {
                    Console.WriteLine("Did not add");
                }
            }
            else
            {
                Console.WriteLine("No way, jose");
            }

            if (_menuRepo.AddItemToMenu(menu))
            {
                Console.WriteLine("Success! ");
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Did not Add. Press any key to contiue");
                Console.ReadKey();

            }


        }

        private void ShowMenuList()
        {
            Console.Clear();
            DisplayAllMenuItems();
            AnyKey();

        }

        private void ShowBasicMenuInfo()
        {
            Console.Clear();
            DisplayAllBasic();
            AnyKey();
        }

        private void RemoveMenuItem()
        {
            Console.Clear();

            List<Menu> menuItems = _menuRepo.GetMenuItems();
            int count = 0;
            

            foreach( var item in menuItems)
            {
                count++;
                Console.WriteLine($"{count:00}. {item.MenuName}");
            }

            Console.Write("What item number do you want to remove. Please enter the number: ");
            int menuNumber = int.Parse(Console.ReadLine());
            int index = menuNumber - 1;
            if(index >= 0 && index < menuItems.Count())
            {
                Menu deleteItem = menuItems[index];

                if (_menuRepo.RemoveItemFromMenu(deleteItem))
                {
                    Console.WriteLine($"{deleteItem.MenuName} is deleted successfully.");
                    AnyKey();
                }

                else
                {
                    Console.WriteLine("Did not delete item.");
                    AnyKey();
                }


            }
            else
            {
                Console.WriteLine("No item is assigned to that number");
            }

        }




        private void DisplayItemInfo(Menu menuList)
        {

           
                Console.WriteLine($" Item Number: #{menuList.MenuNumber}\n" +
                $" Item: {menuList.MenuName}\n" +
                $" Description: {menuList.Description}\n" +
                $" Price: ${menuList.Price}");
            Console.WriteLine(" Ingredients: ");
            foreach (var ingrediant in menuList.Ingredients)
            {
                
                Console.WriteLine($" {ingrediant}");
            }
            Console.WriteLine("");
        }

        private void DisplayBasicItemInfo(Menu menu)
        {
           
            Console.WriteLine( $" Item Number: #{menu.MenuNumber}\n" +
                $" Item Name: {menu.MenuName}\n" +
                $" Price: ${menu.Price}");
            Console.WriteLine("");
        }

        private void DisplayAllMenuItems()
        {
            List<Menu> listOfMenu = _menuRepo.GetMenuItems();
            foreach(var item in listOfMenu)
            {
                DisplayItemInfo(item);
            }
        }

        private void DisplayAllBasic()
        {
            List<Menu> listOfMenu = _menuRepo.GetMenuItems();
            foreach(var item in listOfMenu)
            {
                DisplayBasicItemInfo(item);
            }
        }

        private bool AddIngredianttoItem(string menuItem)
        {

            Console.WriteLine("What ingrediant would you like to add?");
            string ingredient = Console.ReadLine();
            return _menuRepo.AddIngrediantToMenuItem(ingredient, menuItem);

        }

        private bool AddIngredientLoop(string menuItem)
        {
            
                Console.WriteLine(" Do you want to add ingredient, Y or N:");
               
                bool goAgain = true;
                switch (Console.ReadLine().ToLower())
                {
                case "y":
                case "yes":
                    break;
                default:
                    goAgain = false;
                    break;
                }
            while (goAgain)
            {
                if (AddIngredianttoItem(menuItem))
                {
                    AddIngredientLoop(menuItem);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return true;
                
            
            
        }


        private void SeedMenu()
        {
            _menuRepo = new MenuRepo();
            Menu steakEggs = new Menu("Steak and Eggs", "A 6oz sirlon cooked the way you want it\n" +
                 " and eggs the way you want it", new List<string> { "6oz steak meat", "Grade eggs", "salt", "pepper",
                "butter" }, 1.5d);
            Menu footLong = new Menu("FootLong Hamburger", "A Hamburger that is a footlong with the ingrediants you want", new List<string> { "grind meat", "buns", "cheddar cheese", "lettuce", "tomato", "onion", "pickles" }, 2.54d);
            Menu wingsBoneless = new Menu("50 Boneless Wings", "A 50 boneless wing platter of the sauce of you choosing with \n" +
                "your choice of fries, onion rings lettuce", new List<string> { "Tyson chicken nuggets", "our secret 'spices'" }, 2.01);
            Menu mamasFrenchToast = new Menu("Mama's French Toast", "Homemade french toast that I stole from my mom \n" +
                "only one per day", new List<string> { "bread", "eggs", "milk", "cinnamon", "butter" }, 3.51d);
            Menu chefSurprise = new Menu("Chef Surprise", "Whatever the chef feels like making that day", new List<string> { "we", "don't", "know", "maybe", "'chicken'" }, 3.43d);
              
            Menu salad = new Menu("Our House Salad", "a salad containing one of everything", new List<string> { "a lettuce",
            "a tomato", "a piece of onion", "a carrot", "slice of cucumber", "spinanch"}, 20.50d);
            

            _menuRepo.AddItemToMenu(steakEggs);
            _menuRepo.AddItemToMenu(footLong);
            _menuRepo.AddItemToMenu(wingsBoneless);
            _menuRepo.AddItemToMenu(mamasFrenchToast);
            _menuRepo.AddItemToMenu(chefSurprise);
            _menuRepo.AddItemToMenu(salad);
           
                
        }

        private void AnyKey()
        {
            Console.WriteLine("Please press any key to continue.");
            Console.ReadKey();
        }
    }
}
