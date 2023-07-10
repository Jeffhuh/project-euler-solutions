using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p108
    {
        public static void Solution()
        {
            long i = 1;
            while (true)
            {
                i++;
                Dictionary<int, int> fact = PrimeFactorization(i * i);
                long d = 1;
                foreach (var j in fact.Values)
                {
                    d *= j + 1;
                }
                if (((d + 1) >> 1) > 1000) break;
            }
            Console.WriteLine(i);
        }

        public static Dictionary<int, int> PrimeFactorization(long number)
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
            if (number != 1) dict.Add((int)number, 1);
            return dict;
        }
    }
}
