using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Trivia_Client.RequestHandler;

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
            PasswordPic.Image = Properties.Resources.pass;
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
            UsernamePic.Image = Properties.Resources.username;
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
            UsernamePic.Image = Properties.Resources.username2;
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
            PasswordPic.Image = Properties.Resources.pass2;
            PassPanel.BackColor = Color.FromArgb(25, 139, 177);

            ResetUsername();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            RequestHandler.Login(UsernameBox.Text, PasswordBox.Text, this);
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignupMenu signup = new SignupMenu();
            signup.ShowDialog();
            this.Close();
        }

        private void Crown_Click(object sender, EventArgs e)
        {

        }

        private void LoginMenu_Load(object sender, EventArgs e)
        {

        }
        public void showErrorBox(String errorToShow)
        {
            this.errorTextBox.Text = errorToShow;
            this.errorTextBox.Visible = true;

        }
        public void LoginWorked()
        {
            this.Hide();
            RoomListMenu roomListMenu = new RoomListMenu();
            roomListMenu.ShowDialog();
            this.Close();
        }

        private void UsernameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
