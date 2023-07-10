using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p098
    {
        public static void Solution()
        {
            Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();
            using (StreamReader sr = new StreamReader("../../../Files/p098.txt"))
            {
                string line = sr.ReadLine();
                string[] words = line.Replace("\"", string.Empty).Split(',');
                for (int i = 0; i < words.Length; i++)
                {
                    string s = string.Concat(words[i].OrderBy(x => x));
                    List<string> list;
                    if (anagrams.TryGetValue(s, out list))
                    {
                        list.Add(words[i]);
                    }
                    else anagrams.Add(s, new List<string>() { words[i] });
                }
                long max = 0;
                foreach (var i in anagrams)
                {
                    if (i.Value.Count < 2) continue;
                    List<string[]> combinations = new List<string[]>();
                    Combinations(i.Value.ToArray(), 2, 0, new string[2], ref combinations);
                    for (int j = 0; j < combinations.Count; j++)
                    {
                        long l = SquareAnagram(combinations[j][0], combinations[j][1]);
                        if (l > max) max = l;
                    }
                }
                Console.WriteLine(max);
            }
        }

        public static long SquareAnagram(string s1, string s2)
        {
            int upperBound = (int)Math.Sqrt(Math.Pow(10, s1.Length) - 1) - 1;
            int lowerBound = (int)Math.Sqrt(Math.Pow(10, s1.Length - 1)) - 1;
            for (long i = upperBound; lowerBound < i ; i--)
            {
                Dictionary<int, char> mapping = DigitAlignment(s1, i * i);
                if (mapping != null)
                {
                    Dictionary<char, int> inverseMap = new Dictionary<char, int>();
                    foreach (var c1 in mapping)
                    {
                        inverseMap.Add(c1.Value, c1.Key);
                    }
                    long b = 1;
                    long number = 0;
                    if (inverseMap[s2[0]] == 0) continue;
                    for (int j = s2.Length - 1; -1 < j; j--)
                    {
                        number += b * inverseMap[s2[j]];
                        b *= 10;
                    }
                    if (IsPerfectSquareAccurate(number))
                    {
                        return Math.Max(number, i * i);
                    } 
                }
            }
            return 0;
        }

        public static bool IsPerfectSquareAccurate(long x)
        {
            BigInteger bigInteger = SqrtBigInteger(x);
            long a = ((long)bigInteger);
            if (a * a == x) return true;
            return false;
        }

        public static BigInteger SqrtBigInteger(BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!IsSqrtBigInteger(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException("NaN");
        }

        private static bool IsSqrtBigInteger(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }

        public static Dictionary<int, char> DigitAlignment(string s1, long number)
        {
            if (s1.Length != number.ToString().Length) return null;
            Dictionary<int, char> mapping = new Dictionary<int, char>();
            for (int i = s1.Length - 1; -1 < i; i--)
            {
                char c = s1[i];
                int a = (int) (number % 10);
                if (mapping.ContainsValue(c) && !mapping.ContainsKey(a)) return null;
                if (!mapping.TryAdd(a, c))
                {
                    if (c != mapping[a]) return null;
                }
                number /= 10;
            }
            return mapping;
        }

        public static void Combinations<T>(T[] arr, int len, int startPosition, T[] result, ref List<T[]> combinations)
        {
            if (len == 0)
            {
                combinations.Add(result);
                return;
            }
            for (int i = startPosition; i <= arr.Length - len; i++)
            {
                result[result.Length - len] = arr[i];
                Combinations(arr, len - 1, i + 1, result, ref combinations);
            }
        }
    }
}
