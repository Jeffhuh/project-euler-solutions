using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Problems
{
    internal class p083
    {
        private static bool[][] stpSet;
        private static int[][] distance;
        public static void Solution()
        {
            int[][] matrix = new int[80][];
            stpSet = new bool[80][];
            distance = new int[80][];
            using (StreamReader sr = new StreamReader("../../../Files/p083.txt"))
            {
                for (int i = 0; i < 80; i++)
                {
                    matrix[i] = Array.ConvertAll(sr.ReadLine().Split(","), st => int.Parse(st));
                    stpSet[i] = new bool[80];
                }
            }
            int[][][] graph = new int[80][][];
            for (int i = 0; i < matrix.Length; i++)
            {
                distance[i] = new int[80];
                graph[i] = new int[80][];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    distance[i][j] = int.MaxValue;
                    int[] cost = new int[4];
                    if (i == 0) cost[0] = 0;
                    else cost[0] = matrix[i - 1][j];
                    if (j == matrix[i].Length - 1) cost[1] = 0;
                    else cost[1] = matrix[i][j + 1];
                    if (i == matrix.Length - 1) cost[2] = 0;
                    else cost[2] = matrix[i + 1][j];
                    if (j == 0) cost[3] = 0;
                    else cost[3] = matrix[i][j - 1];
                    graph[i][j] = cost;
                }
            }
            distance[0][0] = matrix[0][0];
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph[i].Length; j++)
                {
                    int[] u = MinDistance();
                    stpSet[u[0]][u[1]] = true;

                    for (int k = 0; k < graph[i][j].Length; k++)
                    {
                        int i1 = (k == 0 ? -1 : k == 2 ? 1 : 0) + u[0];
                        int j1 = (k == 1 ? 1 : k == 3 ? -1 : 0) + u[1];
                        if (i1 < 0 || i1 > 79 || j1 < 0 || j1 > 79) continue;
                        int du = distance[u[0]][u[1]];
                        int cost = graph[u[0]][u[1]][k];
                        if (cost != 0 && !stpSet[i1][j1] && cost + du < distance[i1][j1])
                        {
                            distance[i1][j1] = distance[u[0]][u[1]] + cost;
                        }
                    }
                }
            }
            Console.WriteLine(distance[79][79]);
        }

        public static int[] MinDistance()
        {
            int min = int.MaxValue;
            int[] index = new int[2];
            for (int i = 0; i < 80; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    if (stpSet[i][j] == false && distance[i][j] < min)
                    {
                        min = distance[i][j];
                        index[0] = i;
                        index[1] = j;
                    }
                }
            }
            return index;
        }
    }
}
