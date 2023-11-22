using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LocalGPTController.script
{
    public class Twitch
    {
        //참고 : https://steemit.com/kr-dev/@maanya/20
        //공식 문서 : https://dev.twitch.tv/docs/irc/

        private string Outh 
        { 
            get { return Key.Outh; }// "oauth:~~"
        }
        //  발급 링크 : https://twitchapps.com/tmi/

        private string ClientId
        {
            get { return Key.ClientId; }
        }
        //  앱 등록 링크 : https://dev.twitch.tv/console


        private string username, password, channelName;
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;

        private System.Threading.Timer timer;

        public Twitch(string username)
        {
            setup("irc.chat.twitch.tv", 6667, username, Outh, "dwap_");
        }
        public Twitch(string ip, int port, string username, string password, string channelName)
        {
            setup(ip, port, username, password, channelName);
        }

        private void setup(string ip, int port, string username, string password, string channelName)
        {
            this.username = username;
            this.password = password;
            this.channelName = channelName;

            tcpClient = new TcpClient(ip, port);
            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());

            outputStream.WriteLine("PASS " + password);
            outputStream.WriteLine("NICK " + username);
            outputStream.WriteLine("JOIN #" + channelName);
            outputStream.Flush();

            timer = new System.Threading.Timer(ReadChat, null, 0, 100);
            //ReadChat();
        }

        // 0.1초 정도? 주기적 업데이트하다가 메세지 오면 델리게이트로 이벤트 주기
        public void ReadChat(object? sender)
        {
            try
            {
                //ChatListBox.Items.Add(printText);
                string message = inputStream.ReadLine();
                if (message != null)
                    if (message.Contains("PRIVMSG"))
                    {
                        int intIndexParseSign = message.IndexOf('!');
                        string userName = message.Substring(1, intIndexParseSign - 1);

                        // Get the user's message
                        intIndexParseSign = message.IndexOf(" :");
                        message = message.Substring(intIndexParseSign + 2);


                        Form1.Instance.onAddContent("(Twitch)" + userName + " : " + message);
                    }

            }
            catch (Exception e)
            {
                Form1.Instance.onAddContent("Error : " + e.Message);
            }
        }
        
        public void SendMessage(string message)
        {
            //string temp = inputStream.ReadLine();
            //MessageBox.Show(temp, message);

            outputStream.WriteLine("PRIVMSG #" + channelName + " :" + message);
            outputStream.Flush();
        }
    }
}
