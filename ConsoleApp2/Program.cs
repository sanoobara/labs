
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
            public static void Main(string[] args)
            {
                List<List<string>> words;
                List<List<string>> longestWords;
                if (args.Length >= 3)
                {
                    words = InputTextFromFile(args[0], int.Parse(args[2]));
                    longestWords = ShowLongestWords(words);
                    if (args.Length >= 2)
                    {
                        //OutputWordsToFile(longestWords, args[1]);
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

            private static List<List<string>> InputTextFromFile(string fileName, int n)
            {
                List<List<string>> words = new List<List<string>>();


                StreamReader sr = File.OpenText(fileName);
                var wordStringBuilder = new List<StringBuilder>();

                var ministring = new StringBuilder();
                Console.WriteLine($"Объём данных в потоке: {sr.BaseStream.Length}");

                try
                {

                   

                    char[] buffer = new char[n];


                    do
                    {
                        n = sr.Read(buffer, 0, n);
                        int j = 0;
                        for (int i = 0; i < n; i++)
                        {
                            if (buffer[i] == '\n')
                            {
                                j++;
                                wordStringBuilder.Add(ministring);
                                ministring= new StringBuilder();

                            }
                            else
                            {
                                ministring.Append(buffer[i].ToString());
                            }
                            

                        }
                    }
                    while (n != 0);

                    sr.Close();
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }





                words = wordStringBuilder
                            .Select(line => new List<string>(line.ToString().Split(' ')))
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
