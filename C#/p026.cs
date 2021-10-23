using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problem_16_50
{
    class p026
    {
        public static void Solution()
        {
            int recN = 1;
            int index = 0;
            ArrayList mp = new ArrayList();
            for (int i = 7; i < 1_000; i++)
            {
                mp.Clear();
                int rem = 1;
                while (rem != 0 && !mp.Contains(rem))
                {
                    mp.Add(rem);
                    rem *= 10;
                    rem %= i;
                }
                if (mp.Contains(rem))
                {
                    int n = mp.Count - mp.IndexOf(rem);
                    if (n > recN)
                    {
                        recN = n;
                        index = i;
                    }
                }
            }
            Console.WriteLine(index);
        }
     }
}
