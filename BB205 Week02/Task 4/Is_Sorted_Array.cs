using System;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 5, 6, 7, 8, };
            Console.Write("The numbers of array: ");
            for (int i = 0; i < numbers.Length; i++) Console.Write(numbers[i] + " ");
            Console.Write("\nIs this array sorted or not?: ");
            if (IsArraySorted(numbers)) Console.Write("Yes");
            else Console.Write("No");
        }
        public static bool IsArraySorted(int[] array)
        {
            bool checkSort = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    checkSort = true;
                }
                else
                {
                    checkSort = false;
                    break;
                }
            }

            return checkSort;

        }
    }
}
