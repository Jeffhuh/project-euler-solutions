using System;
using System.Numerics;

namespace Problem_16_50
{
    class p016
    {
    
        public static void Solution()
        {
            BigInteger bigN = BigInteger.Pow(2, 1000);
            string n = bigN.ToString();
            long sum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                sum += n[i] - 48;
            }
            Console.WriteLine(sum);
        }
        
    }
}
