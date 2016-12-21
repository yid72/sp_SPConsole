using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.SharePoint.Client;
using SPConsole.Utils;

namespace SPConsole.Command
{
    public class AlertCommand : BaseCommand
    {
        public override void Execute()
        {
            var clientContext = Context.CreateClientContext();

            if (optionCollection.Contains("add"))
            {
                Console.Write("Please input alert title: ");
                string title = Console.ReadLine();

                if (string.IsNullOrEmpty(title))
                {
                    return;
                }

                var alerts = clientContext.Web.CurrentUser.Alerts;
                clientContext.Load(alerts);

                var lists = clientContext.Web.Lists;
                clientContext.Load(lists);

                clientContext.ExecuteQuery();

                var info = new AlertCreationInformation
                {
                    Title = title,
                    User = clientContext.Web.CurrentUser,
                    List = lists[0],
                    EventType = AlertEventType.All,
                    AlertType = AlertType.List,
                    DeliveryChannels = AlertDeliveryChannel.Email,
                    AlertFrequency = AlertFrequency.Daily,
                    AlertTime = DateTime.Now,
                    Properties = new Dictionary<string, string>()
                };

                alerts.Add(info);
                clientContext.ExecuteQuery();
            }
            else if (optionCollection.Contains("del"))
            {
                Console.Write("Please input the ID of the alert: ");
                string strID = Console.ReadLine();
                Guid ID = new Guid(strID);

                var alerts = clientContext.Web.CurrentUser.Alerts;
                clientContext.Load(alerts);
                clientContext.ExecuteQuery();

                alerts.DeleteAlert(ID);
                clientContext.ExecuteQuery();

                Console.WriteLine("Alert " + ID + " is deleted.");
            }
            else
            {
                var alerts = clientContext.Web.CurrentUser.Alerts;
                clientContext.Load(alerts);
                clientContext.ExecuteQuery();

                Console.WriteLine("Alert counts: {0}", alerts.Count);
                Console.WriteLine();

                if (alerts.Count > 0)
                {
                    IEnumerator emurator = alerts.GetEnumerator();
                    int i = 1;
                    while (emurator.MoveNext())
                    {
                        var alert = (Microsoft.SharePoint.Client.Alert) emurator.Current;
                        Console.WriteLine("Alert {0}---", i++);

                        Console.WriteLine("ID={0}", alert.ID);
                        Console.WriteLine("Title={0}", alert.Title);
                        Console.WriteLine("Frequency={0}", alert.AlertFrequency);
                        Console.WriteLine("Delivery Channel: {0}", alert.DeliveryChannels);
                    }
                }
            }
        }
    }
}