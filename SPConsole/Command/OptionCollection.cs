using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPConsole.Command
{
    public class OptionCollection
    {
        private LinkedList<Option> options = new LinkedList<Option>();

        public void AddOption(Option option)
        {
            options.AddLast(option);
        }

        public bool Contains(string name)
        {
            foreach (Option option in options)
            {
                if (option.Name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
