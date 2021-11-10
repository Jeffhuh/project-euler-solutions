using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p047
    {
       public static void Solution()
       {
            int i = 10;
            while(true)
            {
                bool a = true;
                for (int j = 0; j < 4; j++)
                {
                    if (!FourDistinctPrimes(i+j))
                    {
                        a = false;
                        i += j;
                        break;
                    }
                }   
                if (a)
                {
                    Console.WriteLine(i);
                    break;
                }
                i++;
            }
       }

        public static bool FourDistinctPrimes(int number)
        {
            List<int> primes = new List<int>();
            int n = number;
            if (number % 2 == 0)
            {
                primes.Add(2);
                while ((number & 1) == 0) number = number >> 1;
            }
            int i = 3;
            while (i * i <= number)
            {
                if (number % i == 0)
                {
                    primes.Add(i);
                    while(number % i == 0)
                    {
                        number /= i;
                    }
                }
                i += 2;
            }
            if (number != 1)
            {
                primes.Add(0);
            }
            return primes.Count == 4;
        }
    }
}
