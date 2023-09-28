using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 11, 3, 4, 7, 10, 11, 20, 31 };
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                bool check = false;

                if (numbers[i] == 1)
                {
                    continue;
                }
                else
                {
                    for (int j = 2; j * j <= numbers[i]; j++)
                    {
                        if (numbers[i] % j == 0)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (check == false)
                    {
                        sum += numbers[i];
                    }
                }
            }

            Console.WriteLine("The sum of prime numbers in array: " + sum);
        }
    }
}