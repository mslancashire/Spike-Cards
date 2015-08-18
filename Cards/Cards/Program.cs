using Domain;
using Domain.Cards;
using Domain.Cards.Readers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
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

        /*
        ICardsDisplay cardLayout;
        Deck deck = Deck.GenerateRandomDeck(CardCollection.GenerateBasicCollection(), 5);

        cardLayout = new CardLayoutReader(deck.Cards, LayoutSettings.GetDoubleBoxedLayout());
        Console.WriteLine(cardLayout.DisplayCards());
        */

        /*
        // Read Key Type
        ConsoleKeyInfo cki;
        Console.TreatControlCAsInput = true;

        Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.");
        Console.WriteLine("Press the Escape (Esc) key to quit: \n");
        do
        {
            cki = Console.ReadKey();
            Console.Write(" --- You pressed ");
            if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
            if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
            if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
            Console.WriteLine(cki.Key.ToString());
        } while (cki.Key != ConsoleKey.Escape);
        */
    }
}
