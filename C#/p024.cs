using System;
using System.Collections.Generic;
using System.Text;

namespace Problem_16_50
{
    class p024
    {
        public static void Solution()
        {
            int[] digits = { 0,1,2,3,4,5,6,7,8,9};
            int i = 1;
            while (i != 1_000_000)
            {

            }
            Console.WriteLine(String.Join("", new List<int>(digits).ConvertAll(i => i.ToString()).ToArray()));
        }
    }
}
