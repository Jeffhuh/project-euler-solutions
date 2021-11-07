using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p039
    {
        public static void Solution()
        {
            int max = 0;
            int maxP = 0;
            for (int p = 12; p < 1001; p++)
            {
                int upperC = p / 2;
                int count = 0;
                for (int a = 3; a < upperC; a++)
                {
                    for (int b = 3; b < upperC; b++)
                    {
                        int c = p - a - b;
                        if (c < upperC && c > a && c > b)
                        {
                            if (c * c == (a * a + b * b))
                            {
                                count++;
                            }
                        }
                    }
                }
                if (count > max)
                {
                    max = count;
                    maxP = p;
                }
            }
            Console.WriteLine(maxP);
        }
    }
}
