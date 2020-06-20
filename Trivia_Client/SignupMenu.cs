using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Trivia_Client
{
  
    public partial class SignupMenu : Form
    {
        public SignupMenu()
        {
            InitializeComponent();
        }

        public bool Regexp(string re , TextBox tb)
        {
            Regex regex = new Regex(re);
            if(regex.IsMatch(tb.Text))
            {
                return true;
            }
            return false;
        }

        
        private void ResetPassword()
        {
            password.Image = Properties.Resources.pass;
            passPanel.BackColor = Color.Silver;
            passTextBox.ForeColor = Color.CadetBlue;
            if (String.IsNullOrEmpty(passTextBox.Text))
            {
                passTextBox.Text = "Password";
                passTextBox.PasswordChar = '\0';
            }
        }
        private void ResetUsername()
        {
            username.Image = Properties.Resources.username;
            userPanel.BackColor = Color.Silver;
            userTextBox.ForeColor = Color.CadetBlue;
            if (String.IsNullOrEmpty(userTextBox.Text))
                userTextBox.Text = "Username";
        }
        private void resetEmail()
        {
            email.Image = Properties.Resources.mail;
            emailPanel.BackColor = Color.Silver;
            emailTextBox.ForeColor = Color.CadetBlue;
            if (string.IsNullOrEmpty(emailTextBox.Text))
                emailTextBox.Text = "Email";
        }
        private void resetPhone()
        {
            phone.Image = Properties.Resources.phone;
            phonePanel.BackColor = Color.Silver;
            phoneTextBox.ForeColor = Color.CadetBlue;
            if(string.IsNullOrEmpty(phoneTextBox.Text))
            {
                phoneTextBox.Text = "Phone";
            }
        }
        private void resetAddress()
        {
            address.Image = Properties.Resources.address;
            addressPanel.BackColor = Color.Silver;
            addressTextBox.ForeColor = Color.CadetBlue;
            if (string.IsNullOrEmpty(addressTextBox.Text))
            {
                addressTextBox.Text = "Address";
            }
        }
        private void resetDate()
        {
            date.Image = Properties.Resources.birth;
            birthPanel.BackColor = Color.Silver;
            dateTextBox.ForeColor = Color.CadetBlue;
            if (string.IsNullOrEmpty(dateTextBox.Text))
            {
                dateTextBox.Text = "Birthday";
            }
        }
        private void LoginMenu_Click(object sender, EventArgs e)
        {
            ResetPassword();
            ResetUsername();
        }

        private void Batzek_MouseHover(object sender, EventArgs e)
        {
        //    Crown.Visible = true;
         //   Crown.Image = Properties.Resources.IdoMeleh;
        }

        private void Batzek_MouseLeave(object sender, EventArgs e)
        {
           // Crown.Visible = false;
        }

        private void UsernameBox_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(userTextBox.Text) && userTextBox.Text.Equals("Username"))
                userTextBox.Clear();
            userTextBox.ForeColor = Color.FromArgb(25, 139, 177);
            username.Image = Properties.Resources.username2;
            userPanel.BackColor = Color.FromArgb(25, 139, 177);

            ResetPassword();
            resetEmail();
            resetPhone();
            resetAddress();
            resetDate();
        }

        private void PasswordBox_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(passTextBox.Text))
            {
                passTextBox.PasswordChar = '•';
                if (passTextBox.Text.Equals("Password"))
                    passTextBox.Clear();
            }
            else
                passTextBox.PasswordChar = '\0';
            passTextBox.ForeColor = Color.FromArgb(25, 139, 177);
            password.Image = Properties.Resources.pass2;
            passPanel.BackColor = Color.FromArgb(25, 139, 177);

            ResetUsername();
            resetEmail();
            resetPhone();
            resetAddress();
            resetDate();
        }
        private void mail_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(emailTextBox.Text) && emailTextBox.Text.Equals("Email"))
                emailTextBox.Clear();
            emailTextBox.ForeColor = Color.FromArgb(25, 139, 177);
            email.Image = Properties.Resources.mail2;
            emailPanel.BackColor = Color.FromArgb(25, 139, 177);

            ResetUsername();
            ResetPassword();
            resetPhone();
            resetAddress();
            resetDate();
        }
        private void phone_click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(phoneTextBox.Text) && phoneTextBox.Text.Equals("Phone"))
                phoneTextBox.Clear();
            phoneTextBox.ForeColor = Color.FromArgb(25, 139, 177);
            phone.Image = Properties.Resources.phone2;
            phonePanel.BackColor = Color.FromArgb(25, 139, 177);

            ResetUsername();
            ResetPassword();
            resetEmail();
            resetAddress();
            resetDate();
        }
        private void address_click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(addressTextBox.Text) && addressTextBox.Text.Equals("Address"))
                addressTextBox.Clear();
            addressTextBox.ForeColor = Color.FromArgb(25, 139, 177);
            address.Image = Properties.Resources.address2;
            addressPanel.BackColor = Color.FromArgb(25, 139, 177);

            ResetUsername();
            ResetPassword();
            resetEmail();
            resetPhone();
            resetDate();
        }
        private void date_click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(dateTextBox.Text) && dateTextBox.Text.Equals("Birthday"))
                dateTextBox.Clear();
            dateTextBox.ForeColor = Color.FromArgb(25, 139, 177);
            date.Image = Properties.Resources.birth2;
            birthPanel.BackColor = Color.FromArgb(25, 139, 177);

            ResetUsername();
            ResetPassword();
            resetEmail();
            resetAddress();
            resetPhone();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {

        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            if (Regexp("^(?:(?:\\d{2}\\.){2}|(?:\\d{2}\\/){2})\\d{4}$", dateTextBox))
            {
                //
            }
            else
            {
                errorTextBox.ForeColor = Color.Red;
                errorTextBox.Visible = true;
                errorTextBox.Text = "Birth date format is not valid";
            }
        }

        private void SignupMenu_Load(object sender, EventArgs e)
        {

        }

        private void password_Click(object sender, EventArgs e)
        {

        }

        private void phoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void errorTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}
