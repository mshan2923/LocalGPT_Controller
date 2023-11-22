namespace LocalGPTController
{
    partial class Form1
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
            splitContainer1 = new SplitContainer();
            ChatListBox = new ListBox();
            SendTextBox = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(ChatListBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(SendTextBox);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.RightToLeft = RightToLeft.No;
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 400;
            splitContainer1.TabIndex = 0;
            // 
            // ChatListBox
            // 
            ChatListBox.BackColor = SystemColors.AppWorkspace;
            ChatListBox.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ChatListBox.FormattingEnabled = true;
            ChatListBox.ItemHeight = 19;
            ChatListBox.Location = new Point(12, 17);
            ChatListBox.Name = "ChatListBox";
            ChatListBox.Size = new Size(776, 365);
            ChatListBox.TabIndex = 0;
            ChatListBox.SelectedIndexChanged += ChatListBox_SelectedIndexChanged;
            // 
            // SendTextBox
            // 
            SendTextBox.Font = new Font("나눔고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SendTextBox.Location = new Point(12, 13);
            SendTextBox.Name = "SendTextBox";
            SendTextBox.Size = new Size(686, 26);
            SendTextBox.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(704, 3);
            button1.Name = "button1";
            button1.Size = new Size(93, 40);
            button1.TabIndex = 0;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox SendTextBox;
        private Button button1;
        private ListBox ChatListBox;
    }
}