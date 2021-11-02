using System;

namespace Problems
{
    class p027
    {
        public static void Solution()
        {
            int max = 0;
            int a = 0;
            int b = 2;
            for (int i = 2; i < 1_001; i += 2)
            {
                if (i == 2)
                {
                    for (int j = -998; j < 1_001; j += 2)
                    {
                        if (i+1+j > 1)
                        {
                            int n = i;
                            int seq = 0;
                            int k = 0;
                            do
                            {
                                k++;
                                seq++;
                                n = k * k + j * k + i;
                            } while (isPrime(n));
                            if (seq > max)
                            {
                                max = seq;
                                a = j;
                            }
                        }
                    }
                    i--;
                }
                if (isPrime(i))
                {
                    for (int j = -999; j < 1_001; j += 2)
                    {
                        if (i + 1 + j > 1)
                        {
                            int n = i;
                            int seq = 0;
                            int k = 0;
                            do
                            {
                                k++;
                                seq++;
                                n = k * k + j * k + i;
                            } while (isPrime(n));
                            if (seq > max)
                            {
                                max = seq;
                                a = j;
                                b = i;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(a * b);

        }
        
        public static bool isPrime(int n)
        {
            if (n < 2) return false;
            double root = Math.Sqrt(n);
            for (int j = 2; j <= root; j++)
            {
                if (n % j == 0)
                {
                    return false;
                }
            }
            return true;
        }
     }
}
