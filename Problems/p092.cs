using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p092
    {
        static List<int> l89;
        static int count;
        public static void Solution()
        {
            List<int> l1 = new List<int>(); 
            l1.Add(1);
            l89 = new List<int>(); 
            l89.Add(89);
            for (int i = 2; i < 568; i++)
            {
                string s = i.ToString();
                int number = i;
                List<int> list = new List<int>();
                while (true)
                {
                    if (l1.Contains(number))
                    {
                        foreach (int j in list)
                        {
                            l1.Add(j);
                        }
                        break;
                    }
                    if (l89.Contains(number))
                    {
                        foreach (int j in list)
                        {
                            l89.Add(j);
                        }
                        break;
                    }
                    if (number < 568) list.Add(number);
                    number = 0;
                    for (int j = 0; j < s.Length; j++)
                    {
                        int a = s[j] - 48;
                        number += a * a;
                    }
                    s = number.ToString();
                }
            }
            Recursion(0, 7);
            Console.WriteLine(count);
        }

        public static void Recursion(int d, int it)
        {
            if (it == 0)
            {
                if (l89.Contains(d)) count++;
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                Recursion(d + i * i, it - 1);
            }
        }
    }
}
