using System;
using System.Linq;
using System.Numerics;


namespace Euler65
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = 100;
            BigInteger num = getTermForEOfRankN(limit);
            BigInteger denum = 1;

            foreach(int n in Enumerable.Range(0, limit - 1).Reverse())
            {
                BigInteger t = denum;
                denum = num;
                num = t;

                int nextRank = getTermForEOfRankN(n);
                num += nextRank * denum;
                BigInteger g = BigInteger.GreatestCommonDivisor(num, denum);
                num = num / g;
                denum = denum / g;

                Console.WriteLine(num + " / " + denum);
            }

            long sum = 0;

            while(num > 0)
            {
                sum = sum + (long) (num % 10);
                num = num / 10;
            }

            Console.WriteLine(sum);

            Console.ReadLine();


        }

        static int getTermForEOfRankN(int rank)
        {
            if (rank == 0)
                return 2;

            if ((rank + 1) % 3 == 0)
                return (rank + 1) / 3 * 2;

            return 1;
        }
    }
}
