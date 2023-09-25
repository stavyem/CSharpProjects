using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public abstract class Menu
    {
        private readonly List<Item> r_MenuItems = new List<Item>();
        private readonly string r_Title;

        internal Menu(string i_Title)
        {
            r_Title = i_Title;
        }

        public void AddItem(Item i_Item)
        {
            r_MenuItems.Add(i_Item);
        }

        internal abstract void BackOrExit();

        public void Show()
        {
            bool backOrExit = false;

            while (!backOrExit)
            {
                Console.Clear();
                showTitle();
                showMenuItems();
                BackOrExit();
                int choice = getUserValidChoice();
                operateByChoice(choice, out backOrExit);
            }
        }

        private void showTitle()
        {
            Console.WriteLine($"{r_Title}{Environment.NewLine}");
        }

        private void showMenuItems()
        {
            foreach (Item menuItem in r_MenuItems)
            {
                Console.WriteLine(menuItem);
            }
        }

        private int getUserValidChoice()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter your choice:");
                    string choice = Console.ReadLine();
                    validateUserChoice(choice);

                    return int.Parse(choice);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private void validateUserChoice(string i_InputChoice)
        {
            if (int.TryParse(i_InputChoice, out int choice))
            {
                if (choice >= 0 && choice <= r_MenuItems.Count)
                {
                    if (i_InputChoice != choice.ToString())
                    {
                        throw new ArgumentException("Invalid input. To enter a number, make sure it's exactly the written number.");
                    }

                    return;
                }

                throw new ArgumentException($"You are expected to enter a number between 0 to {r_MenuItems.Count}.");
            }

            throw new ArgumentException("You are expected to enter a number.");
        }

        private void operateByChoice(int i_Choice, out bool o_BackOrExit)
        {
            o_BackOrExit = false;

            if (i_Choice == 0)
            {
                o_BackOrExit = true;

                return;
            }

            if (r_MenuItems[i_Choice - 1] is ActionItem item)
            {
                item.OnSelected();
                pressAnyKeyToContinue();
            }
            else
            {
                (r_MenuItems[i_Choice - 1] as MenuItem).ShowMenu();
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
