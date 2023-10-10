using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    internal class MyClass
    {
        // Contains section
        public bool Contains(string ourString, char ourChar)
        {
            bool checkChar = false;
            for(int i = 0; i < ourString.Length; i++)
            {
                if(ourChar == ourString[i])
                {
                    checkChar = true;
                    break;
                }
            }
            return checkChar;
        }
        public bool Contains(string ourString, string findString)
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

        // Replace section
        public string Replace(string ourString, char oldValue, char newValue)
        {

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ourString.Length; i++)
            {
                if (ourString[i] == oldValue)
                {
                    sb.Append(newValue);
                }
                else
                {
                    sb.Append(ourString[i]);
                }
            }

            return sb.ToString();
        }
        public string Replace(string ourString, string oldValue, string newValue)
        {

            int oldValuelength = oldValue.Length;
            int index = 0;

            while (ourString.Length >= index + oldValuelength)
            {
                if (ourString.Substring(index, oldValuelength) == oldValue)
                {
                    ourString = ourString.Substring(0, index) + newValue + ourString.Substring(index + oldValuelength);
                    index += oldValue.Length;
                }
                else
                {
                    index++;
                }
            }

            return ourString;
            
        }
        
        // Trim section
        public string Trim(string str)
        {
            StringBuilder stringBuilder = new StringBuilder(str);
            int countForward = 0, countBackward = 0;
            for (int i = (stringBuilder.Length - 1); i >= 0 ; i--)
            {
                if (stringBuilder[i] != ' ')
                {
                    break;
                }
                countBackward++;
            }
            for(int i = 0; 0 < stringBuilder.Length; i++)
            {
                if (stringBuilder[i] != ' ')
                {
                    break;
                }
                countForward++;
            }
            stringBuilder.Remove(0, countForward);
            stringBuilder.Remove(stringBuilder.Length - countBackward, countBackward);

            return stringBuilder.ToString();
        }

        // Substring section
        public string Substring(string ourString, int index)
        {
            StringBuilder stringBuilder = new StringBuilder(ourString);
            stringBuilder.Remove(0, index);

            return stringBuilder.ToString();
        }
        public string Substring(string ourString, int firstIndex,  int lastIndex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = firstIndex; i <= lastIndex + firstIndex - 1; i++)
            {
                stringBuilder.Append(ourString[i]);
            }

            return stringBuilder.ToString();
        }
    }
}
