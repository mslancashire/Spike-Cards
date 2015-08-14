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
        private static List<String> commandNames = new List<String> { "Help", "ShowCommands", "Exit", "DisplayHand", "DisplayCollection" };

        static void Main(string[] args)
        {
            // check if buffer size is min size for display
            if (Console.BufferWidth < 80)
            {
                Console.WriteLine(String.Format("Your console buffer width must be at least 80 it is currently set at {0}.", Console.BufferWidth));
                return;
            }                     
            
            Console.WriteLine(new String('-', Console.BufferWidth-1));
            Console.WriteLine("Entering command mode.");
            Console.WriteLine("Please enter a command to run, use ShowCommands or Help to show availible commands that can be entered.");
            Console.WriteLine(new String('-', Console.BufferWidth-1));
            
            String commandString;
            String exitCommand = "Exit";
            int enteredCommandNumber = 0;
            do
            {
                enteredCommandNumber++;
                commandString = Console.ReadLine();

                if (IsValidCommand(commandString))
                {
                    Console.WriteLine("> Running command [{0}].", commandString);
                    RunCommand(commandString, enteredCommandNumber);
                    Console.WriteLine("> Finished, ready for next command.");
                }
                else
                {
                    Console.WriteLine(String.Format("Command [{0}] not valid please try again, use ShowCommands or Help to display availible commands.", commandString));
                }

            } while (commandString != null && String.Compare(commandString, exitCommand, true) != 0);
            
            Console.WriteLine(new String('-', Console.BufferWidth));
        }

        private static Boolean IsValidCommand(String commandName)
        {
            return commandNames.Contains(commandName, StringComparer.CurrentCultureIgnoreCase);
        }

        private static void RunCommand(String commandName, Int32 numberOfCommandsRan)
        {
            ICardsDisplay cardLayout = null;
            
            switch (commandName.ToLower())
            {
                case "help" :
                    Console.WriteLine("Please enter a command to run.");
                    break;
                case "showcommands" :
                    Console.WriteLine("The following commands can be run:");
                    Console.WriteLine(">>> " + String.Join("\n\r>>> ", commandNames.ToArray()));
                    break;
                case "exit" :
                    Console.WriteLine("Ran a total of " + numberOfCommandsRan.ToString() + " commands.");
                    Console.WriteLine("Exiting application.");
                    break;
                case "displayhand" :                    
                    Deck deck = Deck.GenerateRandomDeck(CardCollection.GenerateBasicCollection(), 5);
                    cardLayout = new CardLayoutReader(deck.Cards, LayoutSettings.GetDoubleBoxedLayout());
                    Console.WriteLine(cardLayout.DisplayCards());
                    break;
                case "displaycollection" :
                    CardCollection cardCollection = CardCollection.GenerateBasicCollection();
                    cardLayout = new CardLayoutReader(cardCollection.Cards, LayoutSettings.GetDoubleBoxedLayout());
                    Console.WriteLine(cardLayout.DisplayCards());
                    break;
                default:
                    var errorWritter = Console.Error;
                    errorWritter.WriteLine(String.Format("Command [{0}] not valid please try again, use ShowCommands or Help to display availible commands.", commandName));
                    break;
            }
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
