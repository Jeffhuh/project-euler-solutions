using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Problems
{
    internal class p102
    {
        public static void Solution()
        {
            using (StreamReader sr = new StreamReader("../../../Files/p102.txt"))
            {
                string line = string.Empty;
                int count = 0;
                int i = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    int[] tri = line.Split(",").Select(x => int.Parse(x)).ToArray();
                    int a1 = A(tri[0], tri[1], tri[2], tri[3], 0, 0);
                    int a2 = A(tri[0], tri[1], tri[4], tri[5], 0, 0);
                    int a3 = A(tri[2], tri[3], tri[4], tri[5], 0, 0);
                    int a = A(tri[0], tri[1], tri[2], tri[3], tri[4], tri[5]);

                    if (a1 + a2 + a3 == a) count++;
                }
                Console.WriteLine(count);
            }
        }

        public static int A(int ax, int ay, int bx, int by, int cx, int cy)
        {
            return Math.Abs((ax * (by - cy) + bx * (cy - ay) + cx * (ay - by)));
        }
    }
}
