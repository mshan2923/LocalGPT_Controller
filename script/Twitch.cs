using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        public static Twitch Instance { get; private set; }

        private string username, password, channelName;
        private TcpClient tcpClient;
        private StreamReader inputStream;
        private StreamWriter outputStream;

        private System.Threading.Timer timer;

        private bool isPrintError = false;
        public bool isWaitForChat = true;

        public Twitch(string username)
        {
            setup("irc.chat.twitch.tv", 6667, username, Outh, "dwap_");
        }
        public Twitch(string ip, int port, string username, string password, string channelName)
        {
            setup(ip, port, username, password, channelName);
        }

        private async void setup(string ip, int port, string username, string password, string channelName)
        {
            Instance = this;

            this.username = username;
            this.password = password;
            this.channelName = channelName;

            tcpClient = new TcpClient(ip, port);
            inputStream = new StreamReader(tcpClient.GetStream(), leaveOpen: true);
            outputStream = new StreamWriter(tcpClient.GetStream(), leaveOpen: true);
            //outputStream.AutoFlush = true;

            outputStream.WriteLine("PASS " + password);
            outputStream.WriteLine("NICK " + username);
            outputStream.WriteLine("JOIN #" + channelName);
            outputStream.Flush();

            //timer = new System.Threading.Timer(ReadChat, null, 0, 100);
            Form1.Instance.RecieveChatTimer.Tick += RecieveChatTimer_Tick;
            Form1.Instance.RecieveChatTimer.Enabled = true;

            //await ReadFromStreamAsync();
        }

        private void RecieveChatTimer_Tick(object? sender, EventArgs e)
        {
            ReadChat(sender);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns> 0 : username / 1 : message</returns>
        private string[] GetMessageFromTwitchResponse(string message)
        {
            string[] result = new string[] { string.Empty, string.Empty};

            if (String.IsNullOrWhiteSpace(message) == false)
                if (message.Contains("PRIVMSG"))
                {
                    int intIndexParseSign = message.IndexOf('!');
                    string userName = message.Substring(1, intIndexParseSign - 1);
                    result[0] = userName;

                    // Get the user's message
                    intIndexParseSign = message.IndexOf(" :");
                    message = message.Substring(intIndexParseSign + 2);


                    if (message.Length > 0)
                    {
                        if (message.ToCharArray()[0].Equals('!'))
                        {
                            result[1] = message.Substring(1);
                        }
                    }
                    //================= 메세지 맨앞에 "!" 가 있으면 LLM 실행
                }
            return result; 
        }

        // 0.1초 정도? 주기적 업데이트하다가 메세지 오면 델리게이트로 이벤트 주기
        public async void ReadChat(object? sender)
        {
            isWaitForChat = false;
            try
            {
                if (Form1.Instance.isWorkingToLM == false)
                {
                    inputStream = new StreamReader(tcpClient.GetStream(), leaveOpen: true);
                    string message = await inputStream.ReadLineAsync();

                    {
                        string[] sendMessage = GetMessageFromTwitchResponse(message);

                        if (string.IsNullOrEmpty(sendMessage[1]) == false)
                        {
                            Form1.Instance.onAddContent("  [Processing]");

                            Form1.Instance.onSend(sendMessage[1]);
                        }
                    }
                    isPrintError = false;
                }
            }
            catch (ObjectDisposedException e)
            {
                if (isPrintError == false)
                {
                    Form1.OnAddContent("Error : " + e.Message + " / Stream Error");
                    isPrintError = true;
                    MessageBox.Show((e.GetType().FullName + " : " + e.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                Form1.OnAddContent("Error : " + e.Message + (tcpClient.Connected ? "(연결됨)" : "(연결끊킴)"));
            }
            finally
            {
                inputStream.Close();
                isWaitForChat = true;
            }
        }
        
        public void SendMessage(string message)
        {
            /*
            using (StreamWriter sw = new StreamWriter(tcpClient.GetStream()))
            {
                sw.WriteLine("PRIVMSG #" + channelName + " :" + message);
            }*///======== 안되는데 Using

            try
            {
                outputStream.WriteLine("PRIVMSG #" + channelName + " :" + message);
                outputStream.Flush();
            }catch (Exception e)
            {
                Form1.Instance.onAddContent(e.Message);
            }
        }
    }
}
