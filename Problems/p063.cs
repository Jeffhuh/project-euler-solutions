using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p063
    {
        public static void Solution()
        {
            int numbers = 1;
            for (int i = 2; i < 10; i++)
            {
                int exp = 1;
                int nL = 0;
                do
                { 
                    nL = BigInteger.Pow(i, exp).ToString().Length;
                    if (nL == exp)
                    {
                        numbers++;
                    }
                    exp++;
                } while (nL <= i || nL == (exp-1));
            }
            Console.WriteLine(numbers);
        }
    }
}
