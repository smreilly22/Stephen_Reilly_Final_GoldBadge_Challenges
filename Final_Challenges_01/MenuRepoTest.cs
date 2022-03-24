using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Challenges_01
{
    public class MenuRepoTest
    {
        [TestClass]

        public class MenuRepo_Test
        {

       

             private MenuRepo _menuRepo = new MenuRepo();

             [TestInitialize]

            public void Arrange()
            {
                Menu menu1 = new Menu("CheeseBurger" , "Hamburger with cheese", new List<string> { "hamburger", "Cheddar Cheese", "Lettuce", "Tomato", "Buns" }, 2.50d);
                Menu menu2 = new Menu("Burriot" , "Chicken Burrito", new List<string> { "shredded chicken", "Mix Cheese", "rice" }, 3.50d);
                Menu menu3 = new Menu("HotDog", "Beef Hotdog", new List<string> { "beef hotdog", "bun", "Ketchup", "mustard" }, 1.50);

                _menuRepo.AddItemToMenu(menu1);
                _menuRepo.AddItemToMenu(menu2);
                _menuRepo.AddItemToMenu(menu3);
            }

            [TestMethod]
            public void AddMenuItemTest_ShouldAddItem()
            {
                Menu menuItem = new Menu("Grilled Cheese", "a grilled cheese made with love", new List<string> { "cheddar cheese", "texas toast", "tomatoes", }, 2.50d);
                bool result = _menuRepo.AddItemToMenu(menuItem);

                Assert.IsTrue(result);
                Assert.IsTrue(_menuRepo.GetMenuItems().Contains(menuItem));
            }

            [TestMethod]
            public void UpdateMenu_ShouldchangeMenuItemInfo()
            {
                string existingItem = _menuRepo.GetMenuItemByNumber(2).MenuName;
                bool result = _menuRepo.UpdateExistingItemOnMenu( "Burriot" , new Menu("Burrito" , "Chicken Burrito", new List<string> { "shredded chicken", "mix cheese", "rice" }, 4.50d));

                Assert.IsTrue(result);

                var menuItem = _menuRepo.GetMenuItemByNumber(2);
                Assert.AreNotEqual(existingItem, menuItem.MenuName);
                Assert.AreEqual("Burrito", menuItem.MenuName);

            }

            [TestMethod]
            public void RemoveItem_ShouldRemoveItem()
            {
                Menu menu = new Menu("HotDog", "Chicken Hotdog", new List<string> { "beef hotdog", "bun", "Ketchup", "mustard" }, 1.50);
                _menuRepo.AddItemToMenu(menu);
                Assert.IsTrue(_menuRepo.RemoveItemFromMenu(menu));
                Assert.IsFalse(_menuRepo.GetMenuItems().Contains(menu));

            }

        }

    }
}
