using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p028
    {
        public static void Solution()
        {
            long sum = 1001 * 2 - 1;
            int count = 1;
            for (int i = 1; i < 501; i++)
            {
                sum += i*2*(count*4+6);
                count += 2;
            }
            Console.WriteLine(sum);
        }

    }
}
