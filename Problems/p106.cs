using System;
using System.Collections.Generic;

namespace Problems
{
    internal class p106
    {
        public static void Solution()
        {
            int n = 12;
            int it = 1 << n;
            int inb = it - 1;
            int count = 0;
            for (int i = 2; i < it - 2; i++)
            {
                int bL = 0;
                int tempI = i << 1;
                while ((tempI >>= 1) != 0) bL += tempI & 1;
                if (bL > n >> 1) continue;
                List<int> list = new List<int>();
                int a = 1;
                int it2 = i ^ inb;  
                int temp = it2;
                int bL2 = 0;
                while (temp != 0)
                {
                    if ((temp & 1) == 1)
                    {
                        list.Add(a);
                        bL2++;
                    }
                    a <<= 1;
                    temp >>= 1;
                }
                it2 = 1 << bL2;
                for (int j = 2; j < it2; j++)
                {
                    int bL3 = 0;
                    int temp2 = j;
                    int set2 = 0;
                    int index = 0;
                    while (temp2 != 0)
                    {
                        if ((temp2 & 1) == 1)
                        {
                            set2 += list[index];
                            bL3++;
                        }
                        index++;
                        temp2 >>= 1;
                    }
                    if (bL == bL3 && C1(i, set2)) count++;
                }
            }
            Console.WriteLine(count >> 1);
        }

        public static bool C1(int a1, int a2)
        {
            if (a2 > a1)
            {
                int temp = a2;
                a2 = a1;
                a1 = temp;
            }
            string s1 = decimalToBinary(a1);
            string s2 = decimalToBinary(a2);
            List<int> l1 = new List<int>();
            int s1L = s1.Length - 1;
            for (int i = s1L; -1 < i; i--)
            {
                if (s1[i] == '1') l1.Add(s1L - i);
            }

            List<int> l2 = new List<int>();
            int s2L = s2.Length - 1;
            for (int i = s2L; -1 < i; i--)
            {
                if (s2[i] == '1') l2.Add(s2L - i);
            }

            for (int i = 0; i < l1.Count; i++)
            {
                if (l2[i] >= l1[i]) return true;
            }
            return false;    
        }

        public static string decimalToBinary(int dec)
        {
            string binary = string.Empty;
            do
            {
                int r = dec & 1;
                dec >>= 1;
                binary = (char)(48 + r) + binary;
            } while (dec != 0);
            return binary;
        }
    }
}
