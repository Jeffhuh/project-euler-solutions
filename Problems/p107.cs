using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problems
{
    internal class p107
    {
        public static void Solution()
        {
            int[][] graph = new int[40][];
            List<(int edge, int x, int y)> edges = new List<(int edge, int x, int y)>();
            int totoalWeight = 0;
            using (StreamReader sr = new StreamReader("../../../Files/p107.txt"))
            {
                for (int i = 0; i < 40; i++)
                {
                    int[] a = sr.ReadLine().Split(',').Select(x => x[0] == '-' ? -1 : int.Parse(x)).ToArray();
                    graph[i] = a;
                    for (int j = 0; j < i; j++)
                    {
                        if (graph[i][j] != -1)
                        {
                            edges.Add((graph[i][j], i, j));
                            totoalWeight += graph[i][j];
                        }
                    }
                }
            }
            edges = edges.OrderBy(x => x.edge).ToList();
            HashSet<int> set = new HashSet<int>() { edges[0].x, edges[0].y };
            int sum = edges[0].edge;
            for (int i = 0; i < 38; i++)
            {
                for (int j = 1; j < edges.Count; j++)
                {
                    if (set.Contains(edges[j].x) ^ set.Contains(edges[j].y))
                    {
                        set.Add(edges[j].x);
                        set.Add(edges[j].y);
                        sum += edges[j].edge;
                        break;
                    }
                }
            }
            Console.WriteLine(totoalWeight - sum);
        }
    }
}
