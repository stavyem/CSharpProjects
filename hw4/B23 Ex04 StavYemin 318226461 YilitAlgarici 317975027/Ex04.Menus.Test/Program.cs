using System;

namespace Ex04.Menus.Test
{
    internal class Program
    {
        public static void Main()
        {
            createMenu(out Events.MainMenu eventsMenu, out Interfaces.MainMenu interfaceMenu);
            showMenu(eventsMenu, interfaceMenu);
        }

        private static void createMenu(out Events.MainMenu o_EventsMenu, out Interfaces.MainMenu o_InterfaceMenu)
        {
            o_EventsMenu = createEventsMenu();
            o_InterfaceMenu = createInterfaceMenu();
        }

        private static void showMenu(Events.MainMenu i_EventsMenu, Interfaces.MainMenu i_InterfaceMenu)
        {
            i_EventsMenu.Show();
            i_InterfaceMenu.ShowMenu();
        }

        private static Events.MainMenu createEventsMenu()
        {
            Events.MainMenu mainMenu = new Events.MainMenu("Events Main Menu");
            Events.MenuItem showDateTimeMenuItem = new Events.MenuItem(1, "Show Date/Time");
            Events.MenuItem versionAndCapitalsMenuItem = new Events.MenuItem(2, "Version and Capitals");
            Events.ActionItem showDateActionItem = new Events.ActionItem(1, "Show Date");
            Events.ActionItem showTimeActionItem = new Events.ActionItem(2, "Show Time");
            Events.ActionItem versionActionItem = new Events.ActionItem(1, "Show Version");
            Events.ActionItem capitalsActionItem = new Events.ActionItem(2, "Count Capitals");

            showDateActionItem.Selected += showDate;
            showTimeActionItem.Selected += showTime;
            versionActionItem.Selected += showVersion;
            capitalsActionItem.Selected += countCapitals;
            showDateTimeMenuItem.SubMenu.AddItem(showDateActionItem);
            showDateTimeMenuItem.SubMenu.AddItem(showTimeActionItem);
            versionAndCapitalsMenuItem.SubMenu.AddItem(versionActionItem);
            versionAndCapitalsMenuItem.SubMenu.AddItem(capitalsActionItem);
            mainMenu.AddItem(showDateTimeMenuItem);
            mainMenu.AddItem(versionAndCapitalsMenuItem);

            return mainMenu;
        }

        public static void showDate()
        {
            Console.WriteLine($"The current date is: {DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}");
        }

        public static void showTime()
        {
            Console.WriteLine($"The current time is: {DateTime.Now.TimeOfDay.Hours}:{DateTime.Now.TimeOfDay.Minutes}:{DateTime.Now.TimeOfDay.Seconds}");
        }

        public static void showVersion()
        {
            Console.WriteLine("App Version: 23.2.4.9805");
        }

        public static void countCapitals()
        {
            Console.WriteLine("Enter a sentence and see how many capital letters it contains:");
            string input = Console.ReadLine();
            int capitalCount = 0;

            foreach (char c in input)
            {
                if (char.IsLetter(c) && char.IsUpper(c))
                {
                    capitalCount++;
                }
            }

            Console.WriteLine($"The number of capital letters in your sentence is: {capitalCount}");
        }

        private static Interfaces.MainMenu createInterfaceMenu()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Interfaces Main Menu");
            Interfaces.MenuItem dateTimeMenu = new Interfaces.MenuItem("Show Date/Time", mainMenu);
            Interfaces.MenuItem versionAndCapitalsMenu = new Interfaces.MenuItem("Version and Capitals", mainMenu);
            Interfaces.ActionItem showDateItem = new Interfaces.ActionItem("Show Date", dateTimeMenu);
            Interfaces.ActionItem showTimeItem = new Interfaces.ActionItem("Show Time", dateTimeMenu);
            Interfaces.ActionItem showVersionItem = new Interfaces.ActionItem("Show Version", versionAndCapitalsMenu);
            Interfaces.ActionItem countCapitalsItem = new Interfaces.ActionItem("Count Capitals", versionAndCapitalsMenu);

            showDateItem.AddListener(new DateShowing());
            showTimeItem.AddListener(new TimeShowing());
            showVersionItem.AddListener(new VersionShowing());
            countCapitalsItem.AddListener(new CapitalsCounting());

            return mainMenu;
        }

        private class DateShowing : Interfaces.ActionItem.ISelectionListener
        {
            void Interfaces.ActionItem.ISelectionListener.UserSelectedItem()
            {
                showDate();
            }
        }

        private class TimeShowing : Interfaces.ActionItem.ISelectionListener
        {
            void Interfaces.ActionItem.ISelectionListener.UserSelectedItem()
            {
                showTime();
            }
        }

        private class VersionShowing : Interfaces.ActionItem.ISelectionListener
        {
            void Interfaces.ActionItem.ISelectionListener.UserSelectedItem()
            {
                showVersion();
            }
        }

        private class CapitalsCounting : Interfaces.ActionItem.ISelectionListener
        {
            void Interfaces.ActionItem.ISelectionListener.UserSelectedItem()
            {
                countCapitals();
            }
        }
    }
}