using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p066
    {
        public static void Solution()
        {
            List<BigInteger> D = new List<BigInteger>();
            for (int i = 1; i < 1001; i++)
            {
                double r = Math.Sqrt(i);
                if (r % 1 == 0)
                {
                    D.Add(1);
                    continue;
                }
                int div = (int)r;
                List<string> list = new List<string>();
                List<int> sequence = new List<int>();
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
                    sequence.Add(j);
                    j = j * newNum - oldDeonminator;
                    s = newNum.ToString() + " " + j.ToString();
                }
                int k = 1;
                while (true)
                {
                    BigInteger[] fraction = new BigInteger[2];
                    fraction[0] = 1;
                    fraction[1] = sequence[(k-1) % sequence.Count];
                    fraction = XandY(fraction, sequence, k - 1);
                    fraction[0] += div * fraction[1];
                    if ((fraction[0] * fraction[0] - i * fraction[1] * fraction[1]) == 1)
                    {
                        D.Add(fraction[0]);
                        break;
                    }
                    k++;
                }
            }
            BigInteger max = 0;
            int index = 0;
            for (int i = 0; i < D.Count; i++)
            {
                if (max.CompareTo(D[i]) == -1)
                {
                    max = D[i];
                    index = i;
                }
            }
            Console.WriteLine(index+1);
        }

        public static BigInteger[] XandY(BigInteger[] fraction, List<int> seq, int it)
        {
            if (it == 0)
            {
                return fraction;
            }
            int n = seq[(it - 1) % seq.Count];
            BigInteger temp = fraction[0];
            fraction[0] = fraction[1];
            fraction[1] = temp + n * fraction[0];
            return XandY(fraction, seq, --it);
        }
    }
}
