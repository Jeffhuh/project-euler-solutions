using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p051
    {
        public static void Solution()
        {
            int prime = 1009;
            while (true)
            {
                if (IsPrime(prime))
                {
                    string sPrime = prime.ToString();
                    char c = ThreeDigits(sPrime);   
                    if (c != '3')
                    {
                        bool[] replace = new bool[sPrime.Length];
                        for (int i = 0; i < sPrime.Length - 1; i++)
                        {
                            if (sPrime[i] == c) replace[i] = true;
                        }
                        int count = 0;
                        StringBuilder sb = new StringBuilder(sPrime);
                        for (int i = 0; i < 10; i++)
                        {
                            for (int j = 0; j < sPrime.Length - 1; j++)
                            {
                                if (i == 0 && j == 0) continue;
                                if (replace[j])
                                {
                                    sb[j] = (char)(i+48);
                                }
                            }
                            if (!IsPrime(int.Parse(sb.ToString())))
                            {
                                count++;
                            }
                            if (count > 2)
                            {
                                prime += 2;
                                continue;
                            }
                        }
                        if (count < 3)
                        {
                            Console.WriteLine(prime);
                            break;
                        }
                    }
                }
                prime += 2;
            }
        }

        public static char ThreeDigits(string number)
        {
            Dictionary<char,int> fre = new Dictionary<char,int>();
            for (int i = 0; i < number.Length; i++)
            {
                if (!fre.TryAdd(number[i], 1)) fre[number[i]]++;
            }
            foreach (var i in fre)
            {
                char key = i.Key;
                int val = i.Value; 
                if (val > 2 && (key == '0' || key == '1' || key == '2'))
                {
                    if (key == '1' && number[number.Length-1] == '1')
                    {
                        if (val > 3)
                        {
                            return key;
                        }
                        continue;
                    }
                    return key;
                }
            }
            return '3';
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
