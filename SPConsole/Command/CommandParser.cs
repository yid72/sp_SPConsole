using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPConsole.Command
{
    public class CommandParser
    {
        public static ICommand ParseCommand(string strCommand)
        {
            if (String.IsNullOrEmpty(strCommand))
            {
                throw new NullReferenceException("command is empty");
            }

            return ParseCommand(strCommand.Split(' '));
        }

        public static ICommand ParseCommand(string[] tokens)
        {
            ICommand command;
            if ("alert".Equals(tokens[0], StringComparison.InvariantCultureIgnoreCase))
            {
                command = new AlertCommand();
            }
            else if ("email".Equals(tokens[0], StringComparison.InvariantCultureIgnoreCase))
            {
                command = new EmailCommand();
            }
            else if ("web".Equals(tokens[0], StringComparison.InvariantCultureIgnoreCase))
            {
                command = new WebCommand();
            }
            else if ("user".Equals(tokens[0], StringComparison.InvariantCultureIgnoreCase))
            {
                command = new UserCommand();
            }
            else if ("list".Equals(tokens[0], StringComparison.InvariantCultureIgnoreCase))
            {
                command = new LIstCommand();
            }
            else if ("exit".Equals(tokens[0], StringComparison.InvariantCultureIgnoreCase))
            {
                command = new EmailCommand();
            }
            else
            {
                throw new SPConsoleException("Unknown command: " + tokens[0]);
            }

            if (tokens.Length > 1)
            {
                string[] options = new string[tokens.Length - 1];
                Array.Copy(tokens, 1, options, 0, options.Length);
                command.ParseOptions(options);
            }

            return command;
        }
    }
}
