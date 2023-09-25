using System;

namespace Ex04.Menus.Events
{
    public class MainMenu : Menu
    {
        public MainMenu(string i_Title) : base(i_Title)
        {
        }
        internal override void BackOrExit()
        {
            Console.WriteLine("0. Exit");
        }
    }
}
