using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Problems
{
    internal class p079
    {
        public static void Solution()
        {
            List<string> input = new List<string>();
            List<int> list = new List<int>() { 0, 1, 2, 3, 6, 7, 8, 9 };
            using (StreamReader sr = new StreamReader("../../../Files/p079.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!input.Contains(line)) input.Add(line);
                }
            }
            for (int i = 0; i < input.Count; i++)
            {
                string s = input[i];
                for (int j = 0; j < 2; j++)
                {
                    int a = (s[j] - 48);
                    int b = (s[j + 1] - 48);
                    int indexA = list.IndexOf(a);
                    if (b < a && list.IndexOf(b) < indexA)
                    {
                        list.Remove(b);
                        bool bb = true;
                        for (int k = indexA; k < list.Count; k++)
                        {
                            if (b < list[k])
                            {
                                list.Insert(k, b);
                                bb = false;
                                break;
                            }
                        }
                        if (bb) list.Insert(list.Count, b);
                    }
                }
            }
            foreach (var i in list)
            {
                Console.Write(i);
            }
        }
    }
}
