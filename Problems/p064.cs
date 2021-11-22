using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p064
    {
        public static void Solution()
        {
            int count = 0;
            for (int i = 2; i < 10_001; i++)
            { 
                double r = Math.Sqrt(i);
                if (r % 1 == 0) continue;
                int div = (int)r;
                List<string> list = new List<string>();
                string s = "1 " + div;
                while (!list.Contains(s))
                {
                    list.Add(s);
                    string[] numbers = s.Split(' ');
                    int oldDeonminator = int.Parse(numbers[1]);
                    int oldNumerator = int.Parse(numbers[0]);
                    int newNum = (i - oldDeonminator * oldDeonminator) / oldNumerator;
                    double d = r + oldDeonminator;
                    int j = (int)d / newNum;
                    j = j * newNum - oldDeonminator;
                    s = newNum.ToString() + " " + j.ToString();
                }
                count = (list.Count & 1) == 1 ? count + 1 : count;
            }
            Console.WriteLine(count);
        }
    }
}
