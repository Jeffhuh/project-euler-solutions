using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Problems
{
    internal class p072
    {
        public static void Solution()
        {
            long sum = 0;
            for (int i = 2; i < 1_000_001; i++)
            {
                sum += Totient(i);
            }
            Console.WriteLine(sum);
        }

        public static int Totient(int n)
        {
            if (IsPrime(n)) return n - 1;
            int product = 1; 
            if ((n & 1) == 0)
            {
                while ((n & 1) == 0)
                {
                    n >>= 1;
                    product <<= 1;
                }
                product >>= 1;
            }
            int i = 3; 
            while (i * i <= n)
            {
                if (n % i == 0)
                {
                    product *= (i - 1);
                    while (n % i == 0)
                    {
                        n /= i;
                        product *= i;
                    }
                    product /= i;
                }
                i += 2;
            }
            if (n != 1) product *= (n - 1);
            return product;
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
