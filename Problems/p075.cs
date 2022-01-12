using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p075
    {
        public static void Solution()
        {
            List<int> primitiv = new List<int>();
            int q = (int)(-0.5d + Math.Sqrt(0.25d+750_000));
            for (int i = q; 0 < i; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    int a = i * i - j * j;
                    int b = 2 * i * j;
                    int c = i * i + j * j;
                    int l = a + b + c;
                    if (l > 1_500_000) continue;
                    int f = gcd(a,b);
                    if (f != 1 && gcd(f, c) == gcd(f, c)) l /= f;
                    if (!primitiv.Contains(l)) primitiv.Add(l);
                }
            }
            int count = 0;
            byte[] array = new byte[1_500_001];
            for (int i = 0; i < primitiv.Count; i++)
            {
                int jump = primitiv[i];
                int index = jump;
                do
                {
                    if (array[index] == 1) array[index] = 2;
                    if (array[index] == 0) array[index] = 1;
                    index += jump;
                } while (index < 1_500_001);
            }
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 1) count++;
            }
            Console.WriteLine(count);
        }

        public static int gcd(int a, int b)
        {
            while(a != 0 && b != 0)
            {
                if (a < b)
                {
                    b %= a;
                } else
                {
                    a %= b;
                }
            }
            return a | b;
        }
    }
}
