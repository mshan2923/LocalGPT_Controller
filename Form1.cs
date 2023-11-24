using System.Net;
using System.Net.Http.Json;
using LocalGPTController.dto;
using LocalGPTController.script;
using Newtonsoft.Json;

namespace LocalGPTController
{
    public partial class MainForm : Form
    {
        private Twitch twitch;
        public static MainForm Instance { get; private set; }

        public static float Temperture = 0.2f;
        public static int MaxToken = 200;

        public static string SystemComment = "Change all answers to Korean.";
        public static string FailToCommnet = "[자동 응답 실패]";

        public bool isWorkingToLM = false;
        public MainForm()
        {
            InitializeComponent();
            Instance = this;
            twitch = new Twitch("Bot");

            trackBar_TempOption.Value = (int)(Temperture * 10);
            numericUpDown_TokenOption.Value = MaxToken;
            textBox_SystemOption.Text = SystemComment;
            textBox_FailCommentOption.Text = FailToCommnet;
        }

        #region MainTab
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
                printText = MainForm.Instance.SendTextBox.Text;
            }
            else
            {
                printText = text;
            }

            MainForm.Instance.ChatListBox.Items.Add(printText);

            MainForm.Instance.SendTextBox.Clear();
            MainForm.Instance.ChatListBox.Update();

            MainForm.Instance.ChatListBox.SelectedIndex = MainForm.Instance.ChatListBox.Items.Count - 1;
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
                new LM_Message(Role.system.ToString(), SystemComment),
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

        private void SendTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
        #endregion

        #region OptionTab

        private void trackBar_TempOption_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(((TrackBar)sender).Value.ToString());
            Temperture = ((TrackBar)sender).Value * 0.1f;
        }

        private void numericUpDown_TokenOption_ValueChanged(object sender, EventArgs e)
        {
            MaxToken = ((int)((NumericUpDown)sender).Value);
        }

        private void textBox_SystemOption_TextChanged(object sender, EventArgs e)
        {
            SystemComment = ((TextBox)sender).Text;
        }

        private void textBox_FailCommentOption_TextChanged(object sender, EventArgs e)
        {
            FailToCommnet = ((TextBox)sender).Text;
        }

        #endregion


    }
}