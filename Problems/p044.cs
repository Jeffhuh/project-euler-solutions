using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p044
    {
        public static void Solution()
        {
            List<long> pentagonial = new List<long>();
            int i = 2;
            int j = 1;
            bool t = true;
            do
            {
                j = 1;
                int pentI = (i * (3 * i - 1)) >> 1;
                while (j < i)
                {
                    int pentJ = (j * (3 * j - 1)) >> 1;
                    if (IsPentagonal(pentI + pentJ) && IsPentagonal(Math.Abs(pentJ - pentI)))
                    {
                        Console.WriteLine(Math.Abs(pentJ - pentI));
                        t = false; 
                        break;
                    }
                    j++;
                }
                i++;
            } while (t);
        }

        public static bool IsPentagonal(int n)
        {
            double d = (1+Math.Sqrt(1 + 24 * n)) /6;
            if (d % 1 == 0) return true;
            return false;
        }
    }
}
