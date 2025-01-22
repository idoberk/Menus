using System;

namespace Ex04.Menus.Interfaces
{
    public interface IClickable
    {
        void OnClick();
    }

    internal class MenuItem
    {
        private bool m_IsMainMenu = false;
        private readonly int r_Index;
        private string m_Title;
        private IClickable m_ClickHandler;

        public string Title
        {
            get { return m_Title; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Title cannot be null or empty string");
                }

                m_Title = value;
            }
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

        public IClickable Clicked
        {
            get { return m_ClickHandler; }
            set { m_ClickHandler = value; }
        }

        internal MenuItem(string i_Title, int i_Index, IClickable i_ClickInvoker)
        {
            Title = i_Title;
            r_Index = i_Index;
            Clicked = i_ClickInvoker;
        }

        public void Show()
        {
            Console.WriteLine($"{Index}. {Title}");
        }

        public void Click()
        {
            m_ClickHandler.OnClick();
        }
    }
}
