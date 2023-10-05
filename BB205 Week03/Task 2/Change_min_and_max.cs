using System;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { };

            if (numbers.Length == 0)
            {
                MinAndMaxSwapIndex(numbers);
            }
            else
            {
                Console.Write("Our array's elements: ");
                foreach (int i in numbers) Console.Write(i + " ");
                MinAndMaxSwapIndex(numbers);

                Console.Write("\n\nAfter the program our array: ");
                foreach (int i in numbers) Console.Write(i + " ");
                Console.WriteLine("\n\n\n");
            }


        }
        public static void MinAndMaxSwapIndex(params int[] arr)
        {
            if (arr.Length == 0) Console.WriteLine("There is no element in array!");
            else
            {
                int min = arr[0], max = arr[0];
                int minIndex = 0, maxIndex = 0, valueChanger = 0;

                for (int i = 2; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                    {
                        min = arr[i];
                        minIndex = i;
                    }
                    if (arr[i] > max)
                    {
                        max = arr[i];
                        maxIndex = i;
                    }
                }

                valueChanger = arr[maxIndex];
                arr[maxIndex] = arr[minIndex];
                arr[minIndex] = valueChanger;
            }
        }
    }
}