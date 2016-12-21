using System;

namespace SPConsole.Command
{
    public class ExitCommand : BaseCommand
    {
        public override void Execute()
        {
            Environment.Exit(0);
        }
    }
}
