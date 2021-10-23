using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_16_50
{
    class p019
    {
        public static void Solution()
        {
            int[] months = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            int year = 30 * 4 + 28 + 7 * 31;
            int n = (year + 2) % 7;
            int count = 0;
            bool inc = false;
            for (int i = 1; i <= 100; i++)
            {
                if (i % 4 == 0)
                {
                    if (i % 100 != 0)
                    {
                        inc = true;
                    }
                }
                for (int j = 0; j < 12; j++)
                {
                    if (n % 7 == 1)
                    {
                        count++;
                    }
                    n = n + months[j];
                    if (j == 1 && inc) n++;
                }
                inc = false;
            }
            Console.WriteLine(count);
        }
    }
}
