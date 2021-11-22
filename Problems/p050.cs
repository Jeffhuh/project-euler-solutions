using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p050
    {
        public static void Solution()
        {
            int[] primes = ESieve(1_000_000);
            long maxConseq = 0;
            int maxSums = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                long sumP = 0;
                long tempMax = 0;
                int it = 0;
                for (int j = i; j < primes.Length; j++)
                {
                    sumP += primes[j];
                    if (sumP > 999_999)
                    {
                        break;
                    }
                    if (IsPrime(sumP))
                    {
                        tempMax = sumP;
                        it = j - i + 1;
                    }
                }
                if (it >= maxSums)
                {
                    if (it == maxSums)
                    {
                        if (maxConseq < tempMax)
                        {
                            maxConseq = tempMax;
                        }
                    } else
                    {
                        maxSums = it;
                        maxConseq = tempMax;
                    }
                }
            }
            
            Console.WriteLine(maxConseq);
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
            ArrayList numbers = new ArrayList((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);
            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }
            return (int[])numbers.ToArray(typeof(int));
        }

        public static bool IsPrime(long number)
        {
            if (number % 2 == 0 || number < 2)
            {
                if (number == 2) return true;
                return false;
            }
            long i = 3;
            while (i * i <= number)
            {
                if (number % i == 0) return false;
                i += 2;
            }
            return true;
        }
    }
}
