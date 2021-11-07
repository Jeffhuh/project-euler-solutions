using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p041
    {
        public static void Solution()
        {
            int[] add = { 2,4,4};
            int j = 0;
            int max = 0;
            for (int i = 7_000_001; i < 8_000_000;)
            {
                i += (add[j % 3]);
                j++;
                if (pandigital(i) && IsPrime(i)) max = i;
            }
            Console.WriteLine(max);
        }

        public static bool pandigital(int number)
        {
            bool[] contains = new bool[7];
            string n = number.ToString();
            for (int i = 0; i < contains.Length; i++)
            {
                int index = n[i] - 49;
                if (index == -1 || index > 6) return false;
                if (!contains[index])
                {
                    contains[index] = true;
                }
                else return false;
            }
            return true;
        }

        public static bool IsPrime(int number)
        {
            if (number % 2 == 0 || number < 2)
            {
                if (number == 2) return true;
                return false;
            }
            int i = 3;
            while (i * i <= number)
            {
                if (number % i == 0) return false;
                i += 2;
            }
            return true;
        }
    }
}
