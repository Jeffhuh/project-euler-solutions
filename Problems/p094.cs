using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p094
    {

        public static void Solution()
        {
            long sum = 0;
            for (long i = 3; i < 333_333_334; i += 2)
            {
                long b = (i + 1) / 2;
                long x = i * i - b * b;
                if (PerfectSquare(x) && IsPerfectSquareAccurate(x))
                {
                    sum += 2 * (i + b);
                    continue;
                }
                b = (i - 1) / 2;
                x = i * i - b * b;
                if (PerfectSquare(x) && IsPerfectSquareAccurate(x))
                {
                    sum += 2 * (i + b);
                }
            }
            Console.WriteLine(sum);
        }

        private static bool PerfectSquare(long x)
        {
            double d = Math.Sqrt(x);
            if (d % 1 == 0 )
            {
                return true;
            }
            return false;
        }

        public static bool IsPerfectSquareAccurate(long x)
        {
            BigInteger bigInteger = SqrtBigInteger(x);
            long a = ((long)bigInteger);
            if (a * a == x) return true;
            return false;
        }

        public static BigInteger SqrtBigInteger(BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!IsSqrtBigInteger(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException("NaN");
        }

        private static bool IsSqrtBigInteger(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }
    }
}
