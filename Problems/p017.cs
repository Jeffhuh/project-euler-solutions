using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    class p017
    {
        static Dictionary<int, int> l = new Dictionary<int, int>()
        {
            {1, 3}, {2, 3}, {3, 5}, {4, 4}, {5, 4}, {6, 3}, {7, 5}, {8, 5}, {9, 4}, {10, 3}, {11, 6}, {12, 6}, {13, 8}, {14, 8}, {15, 7}, {16, 7}, {17, 9}, {18, 8}, {19, 8}, {2679, 2}, {3458, 1}, {100, 7}, {1000, 8}
        };
        public static void Solution()
        {
            int n = (l[1]+l[2]+l[3]+l[4]+l[5]+l[6]+l[7]+l[8]+l[9])*190 + 100*(l[2]+l[3]+l[4]+l[5]+l[6]+l[7]+l[8]+l[9]) + (l[2679]*4 + l[3458]*4 + 1)*100 + (l[10]+l[11]+l[12]+l[13]+l[14]+l[15]+l[16]+l[17]+l[18]+l[19])*10 + l[100]*900 + l[1000]+l[1] + 3*891;
            Console.WriteLine(n);
        }
    }
}
