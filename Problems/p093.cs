using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p093
    {
        private static List<string> permutations = new List<string>();
        public static void Solution()
        {
            int max = 0;
            int number = 0;
            for (int a = 1; a < 7; a++)
            {
                for (int b = a + 1; b < 8; b++)
                {
                    for (int c = b + 1; c < 9; c++)
                    {
                        for (int d = c + 1; d < 10; d++)
                        {
                            int i = 1;
                            bool bb = true;
                            int n1 = 1000 * a + 100 * b + 10 * c + d;
                            while (bb)
                            {
                                permutations.Clear();
                                Permute(n1.ToString(), 0, 3);
                                bb = false;
                                for (int j = 0; j < permutations.Count; j++)
                                {
                                    string s = permutations[j];
                                    int a1 = s[0] - 48, b1 = s[1] - 48, c1 = s[2] - 48, d1 = s[3] - 48;
                                    for (int o01 = 0; o01 < 4; o01++)
                                    {
                                        for (int o12 = 0; o12 < 4; o12++)
                                        {
                                            for (int o23 = 0; o23 < 4; o23++)
                                            {
                                                double n = C(o23, C(o12, C(o01, a1, b1), c1), d1);
                                                if (n == i)
                                                {
                                                    bb = true;
                                                    break;
                                                }
                                                n = C(o23, C(o01, a1, C(o12, b1, c1)), d1);
                                                if (n == i)
                                                {
                                                    bb = true;
                                                    break;
                                                }
                                                n = C(o01, a1, C(o12, b1, C(o23, c1, d1)));
                                                if (n == i)
                                                {
                                                    bb = true;
                                                    break;
                                                }
                                                n = C(o01, a1, C(o23, C(o12, b1, c1), d1));
                                                if (n == i)
                                                {
                                                    bb = true;
                                                    break;
                                                }
                                                n = C(o12, C(o01, a1, b1), C(o23, c1, d1));
                                                if (n == i)
                                                {
                                                    bb = true;
                                                    break;
                                                }
                                            }
                                            if (bb) break;
                                        }
                                        if (bb) break;
                                    }
                                    if (bb) break;
                                }
                                i++;
                            }
                            if (i > max)
                            {
                                max = i;
                                number = n1;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(number);
        }

        private static void Permute(string str, int l, int r)
        {
            if (l == r)
            {
                permutations.Add(str);
            } else
            {
                for (int i = l; i <= r; i++)
                {
                    str = Swap(str, l, i);
                    Permute(str, l + 1, r);
                    str = Swap(str, l, i);
                }
            }
        }

        private static string Swap(string a, int l, int r)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[l];
            charArray[l] = charArray[r];
            charArray[r] = temp;
            string s = new string(charArray);
            return s;
        }

        private static double C(int @operator, double x, double y)
        {
            switch (@operator)
            {
                case 0:
                    return x + y;
                case 1:
                    return x - y;
                case 2:
                    return x * y;
                case 3:
                    return x / y;
            }
            return 0;
        }
    }
}
