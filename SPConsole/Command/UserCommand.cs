using System;
using SPConsole.Utils;

namespace SPConsole.Command
{
    internal class UserCommand : BaseCommand
    {
        public override void Execute()
        {
            var clientContext = Context.CreateClientContext();

            var web = clientContext.Web;
            clientContext.Load(web);

            var user = web.CurrentUser;
            clientContext.Load(user);

            var infoList = web.SiteUserInfoList;
            clientContext.Load(infoList);

            clientContext.ExecuteQuery();

            var item = infoList.GetItemById(user.Id);

            Console.WriteLine("User id: " + user.UserId.NameId);
            Console.WriteLine("Login name: " + user.LoginName);
            Console.WriteLine("Email: " + user.Email);
            Console.WriteLine("IsSiteAdmin: " + user.IsSiteAdmin);
            Console.WriteLine("Properties:");
            foreach (var keyValuePair in item.Properties.FieldValues)
            {
                Console.WriteLine(keyValuePair);
            }
        }
    }
}