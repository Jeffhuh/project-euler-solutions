using System;
using System.Collections;
using System.Collections.Generic;

namespace Problems
{
    internal class p087
    {
        public static void Solution()
        {
            int[] primes = ESieve((int)Math.Sqrt(50_000_000));
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < primes.Length; i++)
            {
                int sum1 = primes[i] * primes[i] * primes[i] * primes[i];
                if (sum1 > 49_999_999) break;
                for (int j = 0; j < primes.Length; j++)
                {
                    int sum2 = sum1 + primes[j] * primes[j] * primes[j];
                    if (sum2 > 49_999_999) break;
                    for (int k = 0; k < primes.Length; k++)
                    {
                        int sum3 = sum2 + primes[k] * primes[k];
                        if (sum3 > 49_999_999) break;
                        set.Add(sum3);
                    }
                }
            }
            Console.WriteLine(set.Count);
        }

        public static int[] ESieve(int upperLimit)
        {
            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;
            BitArray PrimeBits = new BitArray(sieveBound + 1, true);
            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }
            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);
            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }
            return numbers.ToArray();
        }
    }
}
