using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Problems
{
    internal class p103
    {
        public static void Solution()
        {
            List<int> list = new List<int>() { 15, 26, 33, 34, 35, 37, 40 };
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            int it = (int)Math.Pow(10, list.Count);
            List<int> l;
            for (int i = 0; i < it; i++)
            {
                l = new List<int>(list);
                string s = i.ToString();
                for (int j = 0; j < s.Length; j++) l[l.Count - 1 - j] += s[j] - 48;
                int temp = l[0];
                bool b = true;
                for (int j = 1; j < l.Count; j++)
                {
                    if (l[j] <= temp)
                    {
                        b = false; 
                        break;
                    }
                    temp = l[j];
                }
                if (b && C1(l) && C2(l))
                {
                    dict.TryAdd(l.Sum(), l);
                }
            }
            List<int> a = dict[dict.Keys.Min()];
            foreach (var i in a) Console.Write(i);
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
