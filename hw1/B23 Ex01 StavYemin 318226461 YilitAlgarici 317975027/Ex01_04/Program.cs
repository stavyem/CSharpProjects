using System;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            getUserInput(out string userInput);
            printCharacteristics(userInput);
        }
        
        private static void getUserInput(out string o_UserInput)
        {
            Console.WriteLine("Please enter a 6 character string that contains only english letters or only digits (and then press enter):");
            o_UserInput = Console.ReadLine();

            while (!isValidInput(o_UserInput))
            {
                Console.WriteLine("Input wasn't valid. Let's try again.");
                Console.WriteLine("Please enter a 6 character string that contains only english letters or only digits (and then press enter):");
                o_UserInput = Console.ReadLine();
            }
        }

        private static bool isValidInput(string i_UserInput)
        {
            bool isValid = false;

            if (i_UserInput.Length == 6)
            {
                if (IsWholeInputDigits(i_UserInput))
                {
                    isValid = true;
                }

                else if (isWholeInputAlphabet(i_UserInput))
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        public static bool IsWholeInputDigits(string i_UserInput)
        {
            bool isValid = true;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (!char.IsDigit(i_UserInput[i]))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private static bool isWholeInputAlphabet(string i_UserInput)
        {
            bool isValid = true;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (!isAlphabet(i_UserInput[i]))
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        private static bool isAlphabet(char i_C)
        {
            return ('A' <= i_C && i_C <= 'Z') || ('a' <= i_C && i_C <= 'z');
        }

        private static bool isPalindrome(string i_UserInput, int i_StartIndex, int i_EndIndex)
        {
            return i_StartIndex >= i_EndIndex || (i_UserInput[i_StartIndex] == i_UserInput[i_EndIndex]
                                                  && isPalindrome(i_UserInput, i_StartIndex + 1, i_EndIndex - 1));
        }

        private static bool isDivisibleBy3(int i_UserInput)
        {
            return i_UserInput % 3 == 0;
        }

        private static int amountUpperCaseNumber(string i_UserInput)
        {
            int uppercaseAmount = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if ('A' <= i_UserInput[i] && i_UserInput[i] <= 'Z')
                {
                    uppercaseAmount++;
                }
            }

            return uppercaseAmount;
        }

        private static void printCharacteristics(string i_UserInput)
        {
            if (isPalindrome(i_UserInput, 0, i_UserInput.Length - 1))
            {
                Console.WriteLine("The input is a palindrome.");
            }

            else
            {
                Console.WriteLine("The input is not a palindrome.");
            }

            if (int.TryParse(i_UserInput, out int userInputNumber))
            {
                if (isDivisibleBy3(userInputNumber))
                {
                    Console.WriteLine("The input is divisible by 3.");
                }

                else
                {
                    Console.WriteLine("The input is not divisible by 3.");
                }
            }

            else
            {
                string amountUppercaseMessage = string.Format("Amount of uppercase is {0}.", amountUpperCaseNumber(i_UserInput));
                Console.WriteLine(amountUppercaseMessage);
            }
        }
    }
}
