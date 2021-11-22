using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p065
    {
        public static void Solution()
        {
            BigInteger n1 = 1;
            BigInteger n2 = 2;
            BigInteger d1 = 1;
            BigInteger d2 = 3;
            for (int i = 4; i < 101; i++)
            {
                BigInteger n3;
                BigInteger d3;
                if (i % 3 == 0)
                {
                    int factor = i * 2 / 3;
                    n3 = n2 * factor + n1;
                    d3 = d2 * factor + d1;
                } else
                {
                    n3 = n1 + n2;
                    d3 = d1 + d2;
                }
                n1 = n2;
                n2 = n3;
                d1 = d2;
                d2 = d3;
            }
            string s = (2 * d2 + n2).ToString();
            int sum = 0;
            for (int i = 0; i < s.Length; i++)
            {
                sum += (s[i] - 48);
            }
            Console.WriteLine(sum);
        }
    }
}
