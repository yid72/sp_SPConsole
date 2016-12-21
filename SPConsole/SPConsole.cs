using SPConsole.Command;
using System;

namespace SPConsole
{
    class SPConsole
    {
        private const string ConsolePrompt = "$> ";

        public void Run()
        {
            Console.WriteLine("SharePoint Alert Client Console\n\n");

            Console.Write(ConsolePrompt);
            string line = Console.ReadLine();
            while (line != null)
            {
                try
                {
                    ICommand command = CommandParser.ParseCommand(line);
                    command.Execute();
                }
                catch (SPConsoleException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                   Console.WriteLine(e.ToString());
                }

                Console.WriteLine();
                Console.Write(ConsolePrompt);
                line = Console.ReadLine();
            }
        }
    }
}
