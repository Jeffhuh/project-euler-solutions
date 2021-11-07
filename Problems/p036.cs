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
            long sum = 1;
            for (int i = 1; i <= mL; i++)
            {
                int j = i == 1 ? 1 :(int) Math.Pow(2, i - 1) + 1;
                int upper = (int)Math.Pow(2, i);
                for (; j < upper; j += 2)
                {
                    string s = decimalToBinary(j);
                    string n = s;
                    int k = 0;
                    do
                    {
                        char[] ch = s.ToCharArray();
                        Array.Reverse(ch);
                        n = new string(ch);
                        for (int l = 0; l < k; l++)
                        {
                            n = n + "0";
                        }
                        n = n + s;
                        int number = binaryToDecimal(n);
                        if (palindromic(number.ToString()))
                        {
                            sum += number;
                        }
                        if ((n.Length & 1) == 1)
                        {
                            StringBuilder sb = new StringBuilder(n);
                            sb[n.Length / 2] = '1';
                            n = sb.ToString();
                            number = binaryToDecimal(n);
                            if (palindromic(number.ToString()))
                            {
                                sum += number;
                            }
                        }
                        k++;
                    } while (k + 2 * s.Length < 20);

                }
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
