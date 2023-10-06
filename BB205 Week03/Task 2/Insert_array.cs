using System;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = { 13, 21, 14, 9, 34, 12, 4 };
            InsertArray(ref number, 23, 5, 12, 17);
            Console.WriteLine("Our elements: ");
            foreach (int i in number) Console.Write(i + " ");

        }
        public static void InsertArray(ref int[] arr, params int[] numbers)
        {
            int[] newArr = new int[numbers.Length + arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                newArr[arr.Length + i] = numbers[i];
            }

            arr = newArr;
        }
    }
}
