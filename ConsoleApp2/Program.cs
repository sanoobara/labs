
namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    namespace ConsoleAppDelete
    {
        class Program
        {

            public static void Main()
            {
                List<List<string>> words;
                List<List<string>> longestWords;


                Console.WriteLine("Введите '0', если хотите работать с файлом");
                int choose = int.Parse(Console.ReadLine());
                if (choose == 0)
                {
                    Console.WriteLine("Введите путь файла");
                    string pathfile = Console.ReadLine();

                    words = InputTextFromFile(pathfile);
                    longestWords = ShowLongestWords(words);
                    Console.WriteLine("Введите '0', вывести результат в в файл");

                    choose = int.Parse(Console.ReadLine());
                    if (choose == 0)
                    {
                        Console.WriteLine("Введите имя файла");
                        pathfile = Console.ReadLine();
                        OutputWordsToFile(longestWords, pathfile);
                    }
                }
                else
                {
                    words = ManualInput();
                    ShowLongestWords(words);
                }

                Console.ReadKey();
            }


            private static void OutputWordsToFile(List<List<string>> longestWords, string fileName)
            {
                var wordStringBuilder = new StringBuilder();


                wordStringBuilder.Append($"Самые длинные слова:\n");
                int count = 1;
                foreach (var wordds in longestWords)
                {
                    wordStringBuilder.Append($"{count++})");
                    foreach (var word in wordds)
                    {

                        wordStringBuilder.Append($" {word}");
                    }
                    wordStringBuilder.Append('\n');
                }




                File.WriteAllText(fileName, wordStringBuilder.ToString().Substring(0, wordStringBuilder.Length - 2));

            }

            private static List<List<string>> InputTextFromFile(string fileName)
            {
                List<List<string>> words = new List<List<string>>();
                words = File.ReadAllLines(fileName)
                    .Select(line => new List<string>(line.Split(' ')))
                    .ToList();




                Console.WriteLine($"Текст из файла {fileName} прочитан.");
                return words;
            }

            public static List<List<string>> ManualInput()
            {
                int linesCount;
                List<List<string>> words = new List<List<string>>();

                Console.Write("Введите количество строк: ");
                linesCount = int.Parse(Console.ReadLine());


                for (int i = 0; i < linesCount; i++)
                {
                    Console.Write($"\nВведите строку {i + 1}:");
                    words.Add(new List<string>(Console.ReadLine().Split(' ')));
                }

                return words;
            }

            public static List<List<string>> ShowLongestWords(List<List<string>> words)
            {
                int linesCount = words.Count;
                List<List<string>> longestWords;

                longestWords = new List<List<string>>();
                for (int i = 0; i < linesCount; i++)
                {
                   
                    List<string> temp = new List<string>();

                    foreach (var word in words[i])
                    {
                        temp.Add(String.Join(", ", word.Split(' ').Where(x => x.Contains('-') || x.Contains('_')).ToArray()));
                                                
                    }
                    longestWords.Add(temp);



                }


                Console.WriteLine($"Самые длинные слова:");
                int count = 1;
                foreach (var wordds in longestWords)
                {
                    Console.Write($"{count++})");
                    foreach (var word in wordds)
                    {

                        Console.Write($" {word}");
                    }
                    Console.WriteLine();
                }

                return longestWords;

            }
        }
    }
}
