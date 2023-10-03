using System;

namespace MyApp
{
    class Program
    {
        public static int min(int x, int y)
        {
            return (x <= y) ? x : y;
        }

        public static int fibMonaccianSearch(int[] arr, int x,
                                             int n)
        {
            int fibMMm2 = 0; // (m-2)'th Fibonacci No.
            int fibMMm1 = 1; // (m-1)'th Fibonacci No.
            int fibM = fibMMm2 + fibMMm1; // m'th Fibonacci

            while (fibM < n)
            {
                fibMMm2 = fibMMm1;
                fibMMm1 = fibM;
                fibM = fibMMm2 + fibMMm1;
            }

            int offset = -1;

            while (fibM > 1)
            {
                int i = min(offset + fibMMm2, n - 1);

                if (arr[i] < x)
                {
                    fibM = fibMMm1;
                    fibMMm1 = fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                    offset = i;
                }

                else if (arr[i] > x)
                {
                    fibM = fibMMm2;
                    fibMMm1 = fibMMm1 - fibMMm2;
                    fibMMm2 = fibM - fibMMm1;
                }

                else
                    return i;
            }

            if (fibMMm1 == 1 && arr[n - 1] == x)
                return n - 1;

            return -1;
        }

        public static void Main()
        {
            int[] arr = { 10, 22, 35, 40, 45, 50,
                      80, 82, 85, 90, 100,235 };
            int n = 12;
            int x = 235;
            int ind = fibMonaccianSearch(arr, x, n);
            if (ind >= 0)
                Console.Write("Found at index: " + ind);
            else
                Console.Write(x + " isn't present in the array");
        }
    }
}