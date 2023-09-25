using System;

namespace Ex01_01
{
    class Program
    {
        public static void Main()
        {
            getUserBinaryInput(out string binaryStr1, out string binaryStr2, out string binaryStr3);
            binaryInputToDecimal(binaryStr1, binaryStr2, binaryStr3, 
                out double decimalNumber1, out double decimalNumber2, out double decimalNumber3);
            printStatistics(decimalNumber1, decimalNumber2, decimalNumber3, 
                binaryStr1, binaryStr2, binaryStr3);
        }

        private static void getUserBinaryInput(out string o_BinaryStr1, out string o_BinaryStr2, out string o_BinaryStr3)
        {
            Console.WriteLine("You will need to enter THREE BINARY numbers consists of 8 bits. (press enter to continue)");
            o_BinaryStr1 = getValidBinaryInput();
            o_BinaryStr2 = getValidBinaryInput();
            o_BinaryStr3 = getValidBinaryInput();
        }

        private static string getValidBinaryInput()
        {
            Console.WriteLine("Please enter a binary number consists of 8 bits (and then press enter):");
            string userInput = Console.ReadLine();

            while (!isValidBinary(userInput))
            {
                Console.WriteLine("Input wasn't valid. Let's try again.");
                Console.WriteLine("Please enter a binary number consists of 8 bits (and then press enter):");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static bool isValidBinary(string i_UserInput)
        {
            bool isValid = false;

            if (i_UserInput.Length == 8)
            {
                isValid = true;

                for (int i = 0; i < i_UserInput.Length; i++)
                {
                    if (!(char.IsDigit(i_UserInput[i]) && (i_UserInput[i] == '0' || i_UserInput[i] == '1')))
                    {
                        isValid = false;
                        break;
                    }
                }
            }

            return isValid;
        }

        private static void binaryInputToDecimal(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3,
                                                 out double o_DecimalNumber1, out double o_DecimalNumber2, out double o_DecimalNumber3)
        {
            o_DecimalNumber1 = binaryToDecimal(i_BinaryStr1);
            o_DecimalNumber2 = binaryToDecimal(i_BinaryStr2);
            o_DecimalNumber3 = binaryToDecimal(i_BinaryStr3);
        }

        private static double binaryToDecimal(string i_BinaryString)
        {
            int digit;
            int power = i_BinaryString.Length - 1;
            double decimalNumber = 0;

            for (int i = 0; i < i_BinaryString.Length; i++)
            {
                int.TryParse(i_BinaryString[i].ToString(), out digit);
                decimalNumber += digit * Math.Pow(2, power);
                power--;
            }

            return decimalNumber;
        }

        private static void descendingSort(double i_DecimalNumber1, double i_DecimalNumber2, double i_DecimalNumber3)
        {
            if (i_DecimalNumber1 < i_DecimalNumber2)
            {
                double temporaryPlaceholder = i_DecimalNumber1;
                i_DecimalNumber1 = i_DecimalNumber2;
                i_DecimalNumber2 = temporaryPlaceholder;
            }

            if (i_DecimalNumber2 < i_DecimalNumber3)
            {
                double temporaryPlaceholder = i_DecimalNumber2;
                i_DecimalNumber2 = i_DecimalNumber3;
                i_DecimalNumber3 = temporaryPlaceholder;

                if (i_DecimalNumber1 < i_DecimalNumber2)
                {
                    temporaryPlaceholder = i_DecimalNumber1;
                    i_DecimalNumber1 = i_DecimalNumber2;
                    i_DecimalNumber2 = temporaryPlaceholder;
                }
            }

            string msg =
                string.Format(
                    @"The descending order is:
{0}
{1}
{2}",
                    i_DecimalNumber1, i_DecimalNumber2, i_DecimalNumber3);
            Console.WriteLine(msg);
        }

        private static bool isPowerOfTwo(double i_Number)
        {
            bool isPowerOf2 = true;

            if (i_Number <= 0)
            {
                isPowerOf2 = false;
            }

            else
            {
                int logTwoOfNumber = (int)Math.Log(i_Number, 2); // cast to int so we get the floor value of the logarithm.
                if (Math.Pow(2, logTwoOfNumber) != i_Number)
                {
                    isPowerOf2 = false;
                }
            }

            return isPowerOf2;
        }

        private static int countNumsPowerOf2(double i_DecimalNumber1, double i_DecimalNumber2, double i_DecimalNumber3)
        {
            int amountOfPowerOfTwo = 0;

            if (isPowerOfTwo(i_DecimalNumber1))
            {
                amountOfPowerOfTwo++;
            }

            if (isPowerOfTwo(i_DecimalNumber2))
            {
                amountOfPowerOfTwo++;
            }

            if (isPowerOfTwo(i_DecimalNumber3))
            {
                amountOfPowerOfTwo++;
            }

            return amountOfPowerOfTwo;
        }

        private static void calculateZerosAndOnesAverage(string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3, 
                                                         out float o_AverageZeros, out float o_AverageOnes)
        {
            int totalZeros = countZeros(i_BinaryStr1) + countZeros(i_BinaryStr2) + countZeros(i_BinaryStr3);
            int totalOnes = countOnes(i_BinaryStr1) + countOnes(i_BinaryStr2) + countOnes(i_BinaryStr3);
            o_AverageZeros = (float)totalZeros / 3;
            o_AverageOnes = (float)totalOnes / 3;
        }

        private static int countZeros(string i_BinaryStr)
        {
            int numZeros = 0;

            for (int i = 0; i < i_BinaryStr.Length; i++)
            {
                if(i_BinaryStr[i] == '0')
                {
                    numZeros++;
                }
            }

            return numZeros;
        }

        private static int countOnes(string i_BinaryStr)
        {
            int numOnes = 0;

            for (int i = 0; i < i_BinaryStr.Length; i++)
            {
                if (i_BinaryStr[i] == '1')
                {
                    numOnes++;
                }
            }

            return numOnes;
        }

        private static bool isDivisibleBy4(double i_DecimalNumber)
        {
            return i_DecimalNumber % 4 == 0;
        }

        private static int countNumsDivisibleBy4(double i_DecimalNumber1, double i_DecimalNumber2, double i_DecimalNumber3)
        {
            int amountOfDivisibleBy4 = 0;

            if (isDivisibleBy4(i_DecimalNumber1))
            {
                amountOfDivisibleBy4++;
            }
            if (isDivisibleBy4(i_DecimalNumber2))
            {
                amountOfDivisibleBy4++;
            }
            if (isDivisibleBy4(i_DecimalNumber3))
            {
                amountOfDivisibleBy4++;
            }

            return amountOfDivisibleBy4;
        }

        private static bool isDescendingOrder(double i_DecimalNumber)
        {
            bool isDescending = true;
            string decimalString = i_DecimalNumber.ToString();

            for (int i = 0; i < decimalString.Length - 1; i++)
            {
                if (decimalString[i] < decimalString[i + 1])
                {
                    isDescending = false;
                    break;
                }
            }

            return isDescending;
        }

        private static int countNumOfDescendingSeries(double i_DecimalNumber1, double i_DecimalNumber2, double i_DecimalNumber3)
        {
            int amountOfDescendingSeries = 0;

            if (isDescendingOrder(i_DecimalNumber1))
            {
                amountOfDescendingSeries++;
            }

            if (isDescendingOrder(i_DecimalNumber2))
            {
                amountOfDescendingSeries++;
            }

            if (isDescendingOrder(i_DecimalNumber3))
            {
                amountOfDescendingSeries++;
            }

            return amountOfDescendingSeries;
        }

        private static bool isPalindrome(double i_DecimalNumber)
        {
            string decimalNumber = i_DecimalNumber.ToString();
            int i = 0;
            int j = decimalNumber.Length - 1;
            bool isPalindrome = true;

            while (i <= j)
            {
                if (decimalNumber[i] != decimalNumber[j])
                {
                    isPalindrome = false;
                }

                i++;
                j--;
            }

            return isPalindrome;
        }

        private static int countNumOfPalindromeNumbers(
            double i_DecimalNumber1,
            double i_DecimalNumber2,
            double i_DecimalNumber3)
        {
            int amountOfPalindromeNumbers = 0;

            if (isPalindrome(i_DecimalNumber1))
            {
                amountOfPalindromeNumbers++;
            }

            if (isPalindrome(i_DecimalNumber2))
            {
                amountOfPalindromeNumbers++;
            }

            if (isPalindrome(i_DecimalNumber3))
            {
                amountOfPalindromeNumbers++;
            }

            return amountOfPalindromeNumbers;
        }

        private static void printStatistics(double i_DecimalNumber1, double i_DecimalNumber2, double i_DecimalNumber3,
                                            string i_BinaryStr1, string i_BinaryStr2, string i_BinaryStr3)
        {
            int powerOf2Amount = countNumsPowerOf2(i_DecimalNumber1, i_DecimalNumber2, i_DecimalNumber3);
            int divisibleBy4Amount = countNumsDivisibleBy4(i_DecimalNumber1, i_DecimalNumber2, i_DecimalNumber3);
            int descendingSeriesAmount = countNumOfDescendingSeries(i_DecimalNumber1, i_DecimalNumber2, i_DecimalNumber3);
            int palindromeAmount = countNumOfPalindromeNumbers(i_DecimalNumber1, i_DecimalNumber2, i_DecimalNumber3);

            descendingSort(i_DecimalNumber1, i_DecimalNumber2, i_DecimalNumber3);
            calculateZerosAndOnesAverage(i_BinaryStr1, i_BinaryStr2, i_BinaryStr3, out float averageZeros, out float averageOnes);

            string averageZerosMessage = string.Format("Average of Zeros in input: {0}.", averageZeros);
            string averageOnesMessage = string.Format("Average of Ones in input: {0}.", averageOnes);
            string amountPowerOf2Message = string.Format("Amount of numbers which are powers of 2: {0}.", powerOf2Amount);
            string amountDivisibleBy4Message = string.Format("Amount of numbers which are divisible by 4: {0}.", divisibleBy4Amount);
            string amountDescendingSeriesMessage = string.Format("Amount of numbers which are descending series: {0}.", descendingSeriesAmount);
            string amountPalindromeMessage = string.Format("Amount of numbers which are palindromes: {0}.", palindromeAmount);

            Console.WriteLine(averageZerosMessage);
            Console.WriteLine(averageOnesMessage);
            Console.WriteLine(amountPowerOf2Message);
            Console.WriteLine(amountDivisibleBy4Message);
            Console.WriteLine(amountDescendingSeriesMessage);
            Console.WriteLine(amountPalindromeMessage);
        }
    }
}
