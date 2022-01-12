using System;
using System.Collections;
using System.Collections.Generic;

namespace Problems
{
    internal class p077
    {
        private static Dictionary<int, int> primeSum = new Dictionary<int, int>();
        private static int[] primes = ESieve(10_000);
        public static void Solution()
        {
            primeSum.Add(0, 1);
            primeSum.Add(1, 0);
            primeSum.Add(2, 1);
            primeSum.Add(3, 1);
            int i = 4;
            while (true)
            {
                
                int combinations = PrimeSumCombinations(i, i);
                if (combinations > 5000)
                {
                    Console.WriteLine(i);
                    return;
                }
                primeSum.Add(i, combinations);
                i++;
            }
        }

        public static int PrimeSumCombinations(int n, int max)
        {
            if (n <= max && primeSum.ContainsKey(n)) return primeSum[n];
            int combinations = 0;
            int index = 0;
            while (primes[index++] <= max);
            index--;
            for (int i = index - 1; 0 <= i; i--)
            {
                int d = primes[i];
                combinations += PrimeSumCombinations(n - d, d);
            }
            return combinations;
        }

        /*public static int PrimeSumCombinations(int n)
        {
            if (primeSum.ContainsKey(n)) return primeSum[n];
            int index = 0;
            while (primes[index++] <= n);
            index--;
            Console.WriteLine(n +" : "+index);
            int combinations = 0;
            for (int i = index - 1; 0 <= i; i--)
            {
                int r = n % primes[i];
                if (r == 1) continue;
                int d = n / primes[i];
                int combT = 1;
                if (r == 0 && d == 1) return 1;
                if (r != 0) combT = PrimeSumCombinations(r);
                for (int j = 0; j < d; j++)
                {
                    combT *= PrimeSumCombinations(primes[i]);
                }
                combinations += combT;
            }
            return combinations;
        }*/

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
