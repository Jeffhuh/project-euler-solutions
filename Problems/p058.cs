using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p058
    {
        public static void Solution()
        {
            int primes = 3;
            int diagonal = 5;
            int side = 3;
            while ((double)primes/(double)diagonal >= 0.10d)
            {
                diagonal += 4;
                side += 2;
                int area = side * side;
                for (int i = 1; i < 4; i++)
                {
                    area -= (side - 1);
                    if (IsPrime(area)) primes++;
                }
            }
            Console.WriteLine(side);
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
