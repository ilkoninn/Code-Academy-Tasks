using System;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ourWord = "ilki02nnn";
            char ourAlphabet = 'n';
            Console.Write("Our word: ");
            Console.WriteLine(ourWord);
            Console.Write("Our char: ");
            Console.WriteLine(ourAlphabet);
            if (FindCharInString(ourWord, ourAlphabet) == "")
            {
                Console.WriteLine("\nThere is no like char in our word!\n");
            }
            else if (FindCharInString(ourWord, ourAlphabet).Length == 1)
            {
                Console.Write("\n" + ourAlphabet + " index is: " + FindCharInString(ourWord, ourAlphabet));
                Console.WriteLine();
            }
            else
            {
                Console.Write("\n" + ourAlphabet + " indexes are: ");
                foreach (char c in FindCharInString(ourWord, ourAlphabet)) Console.Write(c + " ");
                Console.WriteLine();
            }
        }
        public static string FindCharInString(string text, char ourChar)
        {
            string indexOfChar = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ourChar)
                {
                    indexOfChar += i;
                }
            }

            if (indexOfChar == "") return "";
            else return indexOfChar;
        }
    }
}
