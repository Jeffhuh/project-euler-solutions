using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Problems
{
    internal class p100
    {
        public static void Solution()
        {
            long A1 = 3;
            long B1 = 2;
            long A2 = 7;
            long B2 = 5;
            long disks = 0;

            while (disks < 1_000_000_000_000)
            {
                A1 += 2 * A2;
                B1 += 2 * B2;

                A2 += 2 * A1;
                B2 += 2 * B1;

                disks = B2 * B2 - B1 * B1;
            }
            BigInteger bigDisks = new BigInteger(disks);
            BigInteger blueDisks = (1 + SqrtBigInteger(2 * bigDisks * bigDisks - 2 * bigDisks + 1)) >> 1;
            Console.WriteLine(blueDisks);
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
