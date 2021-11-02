using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p029
    {
        public static void Solution()
        {
            int[] primes = new int[25];
            primes[0] = 2;
            int q = 0;
            for (int i = 3; i < 101; i++)
            {
                bool p = true;
                int j = 3;
                while (j * j <= i)
                {
                    if (i % j == 0)
                    {
                        p = false; 
                        break;
                    }
                    j += 2;
                }
                if (p && (i & 1) == 1)
                {
                    primes[++q] = i;
                }
            }
            int dt = 9801;
            for (int i = 2; i < 101; i++)
            {
                bool f = true;
                bool equal = true;
                int exp = 1;
                for (int j = 0; j < primes.Length; j++)
                {
                    if (i * i < primes[j]) break;
                    int div = 0;
                    int n = i;
                    while (n % primes[j] == 0)
                    {
                        div++;
                        n /= primes[j];
                    }
                    if (f && div != 0)
                    {
                        exp = div;
                        f = false;
                    }
                    else if (exp != div && div != 0)
                    {
                        equal = false; 
                        break;
                    }
                }
                if (equal && exp != 1)
                {
                    dt -= (int)Math.Floor(100d/(double)exp - 1);
                    Console.WriteLine(i + "   :    " + exp);
                }
            }
            Console.WriteLine(dt);
        }
    }
}
