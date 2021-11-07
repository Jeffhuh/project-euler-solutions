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
                bool first = true;
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
                    if (first && div != 0)
                    {
                        exp = div;
                        first = false;
                    }
                    else if (exp != div && div != 0)
                    {
                        equal = false; 
                        break;
                    }
                }
                if (equal && exp != 1)
                {
                    for (int j = 1; j < exp; j++)
                    {
                        for (int k = 100 * (j - 1) + 1 + j; k <= j * 100; k++) // I have no fucking clue how I came up with this line of code, but it somehow works, even though it doesnt consider the cases like exp = 5 and k = 330, where j is 4 and checks for divisibility of 4, but 330 is divisble by 5 & 6 therefore we should dt-- which doesnt happen, because we check for divisibility of 5 in the next iteration between 400-500
                        {
                            if (k % j == 0 && k % exp == 0)
                            {
                                dt--;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(dt);
        }
    }
}
