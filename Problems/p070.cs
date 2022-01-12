using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems
{
    internal class p070
    {
        static int[] primes;
        public static void Solution() // very slow
        {
            double min = Double.PositiveInfinity;
            int index = 0;
            for (int i = 1000; i < 10_000_001; i++)
            {
                int t = Totient(i);
                if (IsPermutation(t, i))
                {
                    double a = (double)i / (double)t;
                    if (min > a)
                    {
                        min = a;
                        index = i;
                    }
                }
            }
            Console.WriteLine(index);
        }

        public static bool IsPermutation(int a, int b)
        {
            string sA = a.ToString();
            string sB = b.ToString();
            if (sA.Length != sB.Length) return false;
            Dictionary<char, int> permA = new Dictionary<char, int>();
            Dictionary<char, int> permB = new Dictionary<char, int>();
            for (int i = 0; i < sA.Length; i++)
            {
                char cA = sA[i];
                char cB = sB[i];
                if (!permA.TryAdd(cA, 1))
                {
                    permA[cA]++;
                }
                if (!permB.TryAdd(cB, 1))
                {
                    permB[cB]++;
                }
            }
            if (permA.Count != permB.Count) return false;
            foreach (var pair in permA)
            {
                int value;
                if (permB.TryGetValue(pair.Key, out value))
                {
                    if (value != pair.Value) return false;
                } else return false;
            }
            return true;
        }

        public static int Totient(int n)
        {
            if (IsPrime(n)) return n - 1;
            Dictionary<int,int> primeFac = PrimeFactorization(n);
            int totient = 1;
            foreach (var i in primeFac)
            {
                totient *= (i.Key - 1);
                if (i.Value > 1)
                {
                    totient *= (i.Value - 1) * i.Key;
                }
            }
            return totient;
        }

        public static Dictionary<int,int> PrimeFactorization(int number)
        {
            Dictionary<int,int> dict = new Dictionary<int,int>();
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
