using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p073
    {
        public static void Solution()
        {
            int count = 0;
            for (int i = 2; i < 12_001; i++)
            {
                int upperNum = (i & 1) == 0 ? i / 2 : i / 2 + 1;
                int lowerNum = i / 3 + 1;
                for (int j = lowerNum; j < upperNum; j++)
                {
                    if (gcd(j,i) == 1)
                    {
                        count++;
                    }
                }
                
            }
            Console.WriteLine(count);
        }

        public static int gcd(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a | b;
        }
    }
}
