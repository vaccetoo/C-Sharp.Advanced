namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);

            string line = string.Empty;

            int linesCount = 0;

            StringBuilder sb = new StringBuilder();

            while ((line = reader.ReadLine()) != null)
            {
                if (linesCount % 2 == 0)
                {
                    string replacedSymbols = ReplaceSymbols(line);
                    string reversedWords = ReverseWords(replacedSymbols);
                    sb.AppendLine(reversedWords);
                }

                linesCount++;
            }

            return sb.ToString();
        }

        private static string ReplaceSymbols(string text)
        {
            char[] symbolsToReplace = {'-', ',', '.', '!', '?'};

            StringBuilder sb = new StringBuilder(text);

            foreach (char symbol in symbolsToReplace)
            {
                sb = sb.Replace(symbol, '@');
            }

            return sb.ToString();
        }

        private static string ReverseWords(string text)
        {
            string[] reversedString = text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            
            return string.Join(" ", reversedString);
        }
    }
}
