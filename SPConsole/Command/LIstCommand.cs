using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using SPConsole.Utils;

namespace SPConsole.Command
{
    class LIstCommand : BaseCommand
    {
        public override void Execute()
        {
            ClientContext clientContext = Context.CreateClientContext();
            ListCollection lists = clientContext.Web.Lists;
            clientContext.Load(lists);
            clientContext.ExecuteQuery();

            Console.WriteLine("List counts: {0}", lists.Count);

            foreach (var list in lists)
            {
                Console.WriteLine(list.Title);
            }
        }
    }
}
