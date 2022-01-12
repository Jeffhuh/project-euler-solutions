using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Problems
{
    internal class p082
    {
        public static void Solution()
        {
            int[][] matrix = new int[80][];
            using (StreamReader sr = new StreamReader("../../../Files/p082.txt"))
            {
                for (int i = 0; i < 80; i++)
                {
                    matrix[i] = Array.ConvertAll(sr.ReadLine().Split(","), st => int.Parse(st));
                }
            }
            for (int i = 1; i < 80; i++)
            {
                int[] column = new int[80];
                for (int j = 0; j < 80; j++)
                {
                    int temp = 0;
                    int min = int.MaxValue;
                    for (int k = 0; k < 80; k++)
                    {
                        temp = matrix[k][i - 1];
                        if (k < j)
                        {
                            for (int l = k; l < j; l++)
                            {
                                temp += matrix[l][i];
                            }
                        } else if (j < k)
                        {
                            for (int l = k; l > j; l--)
                            {
                                temp += matrix[l][i];
                            }
                        }
                        if (temp < min) min = temp;
                    }
                    column[j] = min;
                }
                for (int j = 0; j < 80; j++)
                {
                    matrix[j][i] += column[j];
                }
            }
            int m = matrix[0][79];
            for (int i = 1; i < 80; i++)
            {
                if (matrix[i][79] < m) m = matrix[i][79];
            }
            Console.WriteLine(m);
        }
    }
}
