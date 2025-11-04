using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("What do you want to do?\n");
            Console.WriteLine("1 - Open file");
            Console.WriteLine("2 - Create new file");
            Console.WriteLine("0 - Exit");
            Console.Write("\nChoose: ");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("What is the file path? (Ex: C:/dev/text.txt)");
            string path = Console.ReadLine();
            Console.WriteLine("\n");

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text + "\n");
            }

            Console.ReadKey();
            Menu();
        }
        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Type your text below (ESC to finish)");
            Console.WriteLine("=======================");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += "\n";
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
        }
        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("WWhat path to save the file? (Ex: C:/dev/text.txt)");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"\nFile {path} saved successfully.");
            Console.ReadKey();
            Menu();
        }
    }
}