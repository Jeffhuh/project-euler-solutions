using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Problems
{
    internal class p099
    {
        public static void Solution()
        {
            int index = 1;
            double max = 0;
            using (StreamReader sr = new StreamReader("../../../Files/p099.txt"))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    i++;
                    int[] n = Array.ConvertAll(line.Split(","), s => int.Parse(s));
                    double temp = Math.Log2(n[0]) * n[1];
                    if (temp > max)
                    {
                        max = temp;
                        index = i;
                    }
                }
                Console.WriteLine(index);
            }
        }
    }
}
