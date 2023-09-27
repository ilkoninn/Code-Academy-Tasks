using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 191;
            bool result = false;

            Console.WriteLine("The given number: " + n);

            if (n == 1)
            {
                Console.WriteLine("1 is not a prime or complex number.");
            }
            else
            {
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = true;
                        break;
                    }
                }

                if (result)
                {
                    Console.WriteLine(n + " is Complex number.");
                }
                else
                {
                    Console.WriteLine(n + " is Simple number.");
                }
            }

        }
    }
}
