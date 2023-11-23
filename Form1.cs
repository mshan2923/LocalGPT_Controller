using System.Net;
using System.Net.Http.Json;
using LocalGPTController.dto;
using LocalGPTController.script;
using Newtonsoft.Json;

namespace LocalGPTController
{
    public partial class Form1 : Form
    {
        private Twitch twitch;
        public static Form1 Instance { get; private set; }

        public static float Temperture = 0.2f;
        public static int MaxToken = 100;

        public static string FailToCommnet = "[자동 응답 실패]";

        public bool isWorkingToLM = false;
        public Form1()
        {
            InitializeComponent();
            Instance = this;
            twitch = new Twitch("Bot");
        }

        public void onAddContent(string text = null)
        {
            string printText;

            if (text == null)
            {
                printText = SendTextBox.Text;
            }
            else
            {
                printText = text;
            }

            /*
            var addedLabel = new Label();
            addedLabel.Width = ChatListBox.Width;
            addedLabel.Text = printText;
            */

            ChatListBox.Items.Add(printText);

            SendTextBox.Clear();
            ChatListBox.Update();

            ChatListBox.SelectedIndex = ChatListBox.Items.Count - 1;
        }
        public static void OnAddContent(string text = null)
        {
            string printText;

            if (text == null)
            {
                printText = Form1.Instance.SendTextBox.Text;
            }
            else
            {
                printText = text;
            }

            Form1.Instance.ChatListBox.Items.Add(printText);

            Form1.Instance.SendTextBox.Clear();
            Form1.Instance.ChatListBox.Update();

            Form1.Instance.ChatListBox.SelectedIndex = Form1.Instance.ChatListBox.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isWorkingToLM == false)
            {
                onSend(SendTextBox.Text);
            }
        }

        private void ChatListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public async void onSend(string message)
        {
            //twitch.SendMessage(SendTextBox.Text);

            {
                SendButton.Text = "Wait";
                SendButton.Enabled = false;
                isWorkingToLM = true;
            }

            string url = "http://localhost:1234/v1/chat/completions";

            if (String.IsNullOrEmpty(message))
            {
                OnRecievedLLM();
                return;
            }

            List<LM_Message> messages = new List<LM_Message>()
            {
                new LM_Message(Role.system.ToString(), "Change all answers to Korean."),
                new LM_Message(Role.user.ToString(), message)
            };

            var seri = JsonConvert.SerializeObject(new LM_RequestDto(messages, Temperture, MaxToken));
            //var seri = JsonConvert.SerializeObject(new LM_RequestDto(SendTextBox.Text));
            //      JsonSerializer.Serialize(new LM_RequestDto(SendTextBox.Text));


            try
            {
                using var request = new HttpClient();
                var content = new StringContent(seri);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var teskRequest = await request.PostAsync(url, content);
                var teskConvert = await teskRequest.Content.ReadAsStringAsync();

                //teskConvert.Wait();

                //==== 기다리는중에 전송 버튼 클릭이벤트 차단 추가

                var deseri_result = JsonConvert.DeserializeObject<LM_ResponseDto>(teskConvert);

                if (deseri_result == null)
                {

                }
                else
                {
                    string result = (string.IsNullOrWhiteSpace(deseri_result.choices[^1].message.content)) ?
                        FailToCommnet :
                        deseri_result.choices[^1].message.content;

                    onAddContent(result);
                    twitch.SendMessage(result);
                }


            }
            catch (HttpRequestException e)
            {
                onAddContent("실패 : 대부분 LM Studio 구동 확인 / " + e.Message);
                //twitch.SendMessage("[AI 구동 하지 않음]");
            }
            catch (Exception ex)
            {
                onAddContent("실패 : " + ex.Message);//user , system 으로 string 값으로 저장
                                                   //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
            finally
            {
                OnRecievedLLM();
            }
        }

        private async void OnRecievedLLM()
        {
            SendButton.Text = "Send";
            SendButton.Enabled = true;
            isWorkingToLM = false;
            //await twitch.ReadFromStreamAsync();
        }
    }
}