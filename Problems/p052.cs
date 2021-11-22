using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p052
    {
        public static void Solution()
        {
            int dL = 2;
            bool found = false;
            while (!found)
            {
                int lowerLimit = (int)Math.Pow(10, dL - 1);
                int upperLimit = (int)Math.Pow(10, dL) / 6;
                for (int j = lowerLimit; j < upperLimit; j++)
                {
                    string[] s = new string[6];
                    for (int i = 0; i < 6; i++)
                    {
                        s[i] = (j * (i + 1)).ToString();
                    }
                    if (IsPermutation(s))
                    {
                        Console.WriteLine(j);
                        found = true;
                        break;
                    }
                }
                dL++;
            }
        }

        public static bool IsPermutation(string[] numbers)
        {
            Dictionary<char, int> perm = new Dictionary<char, int>();
            for (int i = 0; i < numbers[0].Length; i++)
            {
                char c = numbers[0][i];
                if (!perm.TryAdd(c, 1))
                {
                    perm[c]++;
                }
            }
            for (int i = 1; i < numbers.Length; i++)
            {
                Dictionary<char, int> perm2 = new Dictionary<char, int>();
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    char c = numbers[i][j];
                    if (!perm2.TryAdd(c, 1))
                    {
                        perm2[c]++;
                    }
                }
                bool equal = false;
                if (perm.Count == perm2.Count)
                {
                    equal = true;
                    foreach (var pair in perm)
                    {
                        int value;
                        if (perm2.TryGetValue(pair.Key, out value))
                        {
                            if (value != pair.Value)
                            {
                                equal = false;
                                break;
                            }
                        }
                        else
                        {
                            equal = false;
                            break;
                        }
                    }
                }
                if (!equal)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
