using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p034
    {
        public static void Solution()
        {
            int[] fact = { 1,1,2,6,24,120,720,5040,40320,362880};
            int sum = 0;
            for (int i = 100; i < 2_540_161; i++)
            {
                string s = i.ToString();
                int temp = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    temp += fact[s[j] - 48];
                }
                if (temp == i) sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
