using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 12, 1, -5, 12, 45, 23, 55 };
            Console.Write("The numbers of array: ");
            for (int i = 0; i < numbers.Length; i++) Console.Write(numbers[i] + " ");
            Console.Write("\nThe minimum element of array: ");
            Console.Write(MinElementOfArray(numbers));
        }

        public static int MinElementOfArray(int[] array)
        {

            int minElement = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minElement)
                {
                    minElement = array[i];
                }
            }

            return minElement;

        }
    }
}