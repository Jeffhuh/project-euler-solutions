using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    internal class p719
    {
        public static void Solution()
        {
            int digits = 1;
            List<string> list = new List<string>();
            long sSum = 41_333;
            for (long i = 101; i < 1_000_001; i++) 
            {
                long a = i % 9;
                if (a != 0 && a != 1) continue;
                string set = (i * i).ToString();
                int l = set.Length;
                if (digits != l)
                {
                    digits = l;
                    list.Clear();
                    int group = i.ToString().Length - 1;
                    int limit = (int)Math.Pow(2, l - 1);
                    for (int j = 1; j < limit; j++)
                    {
                        string binary = decimalToBinary(j, l - 1);
                        list.Add(binary);
                        int tempG = 0;
                        int maxG = 0;
                        for (int k = l - 2; -1 < k; k--)
                        {
                            if (binary[k] == '0')
                            {
                                tempG++;
                                if (tempG > maxG) maxG = tempG;
                            }
                            else tempG = 0;
                        }
                        if (maxG == group || maxG == group - 1) list.Add(binary);
                    }
                }
                for (int j = 0; j < list.Count; j++)
                {
                    string binary = list[j];
                    int tempSum = set[0] - 48;
                    int sum = 0;
                    for (int k = 1; k < set.Length; k++)
                    {
                        if (binary[k - 1] == '0')
                        {
                            tempSum = 10 * tempSum + (set[k] - 48);
                        } else
                        {
                            sum += tempSum;
                            tempSum = set[k] - 48;
                        }
                    }
                    sum += tempSum;
                    if (sum == i)
                    {
                        sSum += i * i;
                        break;
                    }
                }
            }
            Console.WriteLine(sSum);
            
        }
        public static string decimalToBinary(int dec, int l)
        {
            string binary = string.Empty;
            do
            {
                int r = dec % 2;
                dec /= 2;
                binary = (char)(48 + r) + binary;
            } while (dec != 0);
            while (binary.Length != l) binary = "0" + binary;
            return binary;
        }

        /*public static int SetSum(List<int> list, int sum)
        {
            int group = 1;
            int groupMax = 0;
            int count = list.Count;
            int maxSum = 0;
            while (maxSum < sum)
            {
                groupMax = groupMax * 10 + 9;
                int m = count / group;
                int r = count % group;
                int restSum = 0;
                for (int i = 0; i < r; i++)
                {
                    restSum = restSum * 10 + 9;
                }
                maxSum = groupMax * m + restSum;
                Console.WriteLine(maxSum);
                group++;
            }
            group--;
            for (int i = 0; i < count - group + 1; i++)
            {
                int groupSum = 0; 
                for (int j = i; j < i + group; j++)
                {
                    groupSum += list[j];
                }
                if (groupSum > sum)
                {
                    return int.MaxValue;
                } 
            }
            Console.WriteLine(group);
            return maxSum;
        }*/
    }
}
