using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p021
    {
        public static void Solution()
        {
            int[] sum = new int[10_000];
            for (int i = 1; i < 10_001; i++)
            {
                sum[i - 1]++;
                int sqrt = (int)Math.Sqrt(i);
                for (int j = 2; j <= sqrt; j++)
                {
                    if (i % j == 0)
                    {
                        sum[i - 1] += j + i / j;
                        if (sqrt * sqrt == i)
                        {
                            sum[i - 1] -= sqrt;
                        }
                    }
                }
            }
            int count = 0;
            for (int i = 1; i < 10_001; i++)
            {
                int n = sum[i - 1];
                if (n != i && n < 10_001 && sum[n - 1] == i)
                {
                    count += n;
                }
            }
            Console.WriteLine(count);
        }
    }
}
