using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethods.Models
{
    internal static class ExtensionMethods
    {
        // Contain section
        public static bool CustomContains(this string ourString, char ourChar)
        {
            bool checkChar = false;
            for (int i = 0; i < ourString.Length; i++)
            {
                if (ourChar == ourString[i])
                {
                    checkChar = true;
                    break;
                }
            }
            return checkChar;
        }
        public static bool CustomContains(this string ourString, string findString)
        {
            int lengthOfFind = findString.Length;
            bool checkFind = false;

            if (ourString.Length < lengthOfFind)
            {
                checkFind = false;
            }
            else
            {
                int index = 0;
                while (ourString.Length >= index + lengthOfFind)
                {
                    if (ourString.Substring(index, lengthOfFind) == findString)
                    {
                        checkFind = true;
                        break;
                    }
                    else
                    {
                        index++;
                    }
                }
            }

            return checkFind;
        }

        // Is power of two section
        public static bool IsPowOfTwo(this int number)
        {
            int auxiliaryNumber = 0;

            while (number > 0)
            {
                if (number % 2 != 0)
                {
                    auxiliaryNumber = number;
                    break;
                }
                number /= 2;
            }

            if (auxiliaryNumber == 1) return true;
            else return false;
        }

        // Is prime number section
        public static bool IsPrime(this int number)
        {
            if(number < 0)
            {
                number = -1 * number;
            }
            bool result = true;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }
}
