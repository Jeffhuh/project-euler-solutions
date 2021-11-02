using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p032
    {
        public static void Solution()
        {
            int limit = (int)Math.Sqrt(987654321);
            ArrayList products = new ArrayList();
            int sum = 0;
            for (int i = 1; i < limit/2; i++)
            {
                for (int j = 1; j <= limit/2; j++)
                {
                    int product = i * j;
                    string s = i.ToString() + j.ToString() + product.ToString();
                    int sL = s.Length;
                    if (sL != 9) continue;
                    bool[] digits = new bool[9];
                    bool unique = true;
                    for (int k = 0; k < sL; k++)
                    {
                        int c = s[k] - 49;
                        if (c == -1 || digits[c])
                        {
                            unique = false;
                            break;
                        } else
                        {
                            digits[c] = true;
                        }
                    }
                    if (unique && !products.Contains(product))
                    {
                        products.Add(product);
                        sum += product;
                        Console.WriteLine(product);
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
