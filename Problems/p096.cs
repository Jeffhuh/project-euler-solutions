using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problems
{
    internal class p096
    {
        private static int[][] st;
        private static Stack<int[][]> backtrackingSudoku = new Stack<int[][]>();
        private static Stack<Dictionary<int, string>> backtrackingPs = new Stack<Dictionary<int, string>>();
        public static void Solution()
        {
            st = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                st[i] = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    st[i][j] = (i / 3) * 30 + (j / 3) * 3;
                }
            }
            int sum = 0;
            using (StreamReader sr = new StreamReader("../../../Files/p096.txt"))
            {
                for (int o = 0; o < 50; o++)
                {
                    sr.ReadLine();
                    int[][] sudoku = new int[9][];
                    for (int p = 0; p < 9; p++)
                    {
                        sudoku[p] = Array.ConvertAll(sr.ReadLine().ToCharArray(), s => s - 48);
                    }
                    Dictionary<int, string> solutionSpace = new Dictionary<int, string>();
                    for (int i = 0; i < sudoku.Length; i++)
                    {
                        for (int j = 0; j < sudoku[i].Length; j++)
                        {
                            if (sudoku[i][j] == 0)
                            {
                                bool[] digits = new bool[9];
                                int x = st[i][j] / 10;
                                int y = st[i][j] % 10;
                                for (int k = 0; k < 9; k++)
                                {
                                    if (sudoku[i][k] != 0) digits[sudoku[i][k] - 1] = true;
                                    if (sudoku[k][j] != 0) digits[sudoku[k][j] - 1] = true;
                                    if (sudoku[x + k / 3][y + k % 3] != 0) digits[sudoku[x + k / 3][y + k % 3] - 1] = true;
                                }
                                string s = string.Empty;
                                for (int k = 0; k < 9; k++)
                                {
                                    s = s + (digits[k] ? "" : (k + 1).ToString());
                                }
                                solutionSpace.Add(10 * i + j, s);
                            }
                        } 
                    }
                    KeyValuePair<int, string> pS = solutionSpace.OrderBy(x => x.Value.Length).FirstOrDefault();
                    backtrackingSudoku.Clear();
                    backtrackingPs.Clear();
                    while (solutionSpace.Count > 0)
                    {
                        string s = pS.Value;
                        if (s.Length != 1)
                        {
                            solutionSpace[pS.Key] = solutionSpace[pS.Key].Replace(s[0].ToString(), "");
                            int[][] temp = new int[9][];
                            for (int k = 0; k < 9; k++)
                            {
                                temp[k] = new int[9];
                                for (int l = 0; l < 9; l++)
                                {
                                    temp[k][l] = sudoku[k][l];
                                }
                            }
                            backtrackingSudoku.Push(temp);
                            backtrackingPs.Push(new Dictionary<int, string>(solutionSpace));
                        }
                        Update(sudoku, s[0] - 48, pS.Key, solutionSpace);
                        if (Violation(sudoku, pS.Key))
                        {
                            sudoku = backtrackingSudoku.Pop();
                            solutionSpace = backtrackingPs.Pop();
                        }
                        pS = solutionSpace.OrderBy(x => x.Value.Length).FirstOrDefault();
                    }
                    sum += 100 * sudoku[0][0] + 10 * sudoku[0][1] + sudoku[0][2];
                }
            }
            Console.WriteLine(sum);
        }

        public static bool Violation(int[][] sudoku, int pos)
        {
            int x = pos % 10;
            int y = pos / 10;
            int digit = sudoku[y][x];
            int start = st[y][x];
            for (int i = 0; i < 9; i++)
            {
                if (sudoku[y][i] == digit && 10 * y + i != pos) return true;
                if (sudoku[i][x] == digit && 10 * i + x != pos) return true;
                if (sudoku[start / 10 + i / 3][start % 10 + i % 3] == digit && 10 * (start / 10 + i / 3) + start % 10 + i % 3 != pos) return true;
            }
            return false;
        }

        public static void Update(int[][] sudoku, int insert, int pos, Dictionary<int, string> solutionSpace)
        {
            int x = pos % 10;
            int y = pos / 10;
            sudoku[y][x] = insert;
            solutionSpace.Remove(pos);
            int start = st[y][x];
            for (int i = 0; i < 9; i++)
            {
                int v = 10 * i + x;
                int h = 10 * y + i;
                int g = start + 10 * (i / 3) + i % 3;
                if (solutionSpace.ContainsKey(v))
                {
                    if (solutionSpace[v].Length != 1) solutionSpace[v] = solutionSpace[v].Replace(insert.ToString(), "");
                }
                if (solutionSpace.ContainsKey(h))
                {
                    if(solutionSpace[h].Length != 1) solutionSpace[h] = solutionSpace[h].Replace(insert.ToString(), "");
                }
                if (solutionSpace.ContainsKey(g))
                {
                    if (solutionSpace[g].Length != 1) solutionSpace[g] = solutionSpace[g].Replace(insert.ToString(), "");
                }
            }
        }
    }
}
