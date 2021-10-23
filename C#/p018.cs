using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Problem_16_50
{
    class p018
    {
        public static void Solution()
        {
            int[] triangle = new int[8*15];
            try
            {
                using (StreamReader sr = new StreamReader("../../../Files/Problem18.txt"))
                {
                    int l = 0; 
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] a = line.Split(" ");
                        for (int j = 0; j < a.Length; j++)
                        {
                            triangle[l + j] = Int32.Parse(a[j]);
                        }
                        l += a.Length;
                    }

                    for (int i = 14; 0 < i; i--)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            if (triangle[(i*i+i)/2 + j] < triangle[(i * i + i) / 2 + j+1])
                            {
                                triangle[(i * i - i) / 2 + j] += triangle[(i * i + i) / 2 + j + 1];
                            } else
                            {
                                triangle[(i * i - i) / 2 + j] += triangle[(i * i + i) / 2 + j];
                            }
                        }
                    }
                    Console.WriteLine(triangle[0]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
