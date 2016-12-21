using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPConsole.Command
{
    public interface ICommand
    {
        void ParseOptions(string[] options);

        void Execute();
    }
}
