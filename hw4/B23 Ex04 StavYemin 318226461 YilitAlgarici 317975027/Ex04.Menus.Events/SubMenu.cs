using System;
namespace Ex04.Menus.Events
{
    public class SubMenu : Menu
    {
        internal SubMenu(string i_Title) : base(i_Title)
        {
        }

        internal override void BackOrExit()
        {
            Console.WriteLine("0. Back");
        }
    }

}
