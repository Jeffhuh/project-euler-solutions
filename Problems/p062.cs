using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problems
{
    internal class p062
    {
        public static void Solution() 
        {
            List<List<long>> perm = new List<List<long>>();
            List<Dictionary<char, int>> fre = new List<Dictionary<char, int>>();
            long i = 0;
            while (true)
            {
                long l = i * i * i;
                string temp = l.ToString();
                Dictionary<char, int> dict = new Dictionary<char, int>();
                for (int j = 0; j < temp.Length; j++)
                {
                    char c = temp[j];
                    if (!dict.TryAdd(c, 1)) dict[c]++;
                }
                bool eq = true;
                for (int j = 0; j < fre.Count; j++)
                {
                    if (Equal(fre[j], dict))
                    {
                        List<long> p = perm[j];
                        p.Add(l);
                        if (p.Count > 4)
                        {
                            Console.WriteLine(p[0]);
                            return;
                        }
                        eq = false;
                        break;
                    }
                }
                if (eq)
                {
                    fre.Add(dict);
                    perm.Add(new List<long>() { l });
                }
                i++;
            }
        }

        public static bool Equal(Dictionary<char,int> dict1, Dictionary<char,int> dict2)
        {
            if (dict1.Count == dict2.Count)
            {
                foreach (var pair in dict1)
                {
                    int value;
                    if (dict2.TryGetValue(pair.Key, out value))
                    {
                        if (value != pair.Value)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
