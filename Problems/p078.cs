using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p078
    {
        static Dictionary<long, int> pN = new Dictionary<long, int> ();
        public static void Solution()
        {
            int k = 1;
            pN.Add(0, 1);
            while (true)
            {
                if (p(k) == 0)
                {
                    Console.WriteLine(k);
                    return;
                }
                k++;
            }
        }

        public static int p(long n)
        {
            if (pN.ContainsKey(n)) return pN[n];
            int k = 1;
            long sum = 0;
            int positiv = 1;
            do
            {
                int z = k * (3 * k - 1) / 2;
                if (z > n) break;
                sum += p(n - z) * positiv;
                if (z + k > n) break;
                else sum += p(n - z - k) * positiv;
                positiv *= -1;
                k++;
            } while (true);
            int a = (int) (sum % 1_000_000);
            pN.Add(n, a);
            return a;
        }
    }
}
