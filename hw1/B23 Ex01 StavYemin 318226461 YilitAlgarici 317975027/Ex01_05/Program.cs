using System;
using Ex01_04;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            getValidUserInput(out string userInput);
            printStatistics(userInput);
        }

        private static void getValidUserInput(out string o_UserInput)
        {
            Console.WriteLine("Please enter a 6 digits integer (and then press enter):");
            o_UserInput = Console.ReadLine();

            while (!(Ex01_04.Program.IsWholeInputDigits(o_UserInput) && o_UserInput.Length == 6))
            {
                Console.WriteLine("Input wasn't valid. Let's try again.");
                Console.WriteLine("Please enter a 6 digits integer (and then press enter):");
                o_UserInput = Console.ReadLine();
            }
        }

        private static int charToInt(char i_C)
        {
            return int.Parse(i_C.ToString());
        }

        private static int digitsGreaterThenTheUnits(string i_UserInput)
        {
            int greaterDigitsCounter = 0;
            int length = i_UserInput.Length;
            int unitsDigit = charToInt(i_UserInput[length - 1]);

            for (int i = 0; i < length; i++)
            {
                if (unitsDigit < charToInt(i_UserInput[i]))
                {
                    greaterDigitsCounter += 1;
                }
            }

            return greaterDigitsCounter;
        }

        private static int inputMinDigit(string i_UserInput)
        {
            int minDigit = charToInt(i_UserInput[0]);

            for (int i = 1; i < i_UserInput.Length; i++)
            {
                if (charToInt(i_UserInput[i]) < minDigit)
                {
                    minDigit = charToInt(i_UserInput[i]);
                }
            }

            return minDigit;
        }

        private static int divisibleByThree(string i_UserInput)
        {
            int divisibleByThreeCounter = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                if (charToInt(i_UserInput[i]) % 3 == 0)
                {
                    divisibleByThreeCounter += 1;
                }
            }

            return divisibleByThreeCounter;
        }

        private static double inputDigitsAverage(string i_UserInput)
        {
            int sumOfDigits = 0;

            for (int i = 0; i < i_UserInput.Length; i++)
            {
                sumOfDigits += charToInt(i_UserInput[i]);
            }

            double average = (double)sumOfDigits / i_UserInput.Length;

            return average;
        }

        private static void printStatistics(string i_UserInput)
        { 
            int numGreaterThenTheUnits = digitsGreaterThenTheUnits(i_UserInput);
            int minDigit = inputMinDigit(i_UserInput);
            int numDivisibleByThree = divisibleByThree(i_UserInput);
            double average = inputDigitsAverage(i_UserInput);

            string message = String.Format(
                @"The number of digits greater than the unity number is: {0}.
The minimal digit is: {1}.
The number of digits divisible by three is: {2}.
The average of the digits is: {3}.", numGreaterThenTheUnits, minDigit, numDivisibleByThree, average);
            
            Console.WriteLine(message);
        }
    }
}
