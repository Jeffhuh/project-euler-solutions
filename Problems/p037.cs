using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p037
    {
        public static void Solution()
        {
            int[] primes = { 1,2,3,5,7,9};
            List<int> n = new List<int>();
            n.Add(1);
            n.Add(0);
            int count = 0;
            int sum = 0;
            while (count != 11)
            {
                string number = string.Empty;
                for (int i = n.Count - 1; i >= 0; i--)
                {
                    number = number + (char)(primes[n[i]]+48);
                }
                if (Truncatable(number))
                {
                    count++;
                    sum += int.Parse(number);
                }
                for (int i = 0; i < n.Count; i++)
                {
                    n[i] = (n[i] + 1) % 6;
                    if (n[i] != 0) 
                    {
                        break;
                    } else if (i == 0) n[i] = 0;
                    if (i == n.Count - 1)
                    {
                        n[0] = 0;
                        for (int j = 1; j < n.Count; j++)
                        {
                            n[j] = 0;
                        }
                        n.Add(0);
                    }
                }
            }
            Console.WriteLine(sum);
        }

        public static bool Truncatable(string number)
        {
            if (!IsPrime(int.Parse(number))) return false;
            string temp = string.Empty;
            for (int i = 1; i < number.Length; i++)
            {
                temp = number.Substring(i, number.Length - i);
                if (!IsPrime(int.Parse(temp))) return false;
            }
            for (int i = 1; i < number.Length; i++)
            {
                temp = number.Substring(0, number.Length - i);
                if (!IsPrime(int.Parse(temp))) return false;
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
