using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p095
    {
        public static void Solution()
        {
            int[] map = new int[1_000_001];
            for (int i = 2; i < 1_000_001; i++) map[i] = 1;
            for (int k = 2; k < 1_000_001; k++)
            {
                for (int i = 2 * k; i < 1_000_001; i += k)
                {
                    map[i] += k;
                }
            }
            int max = 0;
            int minInChain = 0;
            List<int> chain = new List<int>();
            for (int i = 2; i < 1_000_001; i++)
            {
                if (chain.Contains(i)) continue;
                List<int> c = new List<int>();
                c.Add(i);
                int div = i;
                while (true)
                {
                    div = map[div];
                    if (div > 1_000_000 || chain.Contains(div) )
                    {
                        if (div > 1_000_000) chain.Add(div);
                        break;
                    }
                    int indexC = c.IndexOf(div);
                    if (indexC != -1)
                    {
                        int temp = c.Count - indexC;
                        if (temp > max)
                        {
                            max = temp;
                            int tempMin = int.MaxValue;
                            for (int j = indexC; j < c.Count; j++)
                            {
                                if (tempMin > c[j])
                                {
                                    tempMin = c[j];
                                }
                            }
                            minInChain = tempMin;
                        }
                        break;
                    }
                    c.Add(div);
                }
                foreach (var j in c) chain.Add(j);
            }
            Console.WriteLine(minInChain);
        }
    }
}
