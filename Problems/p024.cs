using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p024
    {
        public static void Solution()
        {
            int[] fact = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
            ArrayList digits = new ArrayList()
            {
                0,1,2,3,4,5,6,7,8,9
            };
            int i = 1_000_000;
            string perm = "";
            int k = 9;
            while (i != 0 && k != -1)
            {
                int n = (int)(Math.Ceiling((double)i / (double)fact[k]) - 1);
                i -= n * fact[k];
                perm = perm + digits[n];
                digits.RemoveAt(n);
                k--;
            }
            Console.WriteLine(perm);
        }
    }
}
