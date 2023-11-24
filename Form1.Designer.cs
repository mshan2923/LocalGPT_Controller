namespace LocalGPTController
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            TabControll = new TabControl();
            MainTab = new TabPage();
            ChatListBox = new ListBox();
            OptionTab = new TabPage();
            textBox_FailCommentOption = new TextBox();
            label4 = new Label();
            textBox_SystemOption = new TextBox();
            label3 = new Label();
            numericUpDown_TokenOption = new NumericUpDown();
            label2 = new Label();
            trackBar_TempOption = new TrackBar();
            label1 = new Label();
            SendTextBox = new TextBox();
            SendButton = new Button();
            RecieveChatTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            TabControll.SuspendLayout();
            MainTab.SuspendLayout();
            OptionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_TokenOption).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_TempOption).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(TabControll);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(SendTextBox);
            splitContainer1.Panel2.Controls.Add(SendButton);
            splitContainer1.Panel2.RightToLeft = RightToLeft.No;
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 400;
            splitContainer1.TabIndex = 0;
            // 
            // TabControll
            // 
            TabControll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabControll.Controls.Add(MainTab);
            TabControll.Controls.Add(OptionTab);
            TabControll.Location = new Point(3, 3);
            TabControll.Name = "TabControll";
            TabControll.SelectedIndex = 0;
            TabControll.Size = new Size(794, 394);
            TabControll.TabIndex = 1;
            // 
            // MainTab
            // 
            MainTab.Controls.Add(ChatListBox);
            MainTab.Location = new Point(4, 24);
            MainTab.Name = "MainTab";
            MainTab.Size = new Size(786, 366);
            MainTab.TabIndex = 0;
            MainTab.Text = "Main";
            MainTab.UseVisualStyleBackColor = true;
            // 
            // ChatListBox
            // 
            ChatListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ChatListBox.BackColor = SystemColors.AppWorkspace;
            ChatListBox.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ChatListBox.FormattingEnabled = true;
            ChatListBox.ItemHeight = 19;
            ChatListBox.Location = new Point(0, 0);
            ChatListBox.Margin = new Padding(0);
            ChatListBox.Name = "ChatListBox";
            ChatListBox.Size = new Size(786, 365);
            ChatListBox.TabIndex = 0;
            ChatListBox.SelectedIndexChanged += ChatListBox_SelectedIndexChanged;
            // 
            // OptionTab
            // 
            OptionTab.BackColor = SystemColors.AppWorkspace;
            OptionTab.Controls.Add(textBox_FailCommentOption);
            OptionTab.Controls.Add(label4);
            OptionTab.Controls.Add(textBox_SystemOption);
            OptionTab.Controls.Add(label3);
            OptionTab.Controls.Add(numericUpDown_TokenOption);
            OptionTab.Controls.Add(label2);
            OptionTab.Controls.Add(trackBar_TempOption);
            OptionTab.Controls.Add(label1);
            OptionTab.Location = new Point(4, 24);
            OptionTab.Name = "OptionTab";
            OptionTab.Padding = new Padding(3);
            OptionTab.Size = new Size(786, 366);
            OptionTab.TabIndex = 1;
            OptionTab.Text = "Option";
            // 
            // textBox_FailCommentOption
            // 
            textBox_FailCommentOption.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_FailCommentOption.Location = new Point(150, 135);
            textBox_FailCommentOption.Name = "textBox_FailCommentOption";
            textBox_FailCommentOption.Size = new Size(621, 26);
            textBox_FailCommentOption.TabIndex = 7;
            textBox_FailCommentOption.TextChanged += textBox_FailCommentOption_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 138);
            label4.Name = "label4";
            label4.Size = new Size(129, 19);
            label4.TabIndex = 6;
            label4.Text = "FailToCommnet";
            // 
            // textBox_SystemOption
            // 
            textBox_SystemOption.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_SystemOption.Location = new Point(150, 103);
            textBox_SystemOption.Name = "textBox_SystemOption";
            textBox_SystemOption.Size = new Size(621, 26);
            textBox_SystemOption.TabIndex = 5;
            textBox_SystemOption.TextChanged += textBox_SystemOption_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 106);
            label3.Name = "label3";
            label3.Size = new Size(138, 19);
            label3.TabIndex = 4;
            label3.Text = "SystemComment";
            // 
            // numericUpDown_TokenOption
            // 
            numericUpDown_TokenOption.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown_TokenOption.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDown_TokenOption.Location = new Point(150, 71);
            numericUpDown_TokenOption.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown_TokenOption.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown_TokenOption.Name = "numericUpDown_TokenOption";
            numericUpDown_TokenOption.Size = new Size(120, 26);
            numericUpDown_TokenOption.TabIndex = 3;
            numericUpDown_TokenOption.Value = new decimal(new int[] { 200, 0, 0, 0 });
            numericUpDown_TokenOption.ValueChanged += numericUpDown_TokenOption_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 73);
            label2.Name = "label2";
            label2.Size = new Size(88, 19);
            label2.TabIndex = 2;
            label2.Text = "MaxToken";
            // 
            // trackBar_TempOption
            // 
            trackBar_TempOption.Location = new Point(150, 20);
            trackBar_TempOption.Name = "trackBar_TempOption";
            trackBar_TempOption.Size = new Size(300, 45);
            trackBar_TempOption.TabIndex = 1;
            trackBar_TempOption.Value = 2;
            trackBar_TempOption.ValueChanged += trackBar_TempOption_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 20);
            label1.Name = "label1";
            label1.Size = new Size(98, 19);
            label1.TabIndex = 0;
            label1.Text = "Temperture";
            // 
            // SendTextBox
            // 
            SendTextBox.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SendTextBox.Location = new Point(12, 13);
            SendTextBox.Name = "SendTextBox";
            SendTextBox.Size = new Size(686, 26);
            SendTextBox.TabIndex = 1;
            SendTextBox.KeyDown += SendTextBox_KeyDown;
            // 
            // SendButton
            // 
            SendButton.Location = new Point(704, 3);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(93, 40);
            SendButton.TabIndex = 0;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GrayText;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            TabControll.ResumeLayout(false);
            MainTab.ResumeLayout(false);
            OptionTab.ResumeLayout(false);
            OptionTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_TokenOption).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_TempOption).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        public Button SendButton;
        public TextBox SendTextBox;
        public System.Windows.Forms.Timer RecieveChatTimer;
        private TabControl TabControll;
        private TabPage MainTab;
        public ListBox ChatListBox;
        private TabPage OptionTab;
        private Label label1;
        private TrackBar trackBar_TempOption;
        private Label label2;
        private Label label3;
        private TextBox textBox_SystemOption;
        private TextBox textBox_FailCommentOption;
        private Label label4;
        private NumericUpDown numericUpDown_TokenOption;
    }
}