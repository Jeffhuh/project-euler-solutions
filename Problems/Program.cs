using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test.Testing();
            p036.Solution();
        }
    }

    class Test
    {

        internal static void Testing()
        {
            Console.WriteLine(decimalToBinary(63));
        }

        public static string decimalToBinary(int dec)
        {
            string binary = string.Empty;
            do
            {
                int r = dec % 2;
                dec /= 2;
                binary = (char)(48 + r) + binary;
            } while (dec != 0);
            return binary;
        }

        public static int binaryToDecimal(string binary)
        {
            int dec = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                dec = dec << 1;
                dec = binary[i] == '1' ? dec + 1 : dec;
            }
            return dec;
        }
    }
}
