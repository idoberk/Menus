using System;

namespace Ex04.Menus.Events
{
    public delegate void ClickInvoker();

    public class MenuItem
    {
        public event ClickInvoker Clicked;

        private string m_Title;
        private readonly int r_Index;
        private bool m_IsMainMenu = false;

        public string Title 
        { 
            get { return m_Title; }
            set { m_Title = value; }
        }

        public int Index
        {
            get { return r_Index; }
        }

        public bool IsMainMenu
        {
            get { return m_IsMainMenu; }
            set { m_IsMainMenu = value; }
        }

        public MenuItem(string i_Title, int i_Index, ClickInvoker i_ClickInvoker)
        {
            Title = i_Title;
            r_Index = i_Index;
            Clicked += i_ClickInvoker;
        }

        public void Show()
        {
            Console.WriteLine($"{Index}. {Title}");
        }

        public void OnClicked()
        {
            Clicked?.Invoke();

            //if (Clicked != null)
            //{
            //    Clicked.Invoke();
            //}
        }

    }
}
