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

        public Form1()
        {
            InitializeComponent();
            twitch = new Twitch("Bot");
            Instance = this;
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
        private void button1_Click(object sender, EventArgs e)
        {
            //onAddContent();
            onSend();
        }

        private void ChatListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void onSend()
        {
            //twitch.SendMessage(SendTextBox.Text);

            string url = "http://localhost:1234/v1/chat/completions";


            List<LM_Message> messages = new List<LM_Message>()
            {
                new LM_Message(Role.system.ToString(), "Change all answers to Korean."),
                new LM_Message(Role.user.ToString(), SendTextBox.Text)
            };

            var seri = JsonConvert.SerializeObject(new LM_RequestDto(messages, max_token: 100));
            //var seri = JsonConvert.SerializeObject(new LM_RequestDto(SendTextBox.Text));
            //      JsonSerializer.Serialize(new LM_RequestDto(SendTextBox.Text));


            try
            {
                using var request = new HttpClient();
                var content = new StringContent(seri);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var teskRequest = await request.PostAsync(url, content);
                //await request.PostAsJsonAsync(url, new LM_RequestDto(messages, max_token: 100));
                var teskConvert = teskRequest.Content.ReadAsStringAsync();
                teskConvert.Wait();

                //==== 기다리는중에 전송 버튼 클릭이벤트 차단 추가

                var deseri_result = JsonConvert.DeserializeObject<LM_ResponseDto>(teskConvert.Result);

                if (deseri_result == null)
                {

                }
                else
                {

                    if (string.IsNullOrWhiteSpace(deseri_result.choices[^1].message.content))
                    {
                        onAddContent("응답하기 싫습니다.");
                    }
                    else
                    {
                        onAddContent(deseri_result.choices[^1].message.content);
                    }
                }


                //=아니 대체 실행이 안되지? - 인식을 못할때 엔터만 값으로 보냄
            }
            catch (Exception ex)
            {
                onAddContent("실패 : " + ex.Message);//user , system 으로 string 값으로 저장
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}