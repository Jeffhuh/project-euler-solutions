using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p053
    {
        public static void Solution()
        {
            int count = 0; 
            for (int i = 23; i < 101; i++)
            {
                int n = 2;
                long product = i;
                for (int j = 2; j < i; j++)
                {
                    product *= (i - j + 1);
                    product /= j;
                    if (product > 1_000_000)
                    {
                        count += (i + 1) - 2 * n;
                        break;
                    }
                    n++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
