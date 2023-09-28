using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The squeared numbers(1-25):");
            for (float i = 1; i * i <= 25; i++)
            {
                Console.Write(i + " ");
            }
        }
    }
}