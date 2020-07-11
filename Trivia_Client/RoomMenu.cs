using System;
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
    public partial class RoomMenu : Form
    {
        public RoomMenu()
        {
            InitializeComponent();
        }

        private void RoomMenu_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RoomList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void LogoutWorked()
        {
            this.Hide();
            LoginMenu loginMenu = new LoginMenu();
            loginMenu.ShowDialog();
            this.Close();
        }
        public void leaveRoomWorked()
        {
            this.Hide();
            RoomListMenu roomListMenu = new RoomListMenu();
            roomListMenu.ShowDialog();
            this.Close();
        }
        public void showErrorBox(String errorToShow)
        {
            this.errorTextBox.Text = errorToShow;
            this.errorTextBox.Visible = true;

        }
        private void errorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {

        }
        public void Admin()
        {
            this.admin_box.Visible = true;
            this.LeaveButton .Visible= false;
            this.CloseButton.Visible = true;
            this.StartButton.Visible = true;
        }
        public void Member()
        {
            this.admin_box.Visible = false;
            this.LeaveButton.Visible = true;
            this.CloseButton.Visible = false;
            this.StartButton.Visible = false;
        }
        public void addPlayers(List<string> list)
        {
              PlayerList.Items.Add(list);         
        }
        public void SetParameters(string time)
        {
            this.answerTimeout.Text = "Time for each question: " + time;
            this.questionCount.Text = "Number of questions : 10";
        }
    }
}
