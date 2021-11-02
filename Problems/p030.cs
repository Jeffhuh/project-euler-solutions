using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p030
    {
        public static void Solution()
        {
            int n = 0;
            for (int i = 2; i < 360_000; i++)
            {
                string s = i.ToString();
                int sum = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    int d = (s[j] - 48);
                    sum += d*d*d*d*d;
                }
                if (String.Equals(sum.ToString(), s))
                {
                    n += sum;
                }
            }
            Console.WriteLine(n);
        }
    }
}
