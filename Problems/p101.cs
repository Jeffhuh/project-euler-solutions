using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p101
    {
        public static void Solution()
        {
            int n = 10;
            BigInteger sum = 0;
            BigInteger[] seq = new BigInteger[n];
            for (int i = 0; i < n; i++)
            {
                seq[i] = f(i + 1);
            }
            int s = 1;
            for (int i = 0; i < n; i++)
            {
                if ((i & 1) == 0) s = 1;
                else s = -1;
                for (int j = 0; j < i + 1; j++)
                {
                    BigInteger a = s * nCr(i + 1, j) * seq[j];
                    sum += a;
                    s *= -1;
                }
            }
            Console.WriteLine(sum);
        }
        public static BigInteger f(BigInteger x)
        {
            return 1 - x + BigInteger.Pow(x, 2) - BigInteger.Pow(x, 3) + BigInteger.Pow(x, 4) - BigInteger.Pow(x, 5) + BigInteger.Pow(x, 6) - BigInteger.Pow(x, 7) + BigInteger.Pow(x, 8) - BigInteger.Pow(x, 9) + BigInteger.Pow(x, 10);
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
