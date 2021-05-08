using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace CSharpPractice
{
    class IRClient
    {
        private string userName;
        private string channel;

        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;

        public IRClient(string ip, int port, string userName, string pasword, string channel)
        {
            this.userName = userName;
            this.channel = channel;

            tcpClient = new TcpClient(ip, port);
            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());

            outputStream.WriteLine($"PASS {pasword}");
            outputStream.WriteLine($"NICK {userName}");
            outputStream.WriteLine($"USER {userName} 8 * :{userName}");
            outputStream.WriteLine($"JOIN #{channel}");
            outputStream.Flush();
        }

        public void SendIRCMessage(string message)
        {
            outputStream.WriteLine(message);
            outputStream.Flush();
        }

        public string ReadMesage()
        {
            return inputStream.ReadLine();
        }

        public void SendChatMessage(string message)
        {
            SendIRCMessage($"PRIVMSG #{channel} : {message}");
        }
    }

    
}
