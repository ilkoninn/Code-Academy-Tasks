using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Task
{
    public class MyClass
    {
        // Arithmetic operations
        public double Min(params double[] numbers)
        {
            double minimum = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < minimum) minimum = numbers[i];
            }
            return minimum;
        }
        public double Max(params double[] numbers)
        {
            double maximum = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < maximum) maximum = numbers[i];
            }
            return maximum;
        }
        public double Sum(params double[] numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        // Power of numbers method
        public double Power(double firstNumber, double secondNumber)
        {
            double newNumber = 1, i = 0;

            while (i < secondNumber)
            {
                newNumber *= firstNumber;
                i++;
            }

            return newNumber;
        }

        // Resize the array method. This is a method that works in terms of scaling up.
        public void InsertArray(ref int[] firstArr, params int[] secondArr)
        {
            int[] newArr = new int[firstArr.Length + secondArr.Length];

            for (int i = 0; i < firstArr.Length; i++) newArr[i] = firstArr[i];
            for (int i = 0; i < secondArr.Length; i++) newArr[firstArr.Length + i] = secondArr[i];

            firstArr = newArr;
        }
        public void InsertArray(ref float[] firstArr, params float[] secondArr)
        {
            float[] newArr = new float[firstArr.Length + secondArr.Length];

            for (int i = 0; i < firstArr.Length; i++) newArr[i] = firstArr[i];
            for (int i = 0; i < secondArr.Length; i++) newArr[firstArr.Length + i] = secondArr[i];

            firstArr = newArr;
        }
        public void InsertArray(ref double[] firstArr, params double[] secondArr)
        {
            double[] newArr = new double[firstArr.Length + secondArr.Length];

            for (int i = 0; i < firstArr.Length; i++) newArr[i] = firstArr[i];
            for (int i = 0; i < secondArr.Length; i++) newArr[firstArr.Length + i] = secondArr[i];

            firstArr = newArr;
        }

        // Sum of digits method
        public double SumOfDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }

        // Reverse the numerals in number.
        public double ReverseNumber(int number)
        {
            int reverse = 0;
            while (number > 0)
            {
                reverse = reverse * 10 + (number % 10);
                number /= 10;
            }

            return reverse;
        }

        // Find char index in string.
        public string FindCharIndex(string ourString, char ourChar)
        {
            if (ourString == "")
            {
                return "Our string is empty!";
            }
            else
            {
                string indexesOfChar = "";
                for (int i = 0; i < ourString.Length; i++)
                {
                    if (ourString[i] == ourChar)
                    {
                        indexesOfChar += i + " ";
                    }
                }
                if (indexesOfChar == "")
                {
                    return "There is no such a char in our string!";
                }
                else
                {
                    return indexesOfChar;
                }
            }
        }

        // Is the second number power of the first number?
        public bool IsSecondNumberPow(double firstNumber, double secondNumber)
        {
            double auxiliaryNumber = 0;

            while (secondNumber > 0)
            {
                if (secondNumber % firstNumber != 0)
                {
                    auxiliaryNumber = secondNumber;
                    break;
                }
                secondNumber /= firstNumber;
            }

            if (auxiliaryNumber == 1) return true;
            else return false;

        }

    }
}
