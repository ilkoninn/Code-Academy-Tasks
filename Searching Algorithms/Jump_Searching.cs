using System;

namespace MyApp
{
    class Program
    {
        public static int jumpSearch(int[] arr, int x)
        {
            int n = arr.Length;

            int step = (int)Math.Sqrt(n);

            int prev = 0;
            for (int minStep = Math.Min(step, n) - 1; arr[minStep] < x; minStep = Math.Min(step, n) - 1)
            {
                prev = step;
                step += (int)Math.Sqrt(n);
                if (prev >= n)
                    return -1;
            }

            while (arr[prev] < x)
            {
                prev++;

                if (prev == Math.Min(step, n))
                    return -1;
            }

            if (arr[prev] == x)
                return prev;

            return -1;
        }

        public static void Main()
        {
            int[] arr = { 0, 1, 1, 2, 3, 5, 8, 13, 21,
                    34, 55, 89, 144, 233, 377, 610};
            int x = 55;

            int index = jumpSearch(arr, x);

            Console.Write("Number " + x +
                                " is at index " + index);
        }
    }
}