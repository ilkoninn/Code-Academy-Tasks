using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 11, 3, 4, 7, 10, 11, 20, 31 };
            int numberIndex = 0, sum = 0;

            while (numberIndex < numbers.Length)
            {
                if (numberIndex % 2 != 0)
                {
                    sum += numbers[numberIndex];
                }
                numberIndex++;
            }

            Console.WriteLine("The sum of single index numbers: " + sum);


        }
    }
}