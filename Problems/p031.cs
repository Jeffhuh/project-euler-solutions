using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p031
    {
        public static void Solution()
        {
            int count = 0;
            for (int a = 200; a >= 0; a -= 200)
            {
                for (int b = a; b >= 0; b -= 100)
                {
                    for (int c = b; c >= 0; c -= 50)
                    {
                        for (int d = c; d >= 0; d -= 20)
                        {
                            for (int e = d; e >= 0; e -= 10)
                            {
                                for (int f = e; f >= 0; f -= 5)
                                {
                                    for (int g = f; g >= 0; g -= 2)
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
