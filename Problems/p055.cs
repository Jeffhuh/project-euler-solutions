using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p055
    {
        public static void Solution()
        {
            int[] numbers = new int[9_999];
            int count = 0;
            for (int i = 1; i < 10_000; i++)
            {
                if (numbers[i - 1] == -1)
                {
                    continue;
                }
                if (numbers[i - 1] == -2)
                {
                    count++;
                    continue;
                }
                int j = 0;
                bool notFound = true;
                BigInteger sum = i;
                while (j < 50 && notFound)
                {
                    sum += Reverse(sum);
                    if (IsPalindromic(sum))
                    {
                        notFound = false;
                    }
                    j++;
                }
                string s = i.ToString();
                if (notFound)
                {
                    count++;
                    if (s.Length < 5)
                    {
                        numbers[(int)Reverse(BigInteger.Parse(s)) - 1] = -2;
                    }
                } else
                {
                    if (s.Length < 5)
                    {
                        numbers[(int)Reverse(BigInteger.Parse(s)) - 1] = -1;
                    }
                }
            }
            Console.WriteLine(count);
        }

        public static BigInteger Reverse(BigInteger number)
        {
            string s = number.ToString();
            string temp = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                temp = s[i] + temp;
            }
            return BigInteger.Parse(temp);
        }

        public static bool IsPalindromic(BigInteger number)
        {
            string s = number.ToString();
            for (int i = 0; i < s.Length/2; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                {
                    return false; 
                }
            }
            return true;
        }
    }
}
