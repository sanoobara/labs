using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Console = System.Console;

namespace ConsoleAppDelete
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<List<string>> words;
            string[] longestWords;

            if (args.Length >= 1)
            {
                InputTextFromFile(out words, args[0]);
                ShowLongestWords(words, out longestWords);
                if (args.Length >= 2)
                {
                    OutputWordsToFile(longestWords, args[1]);
                }
            }
            else
            {
                words = ManualInput();
                ShowLongestWords(words, out longestWords);
            }

            Console.ReadKey();
        }

        private static void OutputWordsToFile(string[] longestWords, string fileName)
        {
            var wordStringBuilder = new StringBuilder();

            foreach (var word in longestWords)
            {
                wordStringBuilder.Append(word + ", ");
            }

            File.WriteAllText(fileName, wordStringBuilder.ToString().Substring(0, wordStringBuilder.Length - 2));
        }

        private static void InputTextFromFile(out List<List<string>> words, string fileName)
        {
            words = System.IO.File.ReadAllLines(fileName)
                .Select(line => new List<string>(line.Split(' ')))
                .ToList();

            Console.WriteLine($"Текст из файла {fileName} прочитан.");
        }

        public static List<List<string>> ManualInput()
        {
            int linesCount;
            List<List<string>> words = new List<List<string>>();

            Console.Write("Введите количество строк: ");
            while (!int.TryParse(Console.ReadLine(), out linesCount))
            {
                Console.Write("Не число. Повторите ввод: ");
            }

            for (int i = 0; i < linesCount; i++)
            {
                Console.Write($"\nВведите строку {i + 1}:");
                words.Add(new List<string>(Console.ReadLine().Split(' ')));
            }

            return words;
        }

        public static void ShowLongestWords(List<List<string>> words, out string[] longestWords)
        {
            int linesCount = words.Count;

            longestWords = new string[linesCount];
            for (int i = 0; i < linesCount; i++)
            {
                int maxLength = 0;

                foreach (var word in words[i])
                {
                    if (word.Length > maxLength)
                    {
                        maxLength = word.Length;
                        longestWords[i] = word;
                    }
                }
            }

            //Console.WriteLine($"Самые длинные слова: {string.Join(",\n ", longestWords)}");


            Console.WriteLine($"Самые длинные слова:");
            int count = 1;
            foreach (var word in longestWords)
            {
                Console.WriteLine($"{count++}) {word}");
            }

        }
    }
}