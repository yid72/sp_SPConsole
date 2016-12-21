using System;
using System.Collections.Generic;
using System.Linq;

namespace SPConsole.Command
{
    public class Option
    {
        public const string List = "list";

        private string _name;
        private List<string> _properties;

        public Option(string name)
        {
            _name = name;
        }

        public Option(string name, List<string> properties)
        {
            _name = name;
            if (properties != null)
            {
                _properties = properties.ToList();
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public List<string> Properties
        {
            get
            {
                return _properties;
            }
        }
    }
}
