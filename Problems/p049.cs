using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p049
    {
        public static void Solution()
        {
            List<int> fourDigitPrimes = new List<int>();
            for (int i = 1001; i < 10000; i+=2)
            {
                if (IsPrime(i)) fourDigitPrimes.Add(i);
            }
            for (int i = 0; i < fourDigitPrimes.Count - 2; i++)
            {
                for (int j = i + 1; j < fourDigitPrimes.Count - 1; j++)
                {
                    int a1 = fourDigitPrimes[i];
                    if (a1 == 1487) break;
                    int a2 = fourDigitPrimes[j];
                    int d = a2 - a1;
                    int a3 = a2 + d;
                    if (a3 > 9_999) break;
                    if (fourDigitPrimes.Contains(a3))
                    {
                        string[] s = new string[3] { a1.ToString(), a2.ToString(), a3.ToString()};
                        if (IsPermutation(s))
                        {
                            Console.WriteLine(s[0]+s[1]+s[2]);
                            break;
                        }
                    }
                }
            }
        }

        public static bool IsPermutation(string[] numbers)
        {
            Dictionary<char, int> perm = new Dictionary<char, int>();
            for (int i = 0; i < numbers[0].Length; i++)
            {
                char c = numbers[0][i];
                if (!perm.TryAdd(c, 1))
                {
                    perm[c]++;
                }
            }
            for (int i = 1; i < numbers.Length; i++)
            {
                Dictionary<char, int> perm2 = new Dictionary<char, int>();
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    char c = numbers[i][j];
                    if (!perm2.TryAdd(c, 1))
                    {
                        perm2[c]++;
                    }
                }
                bool equal = false;
                if (perm.Count == perm2.Count)
                {
                    equal = true;
                    foreach (var pair in perm)
                    {
                        int value;
                        if (perm2.TryGetValue(pair.Key, out value))
                        {
                            if (value != pair.Value)
                            {
                                equal = false;
                                break;
                            }
                        }
                        else
                        { 
                            equal = false;
                            break;
                        }
                    }
                }
                if (!equal)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsPrime(int number)
        {
            if (number % 2 == 0 || number < 2)
            {
                if (number == 2) return true;
                return false;
            }
            int i = 3;
            while (i * i <= number)
            {
                if (number % i == 0) return false;
                i += 2;
            }
            return true;
        }
    }
}
