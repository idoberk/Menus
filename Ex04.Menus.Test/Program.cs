namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            //Events.MainMenu menu = EventMenus.CreateEventMainMenu();
            InterfaceMenus.MainMenu menu = InterfaceMenus.CreateEventMainMenu();
            menu.Show();
        }
    }
}
