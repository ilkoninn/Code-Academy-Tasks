using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0, l = 0, m = n, count = 1;

            if (n == 1)
            {
                Console.WriteLine("The given " + m + " number is power of 2: 2^" + count);
            }
            else
            {
                while (n > 0)
                {
                    n /= 2;
                    if (n % 2 != 0)
                    {
                        l = n;
                        break;
                    }
                    count++;
                }
                if (l == 1)
                {
                    Console.WriteLine("The given " + m + " number is power of 2: 2^" + count);
                }
                else
                {
                    Console.WriteLine("The given " + m + " number is not power of 2.");
                }
            }
        }
    }
}
