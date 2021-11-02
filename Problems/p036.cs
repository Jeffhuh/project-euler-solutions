using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p036
    {
        public static void Solution()
        {
            int mL = ((int)Math.Floor(Math.Log2(1_000_000)) + 1) / 2;
            int it = (int)Math.Pow(2,mL);
            long sum = 0;
            for (int i = 1; i < it; i += 2)
            {
                int l = (int)Math.Floor(Math.Log2(1_000_000)) + 1;
                int n = 0;
                string binI = decimalToBinary(i);
                for (int j = 0; j < 11 - l; j++)
                {
                    string temp = binI;
                    for (int k = 0; k < j; k++)
                    {
                        temp = temp + "00";
                    }
                    temp = temp + binI; 
                } // case 10101 wird nicht beachtet
                if (l < 10)
                {
                    
                } else
                {
                    n = i * (l + 1); // 1001001001, didnt consider cases where 0 are in between, when l < 10
                }

                if (n > 999_999) continue;
                if (palindromic(n.ToString())) sum += n;
            }
            Console.WriteLine(sum);
        }
        public static int binaryToDecimal(string binary)
        {
            int dec = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                dec = dec << 1;
                dec = binary[i] == '1' ? dec + 1 : dec;
            }
            return dec;
        }

        public static string decimalToBinary(int dec)
        {
            string binary = string.Empty;
            do
            {
                int r = dec % 2;
                dec /= 2;
                binary = (char)(48 + r) + binary;
            } while (dec != 0);
            return binary;
        }

        public static bool palindromic(string s)
        {
            int sL = s.Length;
            for (int j = 0; j < sL / 2; j++)
            {
                if (s[j] != s[sL - 1 - j])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
