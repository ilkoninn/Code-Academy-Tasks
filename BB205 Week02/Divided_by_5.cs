using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber, thirdNumber, sumOfNumbers;
         
            firstNumber = 6;
            secondNumber = 10;
            thirdNumber = 20;
            sumOfNumbers = 0;

            Console.WriteLine("Our numbers: " + firstNumber + ", " + secondNumber + ", " + thirdNumber);
            
            if (firstNumber > 0 && secondNumber > 0 && thirdNumber > 0) 
            {
                if(firstNumber % 5 == 0)
                {
                    sumOfNumbers += firstNumber;
                }
                if (secondNumber % 5 == 0)
                {
                    sumOfNumbers += secondNumber;
                }
                if(thirdNumber % 5 == 0) 
                { 
                    sumOfNumbers += thirdNumber; 
                }
                Console.WriteLine("The sum of numbers, which they are divided by 5: " + sumOfNumbers);
            }
            else
            {
                Console.WriteLine("Numbers should be a positive!");
            };


        }
    }
}