using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace Problems
{
    internal class p110
    {
        public static void Solution()
        {
            int div = 4_000_000;
            div <<= 1;
            int a = (int) Math.Ceiling(Math.Log(div) / Math.Log(3));
            List<int> exp = Enumerable.Repeat(1, a).ToList();
            int[] primes = new int[a];
            primes[0] = 2;
            int p = 3;
            int c = 1;
            while (c != a)
            {
                int k = 3;
                bool bb = true;
                while (k * k <= p)
                {
                    if (p % k == 0)
                    {
                        bb = false;
                        break;
                    }
                    k += 2;
                }
                if (bb) primes[c++] = p;
                p += 2;
            }
            int j = a - 1;
            bool b = true;
            while (b)
            {
                b = false;
                for (int k = 2; k < primes[j]; k++)
                {
                    Dictionary<int, int> pf = PrimeFactorization(k);
                    List<int> list = new List<int>();
                    for (int l = 0; l < exp.Count - 1; l++)
                    {
                        if (pf.ContainsKey(primes[l])) list.Add(exp[l] + pf[primes[l]]);
                        else list.Add(exp[l]);
                    }
                    int prod = 1;
                    for (int i = 0; i < list.Count; i++)
                    {
                        prod *= (list[i] << 1) + 1;
                    }
                    if (prod > div)
                    {
                        exp.RemoveAt(exp.Count - 1);
                        for (int l = 0; l < exp.Count; l++) if (pf.ContainsKey(primes[l])) exp[l] += pf[primes[l]];
                        b = true;
                        break;
                    }
                }
                j--;
            }
            long n = 1;
            for (int i = 0; i < exp.Count; i++) for (int k = 0; k < exp[i]; k++) n *= primes[i];
            Console.WriteLine(n);
        }

        public static Dictionary<int, int> PrimeFactorization(int number)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            if ((number & 1) == 0)
            {
                int exp = 0;
                while ((number & 1) == 0)
                {
                    number >>= 1;
                    exp++;
                }
                dict.Add(2, exp);
            }
            int i = 3;
            while (i * i <= number)
            {
                if (number % i == 0)
                {
                    int exp = 0;
                    while (number % i == 0)
                    {
                        number /= i;
                        exp++;
                    }
                    dict.Add(i, exp);
                }
                i += 2;
            }
            if (number != 1) dict.Add(number, 1);
            return dict;
        }
    }
}
