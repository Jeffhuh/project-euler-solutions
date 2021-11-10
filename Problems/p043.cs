using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p043
    {
        static int[] perm = { 1, 0, 2, 3, 4, 5, 6, 7, 8, 9 };
        static int[] prime = { 2, 3, 5, 7, 11, 13, 17};
        public static void Solution()
        { 
            int count = 1;
            int permC = 9 * 9 * 8 * 5040;
            long sum = 0;
            while (count < permC)
            {
                int length = perm.Length;
                int i = length - 1;
                while (perm[i-1] >= perm[i])
                {
                    i--;
                }
                int j = length;
                while (perm[j-1] <= perm[i-1])
                {
                    j--;
                }
                swap(i - 1, j - 1);
                i++;
                j = length;
                while (i < j)
                {
                    swap(i-1,j-1);
                    i++;
                    j--;
                }
                bool d = true;
                for (int k = 1; k < prime.Length+1; k++)
                {
                    int number = 100 * perm[k] + 10 * perm[k+1] + perm[k+2];
                    if (number % prime[k-1] != 0)
                    {
                        d = false;
                        break;
                    }
                }
                if (d)
                {
                    long n = 0;
                    for (int k = 0; k < perm.Length; k++)
                    {
                        n = 10*n + perm[k];
                    }
                    sum += n;
                }
                count++;
            }
            Console.WriteLine(sum);
            ////////////////
            /*long sum = 0;
            for (long i = 1023456782L; i < 9876543210L; i += 17)
            {
                string temp = string.Empty;
                string n = i.ToString();
                bool dp = true;
                for (int k = 1; k < 8; k++)
                {
                    temp = "" + n[k] + n[k + 1] + n[k + 2];
                    if (int.Parse(temp) % prime[k - 1] != 0)
                    {
                        dp = false;
                        break;
                    }
                }
                if (dp && pandigital(n))
                {
                    sum += i;
                }
            }            
            Console.WriteLine(sum);*/
        }

        public static void swap(int a, int b)
        {
            int temp = perm[a];
            perm[a] = perm[b];
            perm[b] = temp;
        }
        public static bool pandigital(string n)
        {
            if (n.Length != 10) return false;
            bool[] contains = new bool[10];
            for (int i = 0; i < contains.Length; i++)
            {
                int index = n[i] - 48;
                if (contains[index] == false)
                {
                    contains[index] = true;
                }
                else return false;
            }
            return true;
        }
    }
}
