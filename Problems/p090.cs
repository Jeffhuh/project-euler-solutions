using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p090
    {
        private static List<List<int>> combinations = new List<List<int>>();         
        public static void Solution()
        {
            Combinations(10, 6, new bool[10], 0);
            int count = 0;
            for (int i = 0; i < combinations.Count; i++)
            {
                List<int> d1 = combinations[i];
                for (int j = i + 1; j < combinations.Count; j++)
                {
                    List<int> d2 = combinations[j];
                    if (!(d1.Contains(0) && d2.Contains(1) || d1.Contains(1) && d2.Contains(0))) continue;
                    if (!(d1.Contains(0) && d2.Contains(4) || d1.Contains(4) && d2.Contains(0))) continue;
                    if (!(d1.Contains(1) && d2.Contains(8) || d1.Contains(8) && d2.Contains(1))) continue;
                    if (!(d1.Contains(2) && d2.Contains(5) || d1.Contains(5) && d2.Contains(2))) continue;
                    if (!((d1.Contains(6) || d1.Contains(9)) && d2.Contains(0) || d1.Contains(0) && (d2.Contains(6) || d2.Contains(9)))) continue;
                    if (!((d1.Contains(6) || d1.Contains(9)) && d2.Contains(1) || d1.Contains(1) && (d2.Contains(6) || d2.Contains(9)))) continue;
                    if (!((d1.Contains(6) || d1.Contains(9)) && d2.Contains(3) || d1.Contains(3) && (d2.Contains(6) || d2.Contains(9)))) continue;
                    if (!((d1.Contains(6) || d1.Contains(9)) && d2.Contains(4) || d1.Contains(4) && (d2.Contains(6) || d2.Contains(9)))) continue;
                    count++;    
                }
            }
            Console.WriteLine(count);
        }

        private static void Combinations(int n, int k, bool[] comb, int indexComb)
        {
            if (k == 0)
            {
                List<int> list = new List<int>();
                for (int i = 0; i < 10; i++)
                {
                    if (comb[i]) list.Add(i);
                }
                combinations.Add(list);
                return;
            }
            if (k > n) return;
            comb[indexComb] = false;
            bool[] temp1 = new bool[10];
            for (int i = 0; i <= indexComb; i++) temp1[i] = comb[i];
            Combinations(n - 1, k, temp1, indexComb + 1);
            comb[indexComb] = true;
            bool[] temp2 = new bool[10];
            for (int i = 0; i <= indexComb; i++) temp2[i] = comb[i];
            Combinations(n - 1, k - 1, temp2, indexComb + 1);
        }
    }
}
