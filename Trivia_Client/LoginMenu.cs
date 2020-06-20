﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trivia_Client
{
    public partial class LoginMenu : Form
    {
        public LoginMenu()
        {
            InitializeComponent();
        }

        private void ResetPassword()
        {
            PasswordPic.Image = Properties.Resources.PasswordIcon1;
            PassPanel.BackColor = Color.Silver;
            PasswordBox.ForeColor = Color.CadetBlue;
            if (String.IsNullOrEmpty(PasswordBox.Text))
            {
                PasswordBox.Text = "Password";
                PasswordBox.PasswordChar = '\0';
            }
        }
        private void ResetUsername()
        {
            UsernamePic.Image = Properties.Resources.UsernameIcon1;
            UserPanel.BackColor = Color.Silver;
            UsernameBox.ForeColor = Color.CadetBlue;
            if (String.IsNullOrEmpty(UsernameBox.Text))
                UsernameBox.Text = "Username";
        }

        private void LoginMenu_Click(object sender, EventArgs e)
        {
            ResetPassword();
            ResetUsername();  
        }

        private void Batzek_MouseHover(object sender, EventArgs e)
        {
            Crown.Visible = true;
            Crown.Image = Properties.Resources.IdoMeleh;
        }

        private void Batzek_MouseLeave(object sender, EventArgs e)
        {
            Crown.Visible = false;
        }

        private void UsernameBox_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(UsernameBox.Text) && UsernameBox.Text.Equals("Username"))
                UsernameBox.Clear();
            UsernameBox.ForeColor = Color.FromArgb(25, 139, 177);
            UsernamePic.Image = Properties.Resources.UsernameIcon2;
            UserPanel.BackColor = Color.FromArgb(25, 139, 177);

            ResetPassword();
        }

        private void PasswordBox_Click(object sender, EventArgs e)
        {   
            if (!String.IsNullOrEmpty(PasswordBox.Text))
            {
                PasswordBox.PasswordChar = '•';
                if(PasswordBox.Text.Equals("Password"))
                    PasswordBox.Clear();
            }
            else
                PasswordBox.PasswordChar = '\0';
            PasswordBox.ForeColor = Color.FromArgb(25, 139, 177);
            PasswordPic.Image = Properties.Resources.PasswordIcon2;
            PassPanel.BackColor = Color.FromArgb(25, 139, 177);

            ResetUsername();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {

        }

        private void SignupButton_Click(object sender, EventArgs e)
        {

        }
    }
}