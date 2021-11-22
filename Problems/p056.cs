using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p056
    {
        public static void Solution()
        {
            int maxSum = 0;
            for (int i = 2; i < 100; i++)
            {
                if (i % 10 == 0) continue;
                for (int j = 50; j < 100; j++)
                {
                    BigInteger number = BigInteger.Pow(i,j);
                    string s = number.ToString();
                    int sum = 0;
                    for (int k = 0; k < s.Length; k++)
                    {
                        sum += (s[k] - 48);
                    }
                    if (sum > maxSum) maxSum = sum;
                }
            }
            Console.WriteLine(maxSum);
        }

    }
}
