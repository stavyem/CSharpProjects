using System;
using System.Text;

namespace Ex01_02
{
    public class Program
    {
        static void Main()
        {
            PrintDiamond(new StringBuilder(), 1, 9);
        }

        public static void PrintDiamond(StringBuilder i_StringBuilder, int i_Row, int i_Height)
        {
            if (i_Row <= i_Height)
            {
                int spaces = Math.Abs(i_Height / 2 - i_Row + 1);
                int asterisks = i_Height - 2 * spaces;

                i_StringBuilder.Append(' ', spaces);
                i_StringBuilder.Append('*', asterisks);
                i_StringBuilder.Append(Environment.NewLine);
                PrintDiamond(i_StringBuilder, i_Row + 1, i_Height);
            }

            if (i_Row > i_Height)
            {
                Console.WriteLine(i_StringBuilder.ToString());
            }
        }
    }
}