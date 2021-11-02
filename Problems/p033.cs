using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p033
    {
        public static void Solution()
        {
            int productI = 1;
            int productJ = 1;
            for (int i = 11; i <= 99; i++)
            { 
                for (int j = 11; j <= 49;j++)
                {
                    if (2 * j > i || i % 10 == 0 || j % 10 == 0) continue;
                    string sI = i.ToString();
                    string sJ = j.ToString();
                    for (int k = 0; k < sI.Length; k++)
                    {
                        if (sI[k] == sJ[0])
                        {
                            sI = sI.Remove(k,1);
                            sJ = sJ.Remove(0,1);
                        } else if (sI[k] == sJ[1])
                        {
                            sI = sI.Remove(k, 1);
                            sJ = sJ.Remove(1, 1);
                        }
                    }
                    if (sI.Length != 1) continue;
                    int a = gcd(i, j);
                    if (a != 1)
                    {
                        double d = Convert.ToDouble(sJ) / Convert.ToDouble(sI);
                        double dd = (double) j / (double) i;
                        if (d == dd)
                        {
                            Console.WriteLine(i + "   :    "+j);
                            productJ *= j / a;
                            productI *= i / a;
                        }
                    }
                }
            }
            Console.WriteLine(productI / gcd(productI, productJ));
        }

        public static int gcd(int a, int b)
        {
            int temp;
            do
            {
                temp = a % b;
                a = b;
                b = temp;
            } while (temp != 0);
            return a;
        }
    }
}
