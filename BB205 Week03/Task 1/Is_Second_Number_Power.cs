using System;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInput = 1, secondInput = 200;
            if (IsFirstNumberPower(firstInput, secondInput))
            {
                Console.WriteLine(firstInput + " number is power of " + secondInput + ": " + secondInput + "^" + GetFirstNumberPower(firstInput, secondInput));
            }
            else
            {
                Console.WriteLine(firstInput + " number is not power of " + secondInput);
            }
        }
        public static bool IsFirstNumberPower(int firstNumber, int secondNumber)
        {
            int auxiliaryNumber = 0;

            while (firstNumber > 0)
            {
                if (firstNumber % secondNumber != 0)
                {
                    auxiliaryNumber = firstNumber;
                    break;
                }
                firstNumber /= secondNumber;
            }

            if (auxiliaryNumber == 1) return true;
            else return false;
        }
        public static int GetFirstNumberPower(int firstNumber, int secondNumber)
        {
            if (IsFirstNumberPower(firstNumber, secondNumber))
            {
                int countOfPower = -1;

                while (firstNumber > 0)
                {
                    countOfPower++;
                    firstNumber /= secondNumber;
                }

                return countOfPower;
            }
            else
            {
                return 0;
            }
        }

    }
}
