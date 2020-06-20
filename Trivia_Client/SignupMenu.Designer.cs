namespace Trivia_Client
{
    partial class SignupMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignupMenu));
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.userPanel = new System.Windows.Forms.Panel();
            this.passPanel = new System.Windows.Forms.Panel();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailPanel = new System.Windows.Forms.Panel();
            this.phonePanel = new System.Windows.Forms.Panel();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.addressPanel = new System.Windows.Forms.Panel();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.birthPanel = new System.Windows.Forms.Panel();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.signup_buttom = new System.Windows.Forms.Button();
            this.login__buttom = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.PictureBox();
            this.address = new System.Windows.Forms.PictureBox();
            this.email = new System.Windows.Forms.PictureBox();
            this.password = new System.Windows.Forms.PictureBox();
            this.phone = new System.Windows.Forms.PictureBox();
            this.username = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.address)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.phone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userTextBox
            // 
            this.userTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.userTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userTextBox.Font = new System.Drawing.Font("David", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.userTextBox.ForeColor = System.Drawing.Color.CadetBlue;
            this.userTextBox.HideSelection = false;
            this.userTextBox.Location = new System.Drawing.Point(106, 181);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(303, 27);
            this.userTextBox.TabIndex = 7;
            this.userTextBox.Text = "Username";
            this.userTextBox.Click += new System.EventHandler(this.UsernameBox_Click);
            this.userTextBox.TextChanged += new System.EventHandler(this.userTextBox_TextChanged);
            // 
            // userPanel
            // 
            this.userPanel.BackColor = System.Drawing.Color.Silver;
            this.userPanel.ForeColor = System.Drawing.Color.Silver;
            this.userPanel.Location = new System.Drawing.Point(62, 210);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(370, 1);
            this.userPanel.TabIndex = 8;
            // 
            // passPanel
            // 
            this.passPanel.BackColor = System.Drawing.Color.Silver;
            this.passPanel.Location = new System.Drawing.Point(58, 265);
            this.passPanel.Name = "passPanel";
            this.passPanel.Size = new System.Drawing.Size(370, 1);
            this.passPanel.TabIndex = 9;
            // 
            // passTextBox
            // 
            this.passTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.passTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passTextBox.Font = new System.Drawing.Font("David", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.passTextBox.ForeColor = System.Drawing.Color.CadetBlue;
            this.passTextBox.HideSelection = false;
            this.passTextBox.Location = new System.Drawing.Point(102, 232);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(303, 27);
            this.passTextBox.TabIndex = 10;
            this.passTextBox.Text = "Password";
            this.passTextBox.Click += new System.EventHandler(this.PasswordBox_Click);
            // 
            // emailTextBox
            // 
            this.emailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.emailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailTextBox.Font = new System.Drawing.Font("David", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.emailTextBox.ForeColor = System.Drawing.Color.CadetBlue;
            this.emailTextBox.HideSelection = false;
            this.emailTextBox.Location = new System.Drawing.Point(102, 287);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(303, 27);
            this.emailTextBox.TabIndex = 11;
            this.emailTextBox.Text = "Email";
            this.emailTextBox.Click += new System.EventHandler(this.mail_Click);
            // 
            // emailPanel
            // 
            this.emailPanel.BackColor = System.Drawing.Color.Silver;
            this.emailPanel.Location = new System.Drawing.Point(58, 315);
            this.emailPanel.Name = "emailPanel";
            this.emailPanel.Size = new System.Drawing.Size(370, 1);
            this.emailPanel.TabIndex = 9;
            // 
            // phonePanel
            // 
            this.phonePanel.BackColor = System.Drawing.Color.Silver;
            this.phonePanel.Location = new System.Drawing.Point(58, 364);
            this.phonePanel.Name = "phonePanel";
            this.phonePanel.Size = new System.Drawing.Size(370, 1);
            this.phonePanel.TabIndex = 13;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.phoneTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phoneTextBox.Font = new System.Drawing.Font("David", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.phoneTextBox.ForeColor = System.Drawing.Color.CadetBlue;
            this.phoneTextBox.HideSelection = false;
            this.phoneTextBox.Location = new System.Drawing.Point(102, 336);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(303, 27);
            this.phoneTextBox.TabIndex = 14;
            this.phoneTextBox.Text = "Phone";
            this.phoneTextBox.Click += new System.EventHandler(this.phone_click);
            // 
            // addressPanel
            // 
            this.addressPanel.BackColor = System.Drawing.Color.Silver;
            this.addressPanel.Location = new System.Drawing.Point(58, 415);
            this.addressPanel.Name = "addressPanel";
            this.addressPanel.Size = new System.Drawing.Size(370, 1);
            this.addressPanel.TabIndex = 16;
            // 
            // addressTextBox
            // 
            this.addressTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.addressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addressTextBox.Font = new System.Drawing.Font("David", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.addressTextBox.ForeColor = System.Drawing.Color.CadetBlue;
            this.addressTextBox.HideSelection = false;
            this.addressTextBox.Location = new System.Drawing.Point(102, 387);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(303, 27);
            this.addressTextBox.TabIndex = 17;
            this.addressTextBox.Text = "Address";
            this.addressTextBox.Click += new System.EventHandler(this.address_click);
            // 
            // birthPanel
            // 
            this.birthPanel.BackColor = System.Drawing.Color.Silver;
            this.birthPanel.Location = new System.Drawing.Point(58, 469);
            this.birthPanel.Name = "birthPanel";
            this.birthPanel.Size = new System.Drawing.Size(370, 1);
            this.birthPanel.TabIndex = 19;
            // 
            // dateTextBox
            // 
            this.dateTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.dateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dateTextBox.Font = new System.Drawing.Font("David", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.dateTextBox.ForeColor = System.Drawing.Color.CadetBlue;
            this.dateTextBox.HideSelection = false;
            this.dateTextBox.Location = new System.Drawing.Point(102, 441);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(303, 27);
            this.dateTextBox.TabIndex = 20;
            this.dateTextBox.Text = "Birthday";
            this.dateTextBox.Click += new System.EventHandler(this.date_click);
            // 
            // signup_buttom
            // 
            this.signup_buttom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.signup_buttom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signup_buttom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signup_buttom.Font = new System.Drawing.Font("David", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.signup_buttom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.signup_buttom.Location = new System.Drawing.Point(62, 524);
            this.signup_buttom.Name = "signup_buttom";
            this.signup_buttom.Size = new System.Drawing.Size(369, 50);
            this.signup_buttom.TabIndex = 21;
            this.signup_buttom.Text = "Sign up";
            this.signup_buttom.UseVisualStyleBackColor = false;
            this.signup_buttom.Click += new System.EventHandler(this.SignupButton_Click);
            // 
            // login__buttom
            // 
            this.login__buttom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            this.login__buttom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.login__buttom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.login__buttom.Font = new System.Drawing.Font("David", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.login__buttom.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.login__buttom.Location = new System.Drawing.Point(62, 646);
            this.login__buttom.Name = "login__buttom";
            this.login__buttom.Size = new System.Drawing.Size(370, 50);
            this.login__buttom.TabIndex = 22;
            this.login__buttom.Text = "Log in";
            this.login__buttom.UseVisualStyleBackColor = false;
            // 
            // textBox7
            // 
            this.textBox7.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox7.Font = new System.Drawing.Font("David", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox7.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.textBox7.Location = new System.Drawing.Point(142, 598);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(243, 27);
            this.textBox7.TabIndex = 23;
            this.textBox7.Text = "Already have a user? ";
            // 
            // errorTextBox
            // 
            this.errorTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            this.errorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorTextBox.Font = new System.Drawing.Font("David", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.errorTextBox.ForeColor = System.Drawing.Color.Red;
            this.errorTextBox.Location = new System.Drawing.Point(58, 488);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.Size = new System.Drawing.Size(374, 24);
            this.errorTextBox.TabIndex = 24;
            this.errorTextBox.Text = "Error";
            this.errorTextBox.Visible = false;
            this.errorTextBox.TextChanged += new System.EventHandler(this.errorTextBox_TextChanged);
            // 
            // date
            // 
            this.date.Image = global::Trivia_Client.Properties.Resources.birth;
            this.date.Location = new System.Drawing.Point(58, 428);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(38, 38);
            this.date.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.date.TabIndex = 6;
            this.date.TabStop = false;
            // 
            // address
            // 
            this.address.Image = global::Trivia_Client.Properties.Resources.address;
            this.address.Location = new System.Drawing.Point(58, 376);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(38, 38);
            this.address.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.address.TabIndex = 5;
            this.address.TabStop = false;
            // 
            // email
            // 
            this.email.Image = global::Trivia_Client.Properties.Resources.mail;
            this.email.Location = new System.Drawing.Point(58, 278);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(38, 38);
            this.email.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.email.TabIndex = 4;
            this.email.TabStop = false;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.password.Image = global::Trivia_Client.Properties.Resources.pass1;
            this.password.Location = new System.Drawing.Point(58, 222);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(38, 38);
            this.password.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.password.TabIndex = 3;
            this.password.TabStop = false;
            this.password.Click += new System.EventHandler(this.password_Click);
            // 
            // phone
            // 
            this.phone.Image = global::Trivia_Client.Properties.Resources.phone;
            this.phone.Location = new System.Drawing.Point(58, 327);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(38, 38);
            this.phone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.phone.TabIndex = 2;
            this.phone.TabStop = false;
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.username.Image = global::Trivia_Client.Properties.Resources.username;
            this.username.Location = new System.Drawing.Point(62, 166);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(38, 38);
            this.username.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.username.TabIndex = 1;
            this.username.TabStop = false;
            this.username.Click += new System.EventHandler(this.UsernameBox_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Trivia_Client.Properties.Resources.batsek;
            this.pictureBox1.Location = new System.Drawing.Point(226, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(89, 110);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SignupMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(36)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(544, 711);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.login__buttom);
            this.Controls.Add(this.signup_buttom);
            this.Controls.Add(this.birthPanel);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.addressPanel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.phonePanel);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.emailPanel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.passTextBox);
            this.Controls.Add(this.passPanel);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.date);
            this.Controls.Add(this.address);
            this.Controls.Add(this.email);
            this.Controls.Add(this.password);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.username);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SignupMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignupMenu";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.SignupMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.address)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.phone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox username;
        private System.Windows.Forms.PictureBox phone;
        private System.Windows.Forms.PictureBox password;
        private System.Windows.Forms.PictureBox email;
        private System.Windows.Forms.PictureBox address;
        private System.Windows.Forms.PictureBox date;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Panel passPanel;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Panel emailPanel;
        private System.Windows.Forms.Panel phonePanel;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Panel addressPanel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Panel birthPanel;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.Button signup_buttom;
        private System.Windows.Forms.Button login__buttom;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox errorTextBox;
    }
}

