using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p091
    {
        public static void Solution()
        {
            int count = 0;
            for (int i = 1; i < 51; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    if (gcd(i, j) != 1) continue;
                    int x1 = j; 
                    int y1 = i;
                    while (y1 <= 50)
                    {
                        int x2 = x1 - i;
                        int y2 = y1 + j;
                        while (0 <= x2 && y2 <= 50)
                        {
                            count++;
                            x2 -= i;
                            y2 += j;
                        }
                        x2 = x1 + i;
                        y2 = y1 - j;
                        while (x2 <= 50 && 0 <= y2)
                        {
                            count++;
                            x2 += i;
                            y2 -= j;
                        }
                        x1 += j;
                        y1 += i;
                    }
                }
            }
            Console.WriteLine(2 * count + 50 * (3 * 50 + 25));
        }

        public static int gcd(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }
            return a | b;
        }
    }
}
