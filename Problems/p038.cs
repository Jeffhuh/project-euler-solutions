using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p038
    {
        public static void Solution()
        {
            int max = 0;
            for (int i = 1001; i < 10_000; i++)
            {
                string n = i.ToString() + (i * 2).ToString();
                if (!pandigital(n)) continue;
                int number = int.Parse(n);
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine(max);
        }

        public static bool pandigital(string n)
        {
            if (n.Length != 9) return false;
            bool[] contains = new bool[9];
            for (int i = 0; i < contains.Length; i++)
            {
                int index = n[i] - 49;
                if (index == -1) return false;
                if (contains[index] == false)
                {
                    contains[index] = true;
                }
                else return false;
            }
            return true;
        }
    }
}
