using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Problems
{
    class p025
    {
        public static void Solution()
        {
            Console.WriteLine(Math.Ceiling((999 + Math.Log10(5) / 2) / Math.Log10((1 + Math.Sqrt(5)) / 2)));
        }
    }
}
