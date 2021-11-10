using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p046
    {
        public static void Solution()
        {
            List<int> primes = new List<int>();
            primes.Add(3);
            primes.Add(5);
            primes.Add(7);
            int n = 9;
            while (true)
            {
                n += 2; 
                if (IsPrime(n))
                {
                    primes.Add(n);
                } else
                {
                    bool c = true;
                    int i = 0;
                    do
                    {
                        int prime = primes[i];
                        int j = 0;
                        while (prime + 2 * j * j < n)
                        {
                            j++;
                            if (prime + 2 * j * j == n)
                            {
                                c = false;
                                break;
                            }
                        }
                        i++;
                    } while (i < primes.Count);
                    if (c)
                    {
                        Console.WriteLine(n);
                        break;
                    }
                }
            }
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
