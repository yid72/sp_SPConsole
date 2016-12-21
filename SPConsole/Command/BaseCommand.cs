using System;
using System.Collections.Generic;

namespace SPConsole.Command
{
    public abstract class BaseCommand : ICommand
    {
        protected OptionCollection optionCollection = new OptionCollection();

        public BaseCommand()
        {}

        public void ParseOptions(string[] options)
        {
            int i = 0;
            while (i < options.Length)
            {
                if (!options[i].StartsWith("-"))
                {
                    throw new SPConsoleException("Bad command option: " + options[i]);
                }

                string optionName = options[i++].Substring(1);

                List<string> properties = null;

                if (i < options.Length && !options[i].StartsWith("-"))
                {
                    properties = new List<string>();
                    while (i < options.Length && !options[i].StartsWith("-"))
                    {
                        properties.Add(options[i++]);
                    }
                }

                Option option = new Option(optionName, properties);
                optionCollection.AddOption(option);
            }
        }

        public abstract void Execute();
    }
}
