using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problems
{
    internal class p105
    {
        public static void Solution()
        {
            using (StreamReader sr = new StreamReader("../../../Files/p105.txt"))
            {
                string line = string.Empty;
                int sum = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    List<int> list = line.Split(",").ToList().Select(x => int.Parse(x)).ToList();
                    list.Sort();
                    if (C1(list) && C2(list)) sum += list.Sum();
                }
                Console.WriteLine(sum);
            }
        }

        public static bool C1(List<int> list)
        {
            int n = 1 << list.Count;
            HashSet<int> set = new HashSet<int>();
            for (int i = 1; i < n; i++)
            {
                int a = i;
                int b = 0;
                int j = 0;
                while (a != 0)
                {
                    if ((a & 1) == 1) b += list[j];
                    a >>= 1;
                    j++;
                }
                if (set.Contains(b)) return false;
                set.Add(b);
            }
            return true;
        }

        public static bool C2(List<int> list)
        {
            int n = list.Count / 2 + ((list.Count & 1) == 1 ? 1 : 0);
            int l = list[0];
            int r = 0;
            for (int i = 1; i < n; i++)
            {
                l += list[i];
                r += list[list.Count - i];
                if (l <= r) return false;
            }
            return true;
        }
    }
}
