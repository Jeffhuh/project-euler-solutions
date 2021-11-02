using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p035
    {
        public static void Solution()
        {
            int[] primes = ESieve(1_000_000);
            int count = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                string s = primes[i].ToString();
                bool cp = true;
                int sL = s.Length;
                for (int j = 1; j < sL; j++)
                {
                    string nR = string.Empty;
                    for (int k = 0; k < sL; k++)
                    {
                        nR = nR + s[(j+k) % sL];
                    }
                    int min = 0, max = primes.Length - 1, index = -1, sR = Int32.Parse(nR);
                    while (min <= max)
                    {
                        int mid = (min + max) / 2;
                        if (sR == primes[mid])
                        {
                            index = mid;
                            break;
                        }
                        if (sR < primes[mid])
                        {
                            max = mid - 1;
                        } else
                        {
                            min = mid + 1;
                        }
                    }
                    if (index == -1)
                    {
                        cp = false;
                        break;
                    }
                }
                if (cp) count++;
            }
            Console.WriteLine(count);
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
    }
}
