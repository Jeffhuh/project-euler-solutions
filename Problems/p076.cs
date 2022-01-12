using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p076
    {
        private static long[] pN = new long[101];
        public static void Solution()
        {
            pN[0] = 1;
            Console.WriteLine(p(100) - 1);
        }

        public static long p(int n)
        {
            if (pN[n] != 0) return pN[n];
            int k = 1;
            long sum = 0;
            int positiv = 1;
            do
            {
                int z = k * (3 * k - 1) / 2;
                if (z > n) break;
                sum += p(n - z) * positiv;
                if (z + k > n) break;
                else sum += p(n - z - k) * positiv;
                positiv *= -1;
                k++;
            } while (true);
            pN[n] = sum;
            return sum;
        }
    }
}
