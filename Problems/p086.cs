using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p086
    {
        public static void Solution()
        {
            int count = 0;
            int m = 0;
            while (count < 1_000_001)
            {
                m++;
                for (int i = 1; i <= m; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        if (Math.Sqrt(m * m + (i+j) * (i+j)) % 1 == 0) count++;
                    }
                }
            }
            Console.WriteLine(m);
        }
    }
}
