using System;

namespace Collection
{
    class Program
    {
        static void Main()
        {
            var test = new SimpleList {"one", "two", "three", "four", "five", "six", "seven", "eight"};

            test.PrintContents();

            Console.WriteLine("Mazeme");
            test.Remove("six");
            test.Remove("eight");
            test.PrintContents();

            Console.WriteLine("Pridavame");
            test.Add("nine");
            test.PrintContents();
           
            Console.WriteLine("Pridavame element do stredu kol.");
            test.Insert(4, "number");
            test.PrintContents();

            Console.WriteLine("Kontrola elementu v kol:");
            Console.WriteLine("three\": {0}", test.Contains("three"));
            Console.WriteLine("ten\"  : {0}", test.Contains("ten"));

            Console.WriteLine("\nKonec ted:");
            foreach (string s in test)
            {
                Console.WriteLine(s);
            }
            // Delay.
            Console.ReadKey();
        }
    }
}
