using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards.App.Commands
{
    public class CommandParser
    {
        private List<String> _commandNames;
        private Int32 _numberOfCommandsRan;
        private StringBuilder _output;

        public CommandParser()
        {
            _commandNames = new List<String> { "Help", "ShowCommands", "Exit", "DisplayHand", "DisplayCollection" };
            _numberOfCommandsRan = 0;
            _output = new StringBuilder();
        }

        public List<String> CommandNames
        {
            get { return _commandNames; }
            set { _commandNames = value; }
        }

        public String CommandOutput
        {
            get { return _output.ToString(); }
        }


        /// <summary>
        /// Check is the command name is valid for the state of the game.
        /// </summary>
        /// <param name="commandName">The command name to validate.</param>
        /// <returns>True if the provided command name is valid or false if not.</returns>
        public Boolean IsValidCommand(String commandName)
        {
            return _commandNames.Contains(commandName);
        }

        /// <summary>
        /// Runs the given command line for the card game.
        /// </summary>
        /// <param name="commandLine">Command line to run.</param>
        /// <returns>If the game should continue to run.</returns>
        public Boolean RunCommandLineInput(String commandLine)
        {
            Boolean continueRunning = true;
            String commandName;
            List<String> commandArguments;

            if (this.IsValidCommand(commandLine) && TryParseCommandLine(commandLine, out commandName, out commandArguments))
            {
                continueRunning = RunCommand(commandName, commandArguments);
            }
            else
            {
                AddToOutput(String.Format("Command [{0}] not valid please try again, use ShowCommands or Help to display availible commands.", commandLine));
            }

            return continueRunning;
        }

        /// <summary>
        /// Tries to parse the given command line into the command name to execute and any arguments it needs.
        /// </summary>
        /// <param name="commandLine">The command line to parse.</param>
        /// <param name="commandName">An outputted command name that can be executed.</param>
        /// <param name="commandArguments">An outputted list of arguments for the command name.</param>
        /// <returns>True if the parsing of the command line was sucessfull if not it returns false.</returns>
        public Boolean TryParseCommandLine(String commandLine, out String commandName, out List<String> commandArguments)
        {
            Boolean isValid = false;
            List<String> commandList = null;
            commandName = String.Empty;
            commandArguments = new List<String>();

            if (commandLine != null)
            {

                commandList = new List<String>(commandLine.Split(' '));

                if (commandList != null && commandList.Count > 0)
                {
                    // assign comand name
                    commandName = commandList[0];

                    // assign arguments list
                    if (commandList.Count > 1)
                    {
                        commandArguments = commandList.GetRange(1, commandList.Count - 1);
                    }

                    isValid = true;
                }
            }

            return isValid;
        }

        public void AddToOutput(String output)
        {
            this._output.AppendLine(output);
        }

        public Boolean RunCommand(String commandName, List<String> arguments)
        {
            Boolean continueRunning = true;
            //ICardReader cardLayout = null;
            //LayoutSettings currentLayoutSettings = LayoutSettings.GetDoubleBoxedLayout();

            _numberOfCommandsRan++;

            switch (commandName.ToLower())
            {
                case "help":
                    AddToOutput("Please enter a command to run.");
                    break;
                case "showcommands":
                    AddToOutput("The following commands can be run:");
                    AddToOutput(">>> " + String.Join("\n\r>>> ", _commandNames.ToArray()));
                    break;
                case "":
                case "exit":
                    AddToOutput("Ran a total of " + _numberOfCommandsRan + " commands.");
                    AddToOutput("Exiting application.");
                    continueRunning = false;
                    break;
                case "displayhand":
                    //Deck deck = Deck.GenerateRandomDeck(CardCollection.GenerateBasicCollection(), 5);
                    //cardLayout = new TemplateBasedCardReader(deck.Cards, currentLayoutSettings, "Detailed.txt");
                    //AddToOutput(cardLayout.DisplayCards());
                    break;
                case "displaycollection":
                    //CardCollection cardCollection = CardCollection.GenerateBasicCollection();
                    //List<Card> cards = null;

                    if (arguments == null || arguments.Count == 0)
                    {
                        //cards = cardCollection.Cards;
                    }
                    else if (arguments.Contains("FilterByCost"))
                    {
                        var cost = Int32.Parse(arguments[arguments.IndexOf("Filter") + 1]);
                        //Predicate<Card> costFilter = item => item.Cost == cost;
                        //cards = cardCollection.Cards.FindAll(costFilter);
                    }

                    //cardLayout = new TemplateBasedCardReader(cards, currentLayoutSettings, "Detailed.txt");
                    //AddToOutput(cardLayout.DisplayCards());
                    break;
                default:
                    var errorWritter = Console.Error;
                    errorWritter.WriteLine(String.Format("Command [{0}] not valid please try again, use ShowCommands or Help to display availible commands.", commandName));
                    break;
            }

            return continueRunning;
        }
    }
}
