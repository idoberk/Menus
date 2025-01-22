using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public interface IUpdateHierarchy
    {
        void UpdateHierarchy(int i_NewMenuLevel);
    }

    public class MainMenu : IClickable, IUpdateHierarchy
    {
        private int m_MenuLevel;
        private string m_MenuTitle;
        private readonly List<MenuItem> r_MenuItemsList = new List<MenuItem>();

        internal List<MenuItem> MenuItemList
        {
            get { return r_MenuItemsList; }
        }

        public string MenuTitle
        {
            get { return m_MenuTitle; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be null or empty string");
                }

                m_MenuTitle = value;
            }
        }

        public int MenuLevel
        {
            get { return m_MenuLevel; }
            set { m_MenuLevel = value; }
        }

        public MainMenu(string i_MenuTitle)
        {
            MenuTitle = i_MenuTitle;
            MenuLevel = 1;
            AddMenuItem("Back", this);// Show);
        }

        public void SetAsMainMenu()
        {
            MenuItemList[0].Title = "Exit";
            MenuItemList[0].IsMainMenu = true;
            //MenuItemList[0].Clicked = 
            //    MenuItemList[0].Clicked -= Show;
            //    MenuItemList[0].Clicked += exitMenuItem_Clicked;
            //}
        }

        public void AddSubMenu(MainMenu i_SubMenu)
        {
            AddMenuItem(i_SubMenu.MenuTitle, i_SubMenu as IClickable);
            i_SubMenu.UpdateHierarchy(MenuLevel);
            //i_SubMenu.OnLevelChanged(MenuLevel + 1);
            //    HierarchyChanged += i_SubMenu.OnLevelChanged;
            //    i_SubMenu.MenuItemList[0].Clicked -= i_SubMenu.Show;
            //    i_SubMenu.MenuItemList[0].Clicked += Show;
            //}}
        }

        public void UpdateHierarchy(int i_NewMenuLevel)
        {
            MenuLevel += i_NewMenuLevel + 1;
        }

        //private void OnLevelChanged(int i_NewLevel)
        //{
        //    MenuLevel = i_NewLevel;
        //    HierarchyChanged?.Invoke(i_NewLevel + 1);
        //}

        public void AddMenuItem(string i_Title, IClickable i_ClickableMethodHandler)
        {
            MenuItemList.Add(new MenuItem(i_Title, MenuItemList.Count, i_ClickableMethodHandler));
        }

        void IClickable.OnClick()
        {
            Show();
        }

        private void exitMenuItem_Clicked()
        {
            Environment.Exit(0);
        }

        public void Show()
        {
            bool isRunning = true;

            printMenu();

            while(isRunning)
            {
                getInput(out int itemChosen);
                Console.Clear();
                MenuItemList[itemChosen].Click();

                if(MenuItemList[itemChosen].Title == "Back") // itemChosen == 0
                {
                    isRunning = false;
                } else
                {
                    printPrompt("Press any key to continue");
                    Console.ReadKey();
                    printMenu();
                }
            }
        }

        private void printMenu()
        {
            Console.Clear();
            string menuTitle = string.Format("** {0} **", MenuTitle);
            string titleUnderLines = new string('-', menuTitle.Length);
            printPrompt(menuTitle);
            printPrompt(titleUnderLines);

            foreach(MenuItem item in MenuItemList)
            {
                if(item.Index != 0)
                {
                    item.Show();
                }
            }

            MenuItemList[0].Show();
        }

        private void getInput(out int o_UserInput)
        {
            int numOfItems = MenuItemList.Count - 1;

            displayInputInstructions();

            while(!int.TryParse(Console.ReadLine(), out o_UserInput) || o_UserInput < 0 || o_UserInput >= (numOfItems + 1))
            {
                printPrompt("Wrong input - Try again!");
            }
        }

        private void displayInputInstructions()
        {
            int numOfItems = MenuItemList.Count - 1;
            string exitText = MenuLevel == 1 ? "exit" : "go back";
            string promptMessage = string.Empty;

            if(numOfItems == 0)
            {
                promptMessage = string.Format("Please enter 0 to {0}:", exitText);
                // printPrompt(">>");
            } else
            {
                promptMessage = string.Format("Please enter your choice (1 - {0} or 0 to {1}):", numOfItems, exitText);
            }

            printPrompt(promptMessage);
        }

        private void printPrompt(string i_Input)
        {
            Console.WriteLine(i_Input);
        }
    }
}
