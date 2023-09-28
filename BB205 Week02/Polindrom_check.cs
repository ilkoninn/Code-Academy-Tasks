using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = "ata", testWords = "";

            for (int i = words.Length - 1; i >= 0; i--)
            {
                testWords += words[i];
            }

            if (testWords == words)
            {
                Console.WriteLine("The entered word is polindrom.");
            }
            else
            {
                Console.WriteLine("The entered word is not polindrom.");
            }

        }
    }
}