using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBAGame
{
    internal class ConsoleText
    {
        public void CleanLine(string text)
        {
            Console.Clear();
            Console.WriteLine(text);
        }
        public void CleanLine(string text, ConsoleColor fgColor)
        {
            Console.Clear();
            ConsoleColor prevFgColor = Console.ForegroundColor;
            Console.ForegroundColor = fgColor;
            Console.WriteLine(text);
            Console.ForegroundColor = prevFgColor;  
        }
        public void CleanLine(string text, ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Console.Clear();
            ConsoleColor prevFgColor = Console.ForegroundColor;
            ConsoleColor prevBgColor = Console.BackgroundColor;
            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;
            Console.WriteLine(text);
            Console.ForegroundColor = prevFgColor;
            Console.BackgroundColor = prevBgColor;
        }
        public void AddLine(string text)
        {
            Console.WriteLine(text);
        }
        public void AddLine(string text, ConsoleColor fgColor)
        {
            ConsoleColor prevFgColor = Console.ForegroundColor;
            Console.ForegroundColor = fgColor;
            Console.WriteLine(text);
            Console.ForegroundColor = prevFgColor;
        }
        public void AddLine(string text, ConsoleColor fgColor, ConsoleColor bgColor)
        {
            ConsoleColor prevFgColor = Console.ForegroundColor;
            ConsoleColor prevBgColor = Console.BackgroundColor;
            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;
            Console.WriteLine(text);
            Console.ForegroundColor = prevFgColor;
            Console.BackgroundColor = prevBgColor;
        }
        public string GetLine()
        {
            string? text = Console.ReadLine();
            while(text == null)
            {
                text = Console.ReadLine();
            }
            return text;
        }

        public int GetLineInt(int max)
        {
            while (true)
            {
                string? text = Console.ReadLine();
                if (Int32.TryParse(text, out int result))
                {
                    if (result < 1 || result > max)
                    {
                        AddLine("You must enter a number 1-"+max);
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {
                    AddLine("You must enter a whole number 1-"+max);
                }
            }
        }

    }
}
