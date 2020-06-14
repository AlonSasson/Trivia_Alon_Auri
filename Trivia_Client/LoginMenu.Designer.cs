namespace Trivia_Client
{
    partial class LoginMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginMenu));
            this.UserPanel = new System.Windows.Forms.Panel();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.PassPanel = new System.Windows.Forms.Panel();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SignupButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PasswordPic = new System.Windows.Forms.PictureBox();
            this.UsernamePic = new System.Windows.Forms.PictureBox();
            this.Batzek = new System.Windows.Forms.PictureBox();
            this.Crown = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernamePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Batzek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Crown)).BeginInit();
            this.SuspendLayout();
            // 
            // UserPanel
            // 
            this.UserPanel.BackColor = System.Drawing.Color.Silver;
            this.UserPanel.Location = new System.Drawing.Point(59, 301);
            this.UserPanel.Name = "UserPanel";
            this.UserPanel.Size = new System.Drawing.Size(410, 2);
            this.UserPanel.TabIndex = 1;
            // 
            // UsernameBox
            // 
            this.UsernameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.UsernameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsernameBox.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameBox.ForeColor = System.Drawing.Color.CadetBlue;
            this.UsernameBox.Location = new System.Drawing.Point(103, 262);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(366, 33);
            this.UsernameBox.TabIndex = 0;
            this.UsernameBox.Text = "Username";
            this.UsernameBox.Click += new System.EventHandler(this.UsernameBox_Click);
            // 
            // PassPanel
            // 
            this.PassPanel.BackColor = System.Drawing.Color.Silver;
            this.PassPanel.Location = new System.Drawing.Point(59, 394);
            this.PassPanel.Name = "PassPanel";
            this.PassPanel.Size = new System.Drawing.Size(410, 2);
            this.PassPanel.TabIndex = 1;
            // 
            // PasswordBox
            // 
            this.PasswordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.PasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordBox.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordBox.ForeColor = System.Drawing.Color.CadetBlue;
            this.PasswordBox.Location = new System.Drawing.Point(103, 360);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(366, 33);
            this.PasswordBox.TabIndex = 0;
            this.PasswordBox.Text = "Password";
            this.PasswordBox.Click += new System.EventHandler(this.PasswordBox_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LoginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.LoginButton.Location = new System.Drawing.Point(59, 462);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(410, 69);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Log in";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // SignupButton
            // 
            this.SignupButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SignupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignupButton.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SignupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.SignupButton.Location = new System.Drawing.Point(59, 610);
            this.SignupButton.Name = "SignupButton";
            this.SignupButton.Size = new System.Drawing.Size(410, 69);
            this.SignupButton.TabIndex = 4;
            this.SignupButton.Text = "Sign up";
            this.SignupButton.UseVisualStyleBackColor = false;
            this.SignupButton.Click += new System.EventHandler(this.SignupButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.textBox1.Location = new System.Drawing.Point(103, 571);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(366, 33);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Dont have an account?";
            this.textBox1.Click += new System.EventHandler(this.PasswordBox_Click);
            this.textBox1.SelectionStart = 0;
            // 
            // PasswordPic
            // 
            this.PasswordPic.Image = ((System.Drawing.Image)(resources.GetObject("PasswordPic.Image")));
            this.PasswordPic.Location = new System.Drawing.Point(59, 350);
            this.PasswordPic.Name = "PasswordPic";
            this.PasswordPic.Size = new System.Drawing.Size(38, 38);
            this.PasswordPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PasswordPic.TabIndex = 3;
            this.PasswordPic.TabStop = false;
            // 
            // UsernamePic
            // 
            this.UsernamePic.Image = global::Trivia_Client.Properties.Resources.UsernameIcon1;
            this.UsernamePic.Location = new System.Drawing.Point(59, 257);
            this.UsernamePic.Name = "UsernamePic";
            this.UsernamePic.Size = new System.Drawing.Size(38, 38);
            this.UsernamePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UsernamePic.TabIndex = 3;
            this.UsernamePic.TabStop = false;
            // 
            // Batzek
            // 
            this.Batzek.Image = global::Trivia_Client.Properties.Resources.batsek;
            this.Batzek.Location = new System.Drawing.Point(218, 43);
            this.Batzek.Name = "Batzek";
            this.Batzek.Size = new System.Drawing.Size(90, 124);
            this.Batzek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Batzek.TabIndex = 2;
            this.Batzek.TabStop = false;
            this.Batzek.MouseLeave += new System.EventHandler(this.Batzek_MouseLeave);
            this.Batzek.MouseHover += new System.EventHandler(this.Batzek_MouseHover);
            // 
            // Crown
            // 
            this.Crown.Location = new System.Drawing.Point(218, 0);
            this.Crown.Name = "Crown";
            this.Crown.Size = new System.Drawing.Size(66, 43);
            this.Crown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Crown.TabIndex = 5;
            this.Crown.TabStop = false;
            // 
            // LoginMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(542, 703);
            this.Controls.Add(this.SignupButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordPic);
            this.Controls.Add(this.UsernamePic);
            this.Controls.Add(this.Batzek);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.PassPanel);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.UserPanel);
            this.Controls.Add(this.Crown);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginMenu";
            this.Click += new System.EventHandler(this.LoginMenu_Click);
            ((System.ComponentModel.ISupportInitialize)(this.PasswordPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernamePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Batzek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Crown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel UserPanel;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.PictureBox Batzek;
        private System.Windows.Forms.Panel PassPanel;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.PictureBox PasswordPic;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.PictureBox UsernamePic;
        private System.Windows.Forms.Button SignupButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox Crown;
    }
}

