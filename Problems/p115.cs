using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p115
    {
        private static BigInteger Sum = 1;
        public static void Solution()
        {
            int n = 1;
            while (true)
            {
                int mBlocks = (int)(n / 51 + (n % 51 == 50 ? 1 : 0));
                for (int i = 1; i <= mBlocks; i++)
                {
                    List<int> list = new List<int>();
                    for (int j = 0; j < i; j++) list.Add(50);
                    Recursion(list, n);
                }
                if (1_000_000 < Sum) break;
                n++;
                Sum = 1;
            }
            Console.WriteLine(n);
        }

        public static void Recursion(List<int> list, int limit)
        {
            int taken = list.Sum() + list.Count - 1;
            if (taken > limit)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    list[i + 1]++;
                    for (int j = 0; j < i + 1; j++) list[j] = list[i + 1];
                    int t = list.Sum() + list.Count - 1;
                    if (t <= limit)
                    {
                        Recursion(list, limit);
                        break;
                    }
                }
                return;
            }
            while (taken <= limit)
            {
                Dictionary<int, int> blocks = new Dictionary<int, int>();
                for (int i = 0; i < list.Count; i++) if (!blocks.TryAdd(list[i], 1)) blocks[list[i]]++;
                blocks.Add(1, limit - list.Sum());
                Sum += Combinations(blocks);
                list[0]++;
                taken++;
            }
            Recursion(list, limit);
        }

        public static BigInteger Combinations(Dictionary<int, int> blocks)
        {
            int whiteSpace = blocks.Sum(x => x.Value);
            BigInteger sum = 0;
            if (whiteSpace <= blocks[1] << 1)
            {
                foreach (var i in blocks)
                {
                    if (i.Key == 1) continue;
                    List<int> list = new List<int>();
                    foreach (var j in blocks)
                    {
                        if (j.Key == i.Key)
                        {
                            list.Add(j.Value - 1);
                            continue;
                        }
                        if (j.Key == 1)
                        {
                            list.Add((blocks[1] << 1) - whiteSpace + 1);
                            continue;
                        }
                        list.Add(j.Value);
                    }
                    sum += Calculate(list.Sum(), list.ToArray());
                }
            }
            List<int> list2 = new List<int>();
            foreach (var i in blocks)
            {
                if (i.Key == 1) continue;
                list2.Add(i.Value);
            }
            list2.Add(Math.Max(0, (blocks[1] << 1) - whiteSpace));
            sum += Calculate(list2.Sum(), list2.ToArray());
            return sum;
        }

        public static BigInteger Calculate(int n, params int[] k)
        {
            BigInteger prod = 1;
            for (int i = 2; i < n + 1; i++) prod *= i;
            BigInteger div = 1;
            for (int j = 0; j < k.Length; j++) for (int l = 2; l < k[j] + 1; l++) div *= l;
            return prod / div;
        }
    }
}
