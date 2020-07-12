namespace Trivia_Client
{
    partial class RoomListMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomListMenu));
            this.RoomList = new System.Windows.Forms.ListBox();
            this.JoinButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.StatsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RoomList
            // 
            this.RoomList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.RoomList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RoomList.Font = new System.Drawing.Font("David", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RoomList.FormattingEnabled = true;
            this.RoomList.ItemHeight = 36;
            this.RoomList.Items.AddRange(new object[] {
            "Room 1",
            "Room 2",
            "Room 3",
            "Room 4",
            "Room 5",
            "Room 6",
            "Room 7",
            "Room 8",
            "Room 9",
            "Room 10",
            "Room 11",
            "Room 12",
            "Room 13",
            "Room 14"});
            this.RoomList.Location = new System.Drawing.Point(419, 91);
            this.RoomList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoomList.Name = "RoomList";
            this.RoomList.Size = new System.Drawing.Size(349, 324);
            this.RoomList.TabIndex = 0;
            this.RoomList.SelectedIndexChanged += new System.EventHandler(this.RoomList_SelectedIndexChanged);
            this.RoomList.DoubleClick += new System.EventHandler(this.RoomList_DoubleClick);
            // 
            // JoinButton
            // 
            this.JoinButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.JoinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinButton.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.JoinButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.JoinButton.Location = new System.Drawing.Point(243, 478);
            this.JoinButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Size = new System.Drawing.Size(228, 71);
            this.JoinButton.TabIndex = 1;
            this.JoinButton.Text = "Join Room";
            this.JoinButton.UseVisualStyleBackColor = false;
            this.JoinButton.Click += new System.EventHandler(this.JoinButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CreateButton.ForeColor = System.Drawing.Color.Black;
            this.CreateButton.Location = new System.Drawing.Point(539, 478);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(228, 71);
            this.CreateButton.TabIndex = 2;
            this.CreateButton.Text = "Create Room";
            this.CreateButton.UseVisualStyleBackColor = false;
            // 
            // LogoutButton
            // 
            this.LogoutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.LogoutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoutButton.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LogoutButton.Location = new System.Drawing.Point(12, 18);
            this.LogoutButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(147, 54);
            this.LogoutButton.TabIndex = 3;
            this.LogoutButton.Text = "Log out";
            this.LogoutButton.UseVisualStyleBackColor = false;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox1.Location = new System.Drawing.Point(419, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 54);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Rooms";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // errorTextBox
            // 
            this.errorTextBox.Location = new System.Drawing.Point(37, 373);
            this.errorTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(132, 22);
            this.errorTextBox.TabIndex = 5;
            this.errorTextBox.TextChanged += new System.EventHandler(this.errorTextBox_TextChanged);
            // 
            // StatsButton
            // 
            this.StatsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.StatsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatsButton.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.StatsButton.Location = new System.Drawing.Point(806, 18);
            this.StatsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StatsButton.Name = "StatsButton";
            this.StatsButton.Size = new System.Drawing.Size(147, 54);
            this.StatsButton.TabIndex = 3;
            this.StatsButton.Text = "Statistics";
            this.StatsButton.UseVisualStyleBackColor = false;
            this.StatsButton.Click += new System.EventHandler(this.StatsButton_Click);
            // 
            // RoomListMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.ClientSize = new System.Drawing.Size(1004, 567);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.StatsButton);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.JoinButton);
            this.Controls.Add(this.RoomList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RoomListMenu";
            this.Text = "Trivia!";
            this.Load += new System.EventHandler(this.RoomListMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RoomList;
        private System.Windows.Forms.Button JoinButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.Button StatsButton;
    }
}