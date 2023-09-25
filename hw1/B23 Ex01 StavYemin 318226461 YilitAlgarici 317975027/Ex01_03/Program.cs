using System;
using System.Text;
using Ex01_02;
using Ex01_04;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        { 
            diamondWithInputHeight();
        }

        private static void diamondWithInputHeight()
        {
            Console.WriteLine("Please enter a number for your desired diamond height that only contains digits (and then press enter):");
            string userInput = Console.ReadLine();

            while (!isValidInput(userInput))
            {
                Console.WriteLine("Input wasn't valid. Let's try again.");
                Console.WriteLine("Please enter a number for your desired diamond height that only contains digits (and then press enter):");
                userInput = Console.ReadLine();
            }

            int userInputToInt = int.Parse(userInput);
            if(userInputToInt % 2 == 0)
            {
                userInputToInt++;
            }
            StringBuilder stringBuilder = new StringBuilder();
            Ex01_02.Program.PrintDiamond(stringBuilder, 1, userInputToInt);
        }
        
        private static bool isValidInput(string i_UserInput)
        {
            bool isValid = Ex01_04.Program.IsWholeInputDigits(i_UserInput);

            return isValid;
        }
    }
}