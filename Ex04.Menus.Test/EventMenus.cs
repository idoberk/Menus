using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    internal class EventMenus
    {
        public static MainMenu CreateEventMainMenu()
        {
            MainMenu mainMenu = new MainMenu("Drinks Machine");
            mainMenu.SetAsMainMenu();

            MainMenu coffeeSubMenu = new MainMenu("Coffee");
            MainMenu juiceSubMenu = new MainMenu("Juice");

            mainMenu.AddSubMenu(coffeeSubMenu);
            mainMenu.AddSubMenu(juiceSubMenu);

            return mainMenu;
        }
    }
}
