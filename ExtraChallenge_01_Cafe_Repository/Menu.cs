using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Challenges_01
{
    public class Menu
    {
        public Menu() { }

        public Menu(string menuName, string description, List<string> ingrediants, double price)
        {
            MenuName = menuName;
            
            Description = description;
            Ingredients = ingrediants;
            Price = price;
        }

        public string MenuName { get; set; }

        public int MenuNumber { get; set; }

        public string Description { get; set; }

        public List<string> Ingredients { get; set; } = new List<string>();

        public double Price { get; set; }

    }
}
