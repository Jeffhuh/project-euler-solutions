using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Problems
{
    internal class p104
    {
        public static int fact = 362880;
        public static void Solution()
        {
            int f1 = 1;
            int f2 = 1;
            int i = 3;
            while (true)
            {
                int temp = f2;
                f2 = (f2 + f1) % 1_000_000_000;
                f1 = temp;
                if (Pandigital(f2.ToString()))
                {
                    string s = Fibonacci(i).ToString();
                    if (Pandigital(s)) break;
                }
                i++;
            }
            Console.WriteLine(i);
        }

        public static bool Pandigital(string s)
        {
            if (s.Length < 9) return false;
            int a1 = 1;
            for (int i = 0; i < 9; i++)
            {
                a1 *= (s[i] - 48);
            }
            if (a1 != fact) return false;
            HashSet<int> set1 = new HashSet<int>();
            for (int i = 0; i < 9; i++)
            {
                if (set1.Contains(s[i])) return false;
                set1.Add(s[i]);
            }
            return true;
        }

        // https://www.nayuki.io/page/fast-fibonacci-algorithms
        private static BigInteger Fibonacci(int n)
        {
            BigInteger a = BigInteger.Zero;
            BigInteger b = BigInteger.One;
            for (int i = 31; i >= 0; i--)
            {
                BigInteger d = a * (b * 2 - a);
                BigInteger e = a * a + b * b;
                a = d;
                b = e;
                if ((((uint)n >> i) & 1) != 0)
                {
                    BigInteger c = a + b;
                    a = b;
                    b = c;
                }
            }
            return a;
        }
    }
}
