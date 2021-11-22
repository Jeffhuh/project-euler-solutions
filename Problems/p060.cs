using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems
{
    internal class p060
    {
        static int[] primes;
        public static void Solution()
        {
            primes = ESieve(35_000);
            HashSet<int>[] reference = new HashSet<int>[primes.Length];
            int min = int.MaxValue;
            for (int i = 1; i < primes.Length; i++) // 1
            {
                if (primes[i] * 5 >= min) break;
                if (reference[i] == null) reference[i] = References(i);
                for (int j = i + 1; j < primes.Length; j++) // 2
                {
                    if (primes[i] + primes[j] * 4 >= min) break;
                    if (!reference[i].Contains(primes[j])) continue;
                    if (reference[j] == null) reference[j] = References(j);
                    for (int k = j + 1; k < primes.Length; k++) // 3
                    {
                        if (primes[i] + primes[j] + primes[k] * 3 >= min) break;
                        if (!reference[j].Contains(primes[k]) || !reference[i].Contains(primes[k])) continue;
                        if (reference[k] == null) reference[k] = References(k);
                        for (int l = k + 1; l < primes.Length; l++) // 4
                        {
                            if (primes[i] + primes[j] + primes[k] + primes[l] * 2 >= min) break;
                            if (!reference[k].Contains(primes[l]) || !reference[j].Contains(primes[l]) || !reference[i].Contains(primes[l])) continue;
                            if (reference[l] == null) reference[l] = References(l);
                            for (int m = l + 1; m < primes.Length; m++) // 5
                            {
                                int temp = primes[i] + primes[j] + primes[k] + primes[l] + primes[m];
                                if (temp >= min) continue;
                                if (!reference[l].Contains(primes[m]) || !reference[k].Contains(primes[m]) || !reference[j].Contains(primes[m]) || !reference[i].Contains(primes[m])) continue;
                                if (temp < min) min = temp;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(min);
        }

        public static HashSet<int> References(int a)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = a + 1; i < primes.Length; i++)
            {
                if (IsPrime(long.Parse(primes[a].ToString()+primes[i].ToString())) && IsPrime(long.Parse(primes[i].ToString()+primes[a].ToString())))
                {
                    set.Add(primes[i]);
                }
            }
            return set;
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
