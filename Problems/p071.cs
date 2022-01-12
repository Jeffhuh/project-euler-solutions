using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p071
    {
        public static void Solution()
        {
            double d = 3d / 7d;
            double max = 0;
            int index = 0;
            for (int i = 8; i < 1_000_001; i++)
            {
                double temp = Math.Floor(i * d)/(double)i;
                if (temp > max && temp < d)
                {
                    max = temp;
                    index = i;
                }
            }
            int num = (int)(d * index);
            if (num % 2 == 0)
            {
                while (num % 2 == 0  && index % 2 == 0)
                {
                    num >>= 1;
                    index >>= 1;
                }
            }
            int j = 3;
            while (j * j < num)
            {
                if (num % j == 0 && index % j == 0)
                {
                    while (num % j == 0 && index % j == 0)
                    {
                        num /= j;
                        index /= j;
                    }
                }
                j += 2;
            }
            Console.WriteLine(num);
        }
    }
}
