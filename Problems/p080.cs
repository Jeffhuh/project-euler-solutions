using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p080
    {
        public static void Solution()
        {
            Dictionary<int, int> baseN = new Dictionary<int, int>();
            int sum = 0;
            for (int i = 2; i < 101; i++)
            {
                if (Math.Sqrt(i) % 1 == 0) continue;
                Dictionary<int, int> primeFact = PrimeFactorization(i);
                int multiplier = 1;
                int number = 1;
                foreach (var j in primeFact)
                {
                    number *= (j.Value & 1) == 1 ? j.Key : 1;
                    for (int k = j.Value / 2 - 1; k >= 0; k--) multiplier *= j.Key;
                }
                if (baseN.ContainsKey(number))
                {
                    sum += multiplier * baseN[number];
                    continue;
                }
                BigInteger z = 0;
                BigInteger limit = i;
                for (int j = 0; j < 100; j++)
                {
                    int k = 0;
                    while ((10 * z + k + 1) * (k + 1) < limit) k++;
                    sum += k;
                    limit = (limit - k * (10 * z + k)) * 100;
                    z = 10 * z + 2 * k;
                }
            }
            Console.WriteLine(sum);
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
