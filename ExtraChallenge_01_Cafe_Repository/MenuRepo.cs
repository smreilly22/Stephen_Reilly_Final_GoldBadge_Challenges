using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Challenges_01
{
    public class MenuRepo
    {
        private List<Menu> _menuList = new List<Menu>();
        private int _menuID = 1;

        //Add to Menu

        public bool AddItemToMenu(Menu menuItem)
        {
            int startingCount = _menuList.Count;
            menuItem.MenuNumber = _menuID;
            _menuList.Add(menuItem);
            _menuID++;

            bool wasAdded = (_menuList.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public bool AddIngrediantToMenuItem(string ingredient, string menuName)
        {
            
            
            

            Menu menuItem = GetMenuItemByName(menuName);
            if(menuItem != default)
            {
                if (!menuItem.Ingredients.Contains(ingredient))
                {
                    int startingCount = menuItem.Ingredients.Count();
                    menuItem.Ingredients.Add(ingredient);
                    return menuItem.Ingredients.Count > startingCount ? true : false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        //Read Menu

        public List<Menu> GetMenuItems()
        {
            return _menuList;
        }

        public Menu GetMenuItemByName(string menuItem)
        {
            foreach(Menu item in _menuList)
            {
                if(item.MenuName.ToLower() == menuItem.ToLower())
                {
                    return item;

                }

            }
            return null;
        }

        public Menu GetMenuItemByNumber(int menuNumber)
        {
            foreach(Menu item in _menuList)
            {
                if(item.MenuNumber == menuNumber)
                {
                    return item;
                }
            }

            return null;
        }

        public Menu GetMenuItemByPrice(double itemPrice)
        {
            foreach(Menu item in _menuList)
            {
                if(item.Price == itemPrice)
                {
                    return item;
                }
            }

            return null;
        }

        //Update
        
        public bool UpdateExistingItemOnMenu(string existingItem, Menu newItem)
        {
            Menu olditem = GetMenuItemByName(existingItem);
            if(olditem != null)
            {
                olditem.MenuName = newItem.MenuName;
                olditem.MenuNumber = newItem.MenuNumber;
                olditem.Ingredients = newItem.Ingredients;
                olditem.Price = newItem.Price;

                return true;
            }
            else
            {

                 return false;
            }
        }

        //Remove Item

        public bool RemoveItemFromMenu(Menu existingItem)
        {
            bool deleteItem = _menuList.Remove(existingItem);
            return deleteItem;
        }
    }
}
