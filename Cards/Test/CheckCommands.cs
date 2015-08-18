using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Cards.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class CheckCommands
    {
        private CommandParser testCommandParser;
        private CommandParser normalCommadParser;
        private Stream outputStream;

        [TestInitialize]
        public void SetupCommandParser()
        {
            /*
            outputStream = new MemoryStream();
           
            testCommandParser = new CommandParser(outputStream, Console.OutputEncoding, true);            
            */
            testCommandParser = new CommandParser();
            testCommandParser.CommandNames = new List<String> { "Test1", "Test2", "Test3", "Exit" };
            normalCommadParser = new CommandParser();
        }

        [TestMethod]
        public void TestIsValidCommand()
        {
            Assert.IsTrue(testCommandParser.IsValidCommand("Test1"), "Ensure a test command is valid.");
            Assert.IsTrue(testCommandParser.IsValidCommand("Exit"), "Ensure the exit command is valid");
            Assert.IsFalse(testCommandParser.IsValidCommand("CommandNotHere"), "Ensure the command is not valid");
        }

        [TestMethod]
        public void TestParseOfSingleCommand()
        {
            String commandLine = String.Empty;
            String commandName;
            List<String> commandArguments;

            commandLine = "Test1";
            Assert.IsTrue(testCommandParser.TryParseCommandLine(commandLine, out commandName, out commandArguments), "Ensure single command is found.");
            Assert.IsTrue(commandName == commandLine, "Ensure single command name is correct.");
            Assert.IsNotNull(commandArguments, "Ensure arguments list has been created.");
            Assert.IsTrue(commandArguments.Count == 0, "Ensure argument list contains no arguments");
        }

        [TestMethod]
        public void TestParseOfSingleCommandWithOneArgument()
        {
            String commandLine = String.Empty;
            String commandName;
            List<String> commandArguments;

            commandLine = "Test1 TestArg1";
            Assert.IsTrue(testCommandParser.TryParseCommandLine(commandLine, out commandName, out commandArguments), "Ensure single command is found.");
            Assert.IsTrue(commandName == "Test1", "Ensure single command name is correct.");
            Assert.IsNotNull(commandArguments, "Ensure single arguments list has been created.");
            Assert.IsTrue(commandArguments.Count == 1, "Ensure argument list contains one argument.");
        }

        [TestMethod]
        public void TestParseOfSingleCommandWithMultpleArguments()
        {
            String commandLine = String.Empty;
            String commandName;
            List<String> commandArguments;

            commandLine = "Test1 TestArg1 TestArg2 TestArg3";
            Assert.IsTrue(testCommandParser.TryParseCommandLine(commandLine, out commandName, out commandArguments), "Ensure single command is found.");
            Assert.IsTrue(commandName == "Test1", "Ensure single command name is correct.");
            Assert.IsNotNull(commandArguments, "Ensure single arguments list has been created.");
            Assert.IsTrue(commandArguments.Count == 3, "Ensure argument list contains three arguments.");
            Assert.AreEqual("TestArg1", commandArguments[0], "Ensure argument 1 is correct.");
            Assert.AreEqual("TestArg2", commandArguments[1], "Ensure argument 2 is correct.");
            Assert.AreEqual("TestArg3", commandArguments[2], "Ensure argument 3 is correct.");
        }

        [TestMethod]
        public void TestDisplayHandCommand()
        {
            // cards in hand are randomised so we can only count the lines and ensure the number of lines are correct.
            // we can rely on the Layout Tests to ensure the output display is correct, we just need to ensure we have ouput.

            Boolean continueToRun = normalCommadParser.RunCommandLineInput("DisplayHand");            
            Assert.IsTrue(continueToRun, "Ensure command return with continue state.");

            var lineNumber = 1;
            var outputReader = new StringReader(normalCommadParser.CommandOutput);

            while (true)
            {
                String outputLine = outputReader.ReadLine();

                if (outputLine == null)
                {
                    break;
                }

                lineNumber++;
            }

            Assert.AreEqual(11, lineNumber, "Ensure we output the correct number of lines.");

        }

        ~CheckCommands()
        {
            if (outputStream != null)
            {
                this.outputStream.Close();
                this.outputStream.Dispose();
            }
        }
    }
}
