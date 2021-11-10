using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p045
    {
        public static void Solution()
        {
            long t = 40_755;
            int ti = 285;
            do
            {
                ti++;
                t += ti;
            } while (!Pentagonal(t) || !Hexagonal(t));
            Console.WriteLine(t);
        }

        public static bool Pentagonal(long n)
        {
            double d = (1 + Math.Sqrt(1 + 24 * n)) / 6;
            if (d % 1 == 0) return true;
            return false;
        }

        public static bool Hexagonal(long n)
        {
            double d = (1 + Math.Sqrt(1 + 8 * n)) / 4;
            if (d % 1 == 0) return true;
            return false;
        }
    }
}
