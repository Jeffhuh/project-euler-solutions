using System;
using System.Collections.Generic;
using System.Numerics;

namespace Problems
{
    internal class p112
    {
        // bad solution, but cant be bothered rn bc it is 3 am
        public static void Solution()
        {
            /*int i = 2;
            while (true)
            {
                double d = Math.Pow(10, i + 1);
                double limit = d - (Recursion(i, 9) + Recursion(i, 10) + 99 - Math.Pow(10, i - 1));
                if (limit / d > 0.99d) break;
                i++;
            }
            int l = (int)Math.Pow(10, i);
            int count = l - (Recursion(i - 1, 9) + Recursion(i - 1, 10) + 99 - (int)Math.Pow(10, i - 2));
            int q = 0;
            for (int j = l + 1; true; j++)
            {
                Console.WriteLine(j);
                if (Bouncy(j.ToString())) 
                {
                    count++;
                    BigInteger c1 = new BigInteger(count);
                    BigInteger c2 = new BigInteger(j);
                    if (c1 * 100 / 99 == c2)
                    {
                        q = j;
                        break;
                    }
                }
            }*/
            BigInteger q = 0;
            int i = 100;
            while (true)
            {
                Console.WriteLine(i);//+ "  :  " + Bouncy(i.ToString()));
                if (Bouncy(i.ToString()))
                {
                    q++;
                    if (q * 100 / 99 == i) break;
                }
                i++;
            }
            Console.WriteLine(i);
            /*
            int count = 0;
            for (int i = 101; i < 990; i++)
            {
                if (Bouncy(i.ToString())) count++;
            }
            Console.WriteLine(count);
            Console.WriteLine(999 - (Recursion(2, 9) + Recursion(2, 10) + 99) + 9);*/
        }

        public static int Recursion(int n, int i)
        {
            if (n == 0) return i;
            int sum = 0;
            for (int j = 1; j <= i; j++)
            {
                sum += Recursion(n - 1, j);
            }
            return sum;
        }

        public static bool Bouncy(string s)
        {
            if (s.Length < 3) return false;
            bool b = true;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] - 48 > s[i + 1] - 48)
                {
                    b = false;
                    break;
                }
            }
            bool bb = true;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] - 48 < s[i + 1] - 48)
                {
                    bb = false;
                    break;
                }
            }
            return !(b || bb);
        }
    }
}
