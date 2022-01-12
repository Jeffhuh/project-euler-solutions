using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p074
    {
        private static Dictionary<int, int> factorials = new Dictionary<int, int>()
        {
            {0,1},{1,1},{2,2},{3,6},{4,24},{5,120},{6,720},{7,5040},{8,40320},{9,362880}
        };
        public static void Solution()
        {
            int count = 0;
            for (int i = 0; i < 1_000_000; i++)
            {
                List<long> list = new List<long>();
                long temp = i;
                while (!list.Contains(temp))
                {
                    list.Add(temp);
                    temp = DigitFactorial(temp);
                }
                if (list.Count == 60) count++;
            }
            Console.WriteLine(count);
        }

        public static long DigitFactorial(long n)
        {
            string s = n.ToString();
            long sum = 0; 
            for (int i = 0; i < s.Length;i++)
            {
                sum += factorials[s[i]-48];
            }
            return sum; 
        }
    }
}
