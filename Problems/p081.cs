using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Problems
{
    internal class p081
    {
        public static void Solution()
        {
            int[][] matrix = new int[80][];
            using (StreamReader sr = new StreamReader("../../../Files/p081.txt"))
            {
                for (int i = 0; i < 80; i++)
                {
                    matrix[i] = Array.ConvertAll(sr.ReadLine().Split(","), st => int.Parse(st));
                }
            }
            for (int i = 1; i < 80; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    int up = int.MaxValue;
                    int left = int.MaxValue;
                    if (i - j - 1 > -1) up = matrix[i - j - 1][j];
                    if (j - 1 > -1) left = matrix[i - j][j - 1];
                    matrix[i - j][j] += Math.Min(left, up);
                }
            }
            for (int i = 1; i < 80; i++)
            {
                for (int j = 1; j <= 80 - i; j++)
                {
                    matrix[80 - j][i + j - 1] += Math.Min(matrix[80 - j][i + j - 2], matrix[79 - j][i + j - 1]);
                }
            }
            Console.WriteLine(matrix[79][79]);
        }
    }
}
