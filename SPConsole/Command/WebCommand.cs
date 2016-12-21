using System;
using SPConsole.Utils;

namespace SPConsole.Command
{
    internal class WebCommand : BaseCommand
    {
        public override void Execute()
        {
            var clientContext = Context.CreateClientContext();

            var web = clientContext.Web;
            clientContext.Load(web);
            clientContext.ExecuteQuery();
            Console.WriteLine("Title: " + web.Title);
            Console.WriteLine("Url: {0}", web.Url);
        }
    }
}