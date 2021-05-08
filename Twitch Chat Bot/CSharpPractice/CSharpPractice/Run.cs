using System;
using System.Web;

namespace CSharpPractice
{

    class Program
    {
        static void Main()
        {
            IRClient client = new IRClient("irc.twitch.tv", 6667, "NotaHenryBot", "oauth:vskbfwvtou13yfajxpnhl4od0gzaw6", "henryfundenberger");


            var ping = new Ping(client);
            ping.Start();
            while (true)
            {
                var random = new Random();
                


               
                // Get User Info Per Message
                var message = client.ReadMesage();
                string[] GetInfo = message.Split("!");             
                var user = GetInfo[0];
                GetInfo = user.Split(":");
                user = GetInfo[1].Trim();

                try
                {
                    GetInfo = message.Split(":");
                    message = GetInfo[2];
                }
                catch
                {
                    continue;
                }

                // Send user message to console
                Console.WriteLine($"{user}: {message}");
                
                if (message.Contains("!gamerword"))
                {
                    client.SendChatMessage("The N word is bad sim :)");
                    continue;
                }


                // Interpert User Message As Commands
                if (message.Contains("!links"))
                {
                    client.SendChatMessage("You can find all Henry's Links Here: https://linktr.ee/HenryFundenberger");
                    continue;
                }

                if (message.Contains("!lurk"))
                {
                    client.SendChatMessage($"{user} has decided to step away into the lurk dimension!");
                    continue;
                }

                if (message.Contains("!unlurk"))
                {
                    client.SendChatMessage($"{user} has returned from the lurk dimension! welcome back <3");
                }
                
                if (message.Contains("!hug"))
                {
                    string personObj;
                    GetInfo = message.Split("!hug");
                    personObj = GetInfo[1];
                    if (personObj == "")
                    {
                        personObj = "themselves";
                    }
                    client.SendChatMessage($"{user} has given {personObj} a big warm hug!! <3");
                }

                if (message.Contains("!livid"))
                {
                    string personObj;
                    GetInfo = message.Split("!livid");
                    personObj = GetInfo[1];
                    if(personObj == "")
                    {
                        personObj = user;
                    }
                    client.SendChatMessage($"{personObj} is livid!!");
                }
                // Specific User Commands

                if (user == "henryfundenberger")
                {
                    if (message.Contains("!shoutout"))
                    {
                        GetInfo = message.Split("!shoutout");
                        message = GetInfo[1].Trim();
                        client.SendChatMessage($"Go check out {message} over at twitch.tv/{message}");
                        continue;
                    }
                    
                }
            }
        }
    }
}
