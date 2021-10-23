using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Problem_16_50
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test.Testing();
            p026.Solution();
        }
    }

    class Test
    {

        internal static void Testing()
        {
            ArrayList s = new ArrayList()
            {
                1,2, true
            };
            Console.WriteLine((int)s[2] + 1);
        }
    }
}
