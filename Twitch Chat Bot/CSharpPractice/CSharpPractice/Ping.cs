using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CSharpPractice
{
    class Ping
    {
        private IRClient client;
        private Thread sender;

        public Ping(IRClient client)
        {
            this.client = client;
            sender = new Thread(new ThreadStart(Run));
        }

        public void Start()
        {
            sender.IsBackground = true;
            sender.Start();
        }

        private void Run()
        {
            while (true)
            {
                Console.WriteLine("Sending PING");
                client.SendIRCMessage("PING irc.twitch.tv");
                Thread.Sleep(TimeSpan.FromMinutes(5));
                Console.Write("Sent PING");
            }
        }
    }
}
