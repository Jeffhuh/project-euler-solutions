using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p113
    {
        public static void Solution()
        {
            long sum = 0;
            for (int i = 3; i < 101; i++)
            {
                sum += nCr(9 + i, 9) + nCr(8 + i, 8);
            }
            Console.WriteLine(sum - 98 + 99 - 9 * 98);
        }

        public static long nCr(int n, int k)
        {
            k = Math.Max(n - k, k);
            long prod = 1;
            for (int i = k + 1; i < n + 1; i++) prod *= i;
            long div = 1;
            for (int i = n - k; 1 < i; i--) div *= i;
            return prod / div;
        }
    }
}
