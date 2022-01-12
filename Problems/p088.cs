using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    internal class p088
    {
        public static void Solution()
        {
            Dictionary<int, List<int[]>> map = new Dictionary<int, List<int[]>>();
            for (int k = 2; k < 24_001; k++)
            {
                int i = 2;
                List<int[]> tempL = new List<int[]>();
                while (i <= (int)Math.Sqrt(k))
                {
                    if (k % i == 0)
                    {
                        List<int[]> list = map[k / i];
                        for (int j = 0; j < list.Count; j++)
                        {
                            bool b = true; 
                            int[] primeFa = list[j];
                            for (int l = 0; l < primeFa.Length; l++)
                            {
                                if (primeFa[l] < i)
                                {
                                    b = false;
                                    break;
                                }
                            }
                            if (b)
                            {
                                int[] temp = new int[primeFa.Length + 1];
                                for (int l = 0; l < primeFa.Length; l++) temp[l] = primeFa[l];
                                temp[primeFa.Length] = i;
                                Array.Sort(temp);
                                tempL.Add(temp);
                            }
                        }
                    }
                    i++;
                }
                tempL.Add(new int[] { k });
                map.Add(k, tempL);
            }
            HashSet<int> set = new HashSet<int>();
            for (int i = 2; i < 12_001; i++)
            {
                bool b = false;
                for (int j = i; j <= 2 * i; j++)
                {
                    List<int[]> factors = map[j];
                    for (int k = 0; k < factors.Count - 1; k++)
                    {
                        int[] f = factors[k];
                        int sum = 0;
                        for (int l = 0; l < f.Length; l++) sum += f[l];
                        if (i == j - sum + f.Length)
                        {
                            set.Add(j);
                            b = true;
                            break;
                        }
                    }
                    if (b) break;
                }
            }
            Console.WriteLine(set.Sum());
        }
    }
}
