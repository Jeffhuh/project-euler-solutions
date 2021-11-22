using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p061
    {
        public static void Solution()
        {
            List<int> l1 = new List<int>();
            List<int> l2 = new List<int>();
            List<int> l3 = new List<int>();
            List<int> l4 = new List<int>();
            List<int> l5 = new List<int>();
            List<int> l6 = new List<int>();
            List<List<int>> bb = new List<List<int>>();
            int i = 1;
            int j = 2;
            while (i < 10_000)
            {
                if (i > 999)
                {
                    l1.Add(i);
                }
                i += j;
                j++;
            }
            i = 1;
            j = 2;
            while (i < 10_000)
            {
                if (i > 999)
                {
                    l2.Add(i);
                }
                i = j * j;
                j++;
            }
            i = 1;
            j = 2;
            while (i < 10_000)
            {
                if (i > 999)
                {
                    l3.Add(i);
                }
                i = j * (3 * j - 1) / 2;
                j++;
            }
            i = 1;
            j = 2;
            while (i < 10_000)
            {
                if (i > 999)
                {
                    l4.Add(i);
                }
                i = j * (2 * j - 1);
                j++;
            }
            i = 1;
            j = 2;
            while (i < 10_000)
            {
                if (i > 999)
                {
                    l5.Add(i);
                }
                i = j * (5 * j - 3) / 2;
                j++;
            }
            i = 1;
            j = 2;
            while (i < 10_000)
            {
                if (i > 999)
                {
                    l6.Add(i);
                }
                i = j * (3 * j - 2);
                j++;
            }
            bb.Add(l1);
            bb.Add(l2);
            bb.Add(l3);
            bb.Add(l4);
            bb.Add(l5);
            List<int> b = new List<int>();
            List<int> type = new List<int>();
            for (i = 0; i < bb.Count; i++)
            {
                List<int> temp = bb[i];
                for (j = 0; j < temp.Count; j++)
                {
                    b.Add(temp[j]);
                    type.Add(i);
                }
            }
            List<int> skip = new List<int>();
            for (i = 0; i < l6.Count; i++)
            {
                for (j = 0; j < b.Count; j++)
                {
                    if (Cyclic(l6[i], b[j]))
                    {
                        skip.Add(type[j]);
                        for (int k = 0; k < b.Count; k++)
                        {
                            int t = type[k];
                            if (Skip(t, skip)) continue;
                            if (Cyclic(b[j], b[k]))
                            {
                                skip.Add(t);
                                for (int l = 0; l < b.Count; l++)
                                {
                                    t = type[l];
                                    if (Skip(t, skip)) continue;
                                    if (Cyclic(b[k], b[l]))
                                    {
                                        skip.Add(t);
                                        for (int m = 0; m < b.Count; m++)
                                        {
                                            t = type[m];
                                            if (Skip(t, skip)) continue;
                                            if (Cyclic(b[l], b[m]))
                                            {
                                                skip.Add(t);
                                                for (int n = 0; n < b.Count; n++)
                                                {
                                                    t = type[n]; 
                                                    if (Skip(t, skip)) continue;
                                                    if (Cyclic(b[m], b[n]) && Cyclic(b[n], l6[i]))
                                                    {
                                                        Console.WriteLine(l6[i]+b[j]+b[k]+b[l]+b[m]+b[n]);
                                                        return;
                                                    }
                                                }
                                                skip.RemoveAt(skip.Count - 1);
                                            }
                                        }
                                        skip.RemoveAt(skip.Count - 1);
                                    }
                                }
                                skip.RemoveAt(skip.Count - 1);
                            }
                        }
                        skip.RemoveAt(skip.Count - 1);
                    }
                }
            }
        }

        public static bool Skip(int t, List<int> skip)
        {
            for (int q = 0; q < skip.Count; q++)
            {
                if (t == skip[q]) return true;
            }
            return false;
        }

        public static bool Cyclic(int n1, int n2)
        {
            return (n1 % 100) == (n2 / 100);
        }
    }
}
