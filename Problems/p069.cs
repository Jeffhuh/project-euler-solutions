using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p069
    {
        public static void Solution()
        {
            int[] primes = ESieve(1_000);
            int prime = 1;
            int i = 0;
            while (prime * primes[i] <= 1_000_000)
            {
                prime *= primes[i++];
            }
            Console.WriteLine(prime);
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
