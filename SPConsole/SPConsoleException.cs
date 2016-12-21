using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPConsole
{
    class SPConsoleException : Exception
    {
        public SPConsoleException()
        {
        }

        public SPConsoleException(string message) : base(message)
        {
        }
    }
}
