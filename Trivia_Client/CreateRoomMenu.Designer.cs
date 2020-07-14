namespace Trivia_Client
{
    partial class CreateRoomMenu
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.usersTextBox = new System.Windows.Forms.TextBox();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.leaveRoomButton = new System.Windows.Forms.Button();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(521, 70);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(139, 20);
            this.nameTextBox.TabIndex = 9;
            this.nameTextBox.Text = "room name";
            // 
            // usersTextBox
            // 
            this.usersTextBox.Location = new System.Drawing.Point(317, 70);
            this.usersTextBox.Name = "usersTextBox";
            this.usersTextBox.Size = new System.Drawing.Size(139, 20);
            this.usersTextBox.TabIndex = 8;
            this.usersTextBox.Text = "amout of players";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(141, 70);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(139, 20);
            this.timeTextBox.TabIndex = 7;
            this.timeTextBox.Text = "time";
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(418, 282);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(150, 99);
            this.createButton.TabIndex = 6;
            this.createButton.Text = "create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // leaveRoomButton
            // 
            this.leaveRoomButton.Location = new System.Drawing.Point(194, 281);
            this.leaveRoomButton.Name = "leaveRoomButton";
            this.leaveRoomButton.Size = new System.Drawing.Size(123, 100);
            this.leaveRoomButton.TabIndex = 5;
            this.leaveRoomButton.Text = "Back to roomlist";
            this.leaveRoomButton.UseVisualStyleBackColor = true;
            this.leaveRoomButton.Click += new System.EventHandler(this.leaveRoomButton_Click);
            // 
            // errorTextBox
            // 
            this.errorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorTextBox.Location = new System.Drawing.Point(356, 182);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(100, 13);
            this.errorTextBox.TabIndex = 10;
            this.errorTextBox.Visible = false;
            // 
            // CreateRoomMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.usersTextBox);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.leaveRoomButton);
            this.Name = "CreateRoomMenu";
            this.Text = "CreateRoomMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox usersTextBox;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button leaveRoomButton;
        private System.Windows.Forms.TextBox errorTextBox;
    }
}