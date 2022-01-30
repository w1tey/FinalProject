using FinalProjectSharp;
using System;
using System.IO.Enumeration;
using System.Threading.Channels;

namespace FinalProject;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to Translator, a useless app." +
                          "\nPlease enter 2 languages (from and to) to create a new dictionary");
        var from = Console.ReadLine();
        var to = Console.ReadLine();
        var dictionary = new Dictionary(from, to);

        Console.WriteLine("Now, you will add words to your dictionary.");

        // Add words to dictionary
        while (true)
        {
            Console.WriteLine("1 - Continue" +
                              "\n2 - Enough words");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                List<string> translationsForWord = new List<string>();
                Console.Write("Enter the word you want to add:  ");
                var word = Console.ReadLine();

                while (true)
                {
                    Console.WriteLine("1 - Continue" +
                                      "\n2 - Enough Translations");
                    choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        Console.WriteLine("Enter word: ");
                        string? newTranslation = Console.ReadLine();
                        if (newTranslation != null) translationsForWord.Add(newTranslation);
                    }

                    else
                    {
                        break;
                    }
                }

                dictionary.Append(new Translation(word, translationsForWord));
            }

            else
            {
                break;
            }
        }

        Console.Clear();
        Console.WriteLine("Now see all of your translations.");
        dictionary.Print();

        Dictionary.Serialization(dictionary.Words);



        while (true)
        {
            Console.WriteLine("\nChoose one of these options:" +
                              "\n\t1 - Add a new translation to dictionary" +
                              "\n\t2 - Remove a word" +
                              "\n\t3 - Change a word / its translation" +
                              "\n\t4 - Print all the words" +
                              "\n\t5 - Exit");

            var choice = Console.ReadLine();

            switch (choice)
            {
                default:
                    break;
            }

            break;
        }

    }
}
