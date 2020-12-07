using System;

namespace mbaaz.AdventOfCode2020.Common.Tasks
{
    public class Printer
    {
        private const int PRINT_CHAR_WIDTH = 80;
        private const char PRINT_SPECIAL = '*';
        private const char PRINT_FILLER  = ' ';

        public void PrintHeaderSection(string text)
        {
            var lines = text.SplitToLines(PRINT_CHAR_WIDTH);
            foreach (var line in lines)
            {
                PrintHeader(line);
            }
            PrintNewLine();
        }

        public void PrintSection(string text)
        {
            var lines = text.SplitToLines(PRINT_CHAR_WIDTH);
            foreach (var line in lines)
            {
                Print(line);
            }
            PrintNewLine();
        }

        public void PrintSeparator()
            => PrintRow(new string(PRINT_SPECIAL, PRINT_CHAR_WIDTH));

        public void PrintNewLine()
            => PrintRow(new string(PRINT_FILLER, PRINT_CHAR_WIDTH));

        private void PrintHeader(string title)
            => PrintCentered(title.ToUpper(), PRINT_SPECIAL);

        private void Print(string text, char filler = PRINT_FILLER)
        {
            if(text.Length > (PRINT_CHAR_WIDTH))
                throw new ApplicationException("Text is too long to print on one line!");

            text = $"{text} ";

            var padding = new string(filler, PRINT_CHAR_WIDTH - text.Length);
            PrintRow($"{text}{padding}");
        }

        private void PrintCentered(string text, char filler = PRINT_FILLER)
        {
            if(text.Length > (PRINT_CHAR_WIDTH))
                throw new ApplicationException("Text is too long to print on one line!");

            text = (text.Length % 2 == 1)
                    ? $" {text}  "
                    : $" {text} "
                ;

            var padding = new string(filler, (PRINT_CHAR_WIDTH - text.Length) / 2);
            PrintRow($"{padding}{text}{padding}");
        }

        private void PrintRow(string text)
            => Console.WriteLine($"{PRINT_SPECIAL} {text} {PRINT_SPECIAL}");
    }
}