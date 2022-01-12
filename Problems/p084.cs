using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Problems
{
    internal class p084
    {
        public static void Solution()
        {
            Dictionary<int, int> board = new Dictionary<int, int>();
            for (int i = 0; i < 40; i++) board.Add(i, 0);
            int square = 0;
            int dd = 0;
            int dice = 4;
            int cc = 0;
            int ch = 0;
            Random r = new Random();
            int it = 10_000_000;
            for (int i = 0; i < it; i++)
            {
                int moveD1 = r.Next(1, dice + 1);
                int moveD2 = r.Next(1, dice + 1);
                if (moveD1 == moveD2)
                {
                    if (dd == 2)
                    {
                        dd = 0;
                        square = 10;
                        board[10]++;
                        continue;
                    }
                    else
                    {
                        dd++;
                    }
                }
                else dd = 0;
                square = (square + moveD1 + moveD2) % 40;
                if (square == 30)
                {
                    square = 10;
                    board[10]++;
                    continue;
                }
                if (square == 2 || square == 17 || square == 33)
                {
                    cc++;
                    cc &= ~(1 << 4);
                    if (cc == 0)
                    {
                        square = 0;
                        board[0]++;
                        continue;
                    } else if (cc == 1)
                    {
                        square = 10;
                        board[10]++;
                        continue;
                    }
                }
                if (square == 7 || square == 22 || square == 36)
                {
                    int chT = -1;
                    ch++;
                    ch &= ~(1 << 4);
                    switch (ch)
                    {
                        case 0:
                            chT = 0;
                            break;

                        case 1:
                            chT = 10;
                            break;

                        case 2:
                            chT = 11;
                            break;

                        case 3:
                            chT = 24;
                            break;

                        case 4:
                            chT = 39;
                            break;

                        case 5:
                            chT = 5;
                            break;

                        case 6:
                        case 7:
                            if (square == 7) chT = 15;
                            else if (square == 22) chT = 25;
                            else if (square == 36) chT = 5;
                            break;

                        case 8:
                            if (square == 22) chT = 28;
                            else chT = 12;
                            break;

                        case 9:
                            chT = square - 3;
                            break;
                    }
                    if (chT != -1)
                    {
                        board[chT]++;
                        square = chT;
                        continue;
                    }
                }
                board[square]++;
            }
            List<KeyValuePair<int, int>> list = board.ToList();
            list.Sort((p1,p2) => p1.Value.CompareTo(p2.Value));
            /*foreach (var pair in list)
            {    
                Console.WriteLine(pair.Key +"  :  "+pair.Value + " ----- "+((double)pair.Value/it*100));
            }*/
            for (int i = 0; i < 3; i++)
            {
                string s = list[list.Count - 1 - i].Key.ToString();
                if (s.Length == 1) s = "0" + s;
                Console.Write(s);
            }
        }
    }
}
