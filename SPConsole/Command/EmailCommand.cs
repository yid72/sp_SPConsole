using SPConsole.Utils;
using System.Threading.Tasks;

namespace SPConsole.Command
{
    class EmailCommand : BaseCommand
    {
        private const string from = "yid@microsoft.com";
        private const string defaultTo = from;
        private const string subject = "Unsubscribe your dialy digest email";
        private const string BodyTemplate = "<p>Click <a href=\"{UNSUBSCRIBE_URL}\">here</a> to unsubscribe your daily digest email.</p>";

        private string to = defaultTo;

        private NotifyRestClient client = new NotifyRestClient();

        private Emailer emailer = new Emailer();

        public new void ParseOptions(string[] options)
        {
            if (options.Length > 1)
            {
                to = options[0];
            }
        }
        public override void Execute()
        {
            Task<string> task = Task.Run(async () =>
            {
                return await client.GenerateUnsubscribeUrl();
            });
            Task.WaitAll(task);

            string url = task.Result;
            string body = BodyTemplate.Replace("{UNSUBSCRIBE_URL}", url);

            emailer.SendEmail(from, to, subject, body);
        }
    }
}
