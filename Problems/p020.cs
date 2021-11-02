using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Problems
{
    class p020
    {
        public static void Solution()
        {
            int sum = 0;
            BigInteger fac = 3628800;
            for (int i = 11; i <= 100; i++)
            {
                fac *= i;
            }
            while (fac > 0)
            {
                sum += (int)(fac % 10);
                fac /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
