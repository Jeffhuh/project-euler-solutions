using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p040
    {
        public static void Solution()
        {
            int product = 1;
            for (int i = 0; i < 7; i++)
            {
                product *= d((int)Math.Pow(10, i));
            }
            Console.WriteLine(product);
        }

        public static int d(int index)
        {
            int digitLength = 1;
            int upperLimit = 9;
            int lowerLimit = 0;
            while (upperLimit < index) 
            {
                digitLength++;
                lowerLimit = upperLimit;
                upperLimit += 9 * digitLength * (int)Math.Pow(10,digitLength-1);
            }
            int it = index - lowerLimit - 1;
            int pos = it % digitLength;
            if (pos == 0) return (it / (digitLength * (int)Math.Pow(10, digitLength - 1)) + 1);
            if (pos == digitLength - 1) return (it / digitLength) % 10;
            return (it / (digitLength * (int)Math.Pow(10, digitLength - 1 - pos))) % 10;
        }
    }
}
