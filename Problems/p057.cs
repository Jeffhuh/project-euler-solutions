using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p057
    {
        public static void Solution()
        {
            int count = 0;
            BigInteger numerator = 3;
            BigInteger denominator = 2;
            for (int i = 0; i < 999; i++)
            {
                BigInteger temp = numerator + denominator;
                numerator += 2 * denominator;
                denominator = temp;
                if (numerator.ToString().Length > denominator.ToString().Length) count++;
            }
            Console.WriteLine(count);
        }
    }
}
