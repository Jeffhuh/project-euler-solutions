using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p085
    {
        public static void Solution()
        {
            int l = 1;
            int lK = 1;
            int d = int.MaxValue;
            int a = 0;
            while (lK < 1_000_000)
            { 
                int b = (int)(-0.5 + Math.Sqrt(0.25+4_000_000d/(double)lK));
                b = Math.Abs(b * (b + 1) / 2 * lK - 2_000_000) > Math.Abs((b + 1) * (b + 2) * lK / 2 - 2_000_000) ? b + 1 : b;
                int dd = Math.Abs(b * (b + 1) / 2 * lK - 2_000_000);
                if (dd < d)
                {
                    a = l * b;
                    d = dd;
                }
                l++;
                lK += l;
            }
            Console.WriteLine(a);
        }
    }
}
