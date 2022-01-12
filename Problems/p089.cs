using System;
using System.Collections.Generic;
using System.IO;

namespace Problems
{
    internal class p089
    {
        public static void Solution()
        {
            Dictionary<char, int> values = new Dictionary<char, int>() { ['I'] = 1, ['V'] = 5, ['X'] = 10, ['L'] = 50, ['C'] = 100, ['D'] = 500, ['M'] = 1000 };
            int saved = 0;
            using (StreamReader sr = new StreamReader("../../../Files/p089.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int sum = 0;
                    int l = line.Length;
                    for (int i = 0; i < l; i++)
                    {
                        char c = line[i];
                        char c1 = i + 1 < l ? line[i + 1] : '\0'; 
                        if (c == 'I' && (c1 == 'V' || c1 == 'X'))
                        {
                            if (c1 == 'V') sum += 4;
                            else sum += 9;
                            i++;
                            continue;
                        }
                        if (c == 'X' && (c1 == 'L' || c1 == 'C'))
                        {
                            if (c1 == 'L') sum += 40;
                            else sum += 90;
                            i++;
                            continue;
                        }
                        if (c == 'C' && (c1 == 'D' || c1 == 'M'))
                        {
                            if (c1 == 'D') sum += 400;
                            else sum += 900;
                            i++;
                            continue;
                        }
                        sum += values[c];
                    }
                    int ln = 0;
                    for (int i = 2; i >= 0; i--)
                    {
                        int a = (int)Math.Pow(10, i);
                        ln += sum / (10 * a);
                        sum %= (10 * a);
                        if (sum / (9 * a) == 1) ln += 2;
                        sum %= (9 * a);
                        if (sum / (5 * a) == 1) ln++;
                        sum %= (5 * a);
                        if (sum / (4 * a) == 1) ln += 2;
                        sum %= (4 * a);
                    }
                    ln += sum;
                    saved += (l - ln);
                }
                Console.WriteLine(saved);
            }
        }
    }
}
