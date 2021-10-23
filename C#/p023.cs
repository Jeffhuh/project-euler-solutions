using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problem_16_50
{
    class p023
    {
        public static void Solution()
        {
            ArrayList abundantN = new ArrayList();
            for (int i = 1; i < 28_124; i++)
            {
                int sum = 1;
                int p = 2;
                int n = i;
                while(p * p <= n && n > 1)
                {
                    if (n % p == 0)
                    {
                        int j = p * p;
                        n /= p;
                        while (n % p == 0)
                        {
                            j *= p;
                            n /= p;
                        }
                        sum *= (j - 1) / (p - 1);
                    }
                    if ((p & 1) == 1)
                    {
                        p += 2;
                    } else
                    {
                        p = 3;
                    }
                }
                if (n > 1)
                {
                    sum *= (n + 1);
                }
                sum -= i;
                if (i < sum)
                {
                    abundantN.Add(i);
                }
            }
            long count = 28_124 * 28_123 / 2;
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < abundantN.Count; i++)
            {
                for (int j = i; j < abundantN.Count; j++)
                {
                    int n = (int)abundantN[j] + (int)abundantN[i];
                    if (n < 28_124)
                    {
                        set.Add(n);
                    }
                }
            }
            foreach (int i in set)
            {
                count -= i;
            }
            Console.WriteLine(count);
        }
    }
}
