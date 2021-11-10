using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p048
    {
        public static void Solution()
        {
            long sum = 0L; 
            for (int i = 1; i < 1_001; i++)
            {
                sum += Mod10Pow(i);
            }
            Console.WriteLine(sum %= 10_000_000_000L);
        }

        public static long Mod10Pow(long number)
        {
            long pow = number;
            int i = 1;
            while (i < pow)
            {
                number *= pow;
                number %= 10_000_000_000L;
                i++;
            }
            return number;
        } 
    }
}
