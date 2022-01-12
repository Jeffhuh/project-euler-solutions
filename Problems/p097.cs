using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p097
    {
        public static void Solution()
        {
            long n = 1;
            int it = 7_830_457;
            while (it >= 28)
            {
                n <<= 28;
                n %= 10_000_000_000L;
                it -= 28;
            }
            n <<= it;
            n %= 10_000_000_000L;
            n *= 28_433;
            n++;
            n %= 10_000_000_000L;
            Console.WriteLine(n);
        }
    }
}
