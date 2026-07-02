using System;
using System.Text;

namespace Cards.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.GetEncoding(437);

            // check if buffer size is min size for display
            if (Console.BufferWidth < 80)
            {
                Console.WriteLine(String.Format("Your console buffer width must be at least 80 it is currently set at {0}.", Console.BufferWidth));
                return;
            }

            //Commands.CommandParser commandParser = new Commands.CommandParser(Console.OpenStandardOutput(), Console.OutputEncoding, true);
            Commands.CommandParser commandParser = new Commands.CommandParser();

            Console.WriteLine(new String('-', Console.BufferWidth - 1));
            Console.WriteLine("Entering command mode.");
            Console.WriteLine("Please enter a command to run, use ShowCommands or Help to show availible commands that can be entered.");
            Console.WriteLine(new String('-', Console.BufferWidth - 1));

            Boolean continueRunning = true;

            do
            {
                continueRunning = commandParser.RunCommandLineInput(Console.ReadLine());
                Console.Write(commandParser.CommandOutput);
            } while (continueRunning);

            Console.WriteLine(new String('-', Console.BufferWidth));
        }
    }
}