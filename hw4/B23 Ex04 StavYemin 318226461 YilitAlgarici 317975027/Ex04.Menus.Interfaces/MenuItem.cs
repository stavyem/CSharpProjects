using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private readonly string r_MenuTitle;
        private readonly List<MenuItem> r_MenuItems;

        public MenuItem(string i_MenuTitle, MenuItem i_PreviousMenu)
        {
            r_MenuTitle = i_MenuTitle;
            r_MenuItems = new List<MenuItem> { i_PreviousMenu };
            i_PreviousMenu?.addMenuItem(this);
        }

        internal MenuItem(string i_MenuTitle) : this(i_MenuTitle, null) { }

        private void addMenuItem(MenuItem i_ItemToAdd)
        {
            r_MenuItems.Add(i_ItemToAdd);
        }

        public void ShowMenu()
        {
            bool backOrReturn = false;

            while (!backOrReturn)
            {
                printMenuTitle();
                printMenuItems();
                int selectedOption = getUserValidSelection();
                operateBySelection(selectedOption, out backOrReturn);
            }
        }

        private void printMenuTitle()
        {
            Console.Clear();
            Console.WriteLine($"{r_MenuTitle}{Environment.NewLine}");
        }

        private void printMenuItems()
        {
            string returnOption = this is MainMenu ? "Exit" : "Back";

            for (int i = 1; i < r_MenuItems.Count; i++)
            {
                Console.WriteLine($"{i}. {r_MenuItems[i].r_MenuTitle}");
            }

            Console.WriteLine($"0. {returnOption}");
        }

        private int getUserValidSelection()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your choice:");
                    string userSelection = Console.ReadLine();
                    validateUserSelection(userSelection);

                    return int.Parse(userSelection);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private void validateUserSelection(string i_UserSelection)
        {
            if (int.TryParse(i_UserSelection, out int selection))
            {
                if (selection >= 0 && selection <= r_MenuItems.Count - 1)
                {
                    if (i_UserSelection != selection.ToString())
                    {
                        throw new ArgumentException("Invalid input. To enter a number, make sure it's exactly the written number.");
                    }

                    return;
                }

                throw new ArgumentException($"You are expected to enter a number between 0 to {r_MenuItems.Count - 1}.");
            }

            throw new ArgumentException("You are expected to enter a number.");
        }

        private void operateBySelection(int i_Selection, out bool o_BackOrExit)
        {
            o_BackOrExit = false;
            MenuItem selectedMenuItem = r_MenuItems[i_Selection];

            if (i_Selection == 0)
            {
                o_BackOrExit = true;
                return;
            }

            if (selectedMenuItem is ActionItem)
            {
                (selectedMenuItem as ActionItem).InvokeUserSelection();
                pressAnyKeyToContinue();
            }
            else
            {
                selectedMenuItem?.ShowMenu();
            }
        }

        private static void pressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
