using System;

namespace MyApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number, firstDigit, secondDigit, thirdDigit, sumOfDigits;

            number = 278;

            firstDigit = number / 100;
            secondDigit = number / 10 % 10;
            thirdDigit = number % 10;
            sumOfDigits = firstDigit + secondDigit + thirdDigit;

            Console.WriteLine("Our number: " + number);
            if (number > 0)
            {
                Console.WriteLine("The sum of the number's digits: " + sumOfDigits);
            }
            else if (number == 0)
            {
                Console.WriteLine("The number is zero.");
            }
            else
            {
                Console.WriteLine("The sum of the number's digits: " + (-sumOfDigits));
            }
        }
    }
}