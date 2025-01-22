using System;
using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    internal static class EventMenus
    {
        public static MainMenu CreateEventMainMenu()
        {
            MainMenu mainMenu = new MainMenu("Delegates Main Menu");
            mainMenu.SetAsMainMenu();

            MainMenu lettersAndVersionMenu = new MainMenu("Letters and Version");
            MainMenu showCurrentDateOrTimeMenu = new MainMenu("Show Current Date/Time");

            lettersAndVersionMenu.AddMenuItem("Show Version", showVersion);
            lettersAndVersionMenu.AddMenuItem("Count Lowercase Letters", countLowercaseLetters);

            showCurrentDateOrTimeMenu.AddMenuItem("Show Current Time", showCurrentTime);
            showCurrentDateOrTimeMenu.AddMenuItem("Show Current Date", showCurrentDate);

            mainMenu.AddSubMenu(lettersAndVersionMenu);
            mainMenu.AddSubMenu(showCurrentDateOrTimeMenu);

            return mainMenu;
        }
        
        private static void showVersion()
        {
            Console.WriteLine("App Version: 25.1.4.5480");
        }

        private static void countLowercaseLetters()
        {
            Console.WriteLine("Please enter your sentence:");
            string userSentenceInput = Console.ReadLine();
            int lowercaseLettersCount = 0;

            foreach (char letter in userSentenceInput)
            {
                if (char.IsLower(letter))
                {
                    lowercaseLettersCount++;
                }
            }

            Console.WriteLine("There are {0} lowercase letters in your text", lowercaseLettersCount);
        }

        private static void showCurrentTime()
        {
            Console.WriteLine("Current Time is {0}", DateTime.Now.ToShortTimeString());
        }

        private static void showCurrentDate()
        {
            Console.WriteLine("Current Date is {0}", DateTime.Now.ToShortDateString());
        }
    }
}