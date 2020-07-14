namespace Trivia_Client
{
    partial class RoomMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomMenu));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.PlayerList = new System.Windows.Forms.ListBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.LeaveButton = new System.Windows.Forms.Button();
            this.admin_box = new System.Windows.Forms.TextBox();
            this.answerTimeout = new System.Windows.Forms.TextBox();
            this.questionCount = new System.Windows.Forms.TextBox();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox1.Location = new System.Drawing.Point(312, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 43);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Players";
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CloseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CloseButton.Location = new System.Drawing.Point(404, 392);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(171, 58);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Close Room";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // PlayerList
            // 
            this.PlayerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.PlayerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayerList.Font = new System.Drawing.Font("David", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PlayerList.FormattingEnabled = true;
            this.PlayerList.ItemHeight = 29;
            this.PlayerList.Location = new System.Drawing.Point(312, 82);
            this.PlayerList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.Size = new System.Drawing.Size(262, 261);
            this.PlayerList.TabIndex = 5;
            this.PlayerList.SelectedIndexChanged += new System.EventHandler(this.PlayerList_SelectedIndexChanged);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.StartButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StartButton.Location = new System.Drawing.Point(189, 392);
            this.StartButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(171, 58);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Start Game";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // LeaveButton
            // 
            this.LeaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.LeaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeaveButton.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LeaveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LeaveButton.Location = new System.Drawing.Point(295, 392);
            this.LeaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.Size = new System.Drawing.Size(171, 58);
            this.LeaveButton.TabIndex = 6;
            this.LeaveButton.Text = "Leave Game";
            this.LeaveButton.UseVisualStyleBackColor = false;
            this.LeaveButton.Visible = false;
            this.LeaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
            // 
            // admin_box
            // 
            this.admin_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.admin_box.Location = new System.Drawing.Point(37, 153);
            this.admin_box.Name = "admin_box";
            this.admin_box.Size = new System.Drawing.Size(100, 13);
            this.admin_box.TabIndex = 11;
            this.admin_box.Text = "Admin";
            this.admin_box.Visible = false;
            this.admin_box.TextChanged += new System.EventHandler(this.admin_box_TextChanged);
            // 
            // answerTimeout
            // 
            this.answerTimeout.Location = new System.Drawing.Point(613, 70);
            this.answerTimeout.Name = "answerTimeout";
            this.answerTimeout.Size = new System.Drawing.Size(100, 20);
            this.answerTimeout.TabIndex = 12;
            // 
            // questionCount
            // 
            this.questionCount.Location = new System.Drawing.Point(613, 117);
            this.questionCount.Name = "questionCount";
            this.questionCount.Size = new System.Drawing.Size(100, 20);
            this.questionCount.TabIndex = 13;
            // 
            // errorTextBox
            // 
            this.errorTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.errorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorTextBox.Font = new System.Drawing.Font("David", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.errorTextBox.ForeColor = System.Drawing.Color.Red;
            this.errorTextBox.Location = new System.Drawing.Point(254, 358);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.Size = new System.Drawing.Size(248, 22);
            this.errorTextBox.TabIndex = 14;
            // 
            // RoomMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.ClientSize = new System.Drawing.Size(753, 461);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.questionCount);
            this.Controls.Add(this.answerTimeout);
            this.Controls.Add(this.admin_box);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LeaveButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PlayerList);
            this.ForeColor = System.Drawing.Color.Coral;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RoomMenu";
            this.Text = "Trivia!";
            this.Load += new System.EventHandler(this.RoomMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ListBox PlayerList;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button LeaveButton;
        private System.Windows.Forms.TextBox admin_box;
        private System.Windows.Forms.TextBox answerTimeout;
        private System.Windows.Forms.TextBox questionCount;
        private System.Windows.Forms.TextBox errorTextBox;
    }
}