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
    public partial class CreateRoomMenu : Form
    {
        public CreateRoomMenu()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxInput(this.usersTextBox.Text, this.timeTextBox.Text))
            {
                RequestHandler.CreateRoom(this.nameTextBox.Text, int.Parse(this.usersTextBox.Text), int.Parse(this.timeTextBox.Text), 10, this);

            }
            else
            {
                this.errorTextBox.Text = "Time for question and Max users should be numbers";
                this.errorTextBox.Visible = true;
            }
        }
        public void showErrorBox(String errorToShow)
        {
            this.errorTextBox.Text = errorToShow;
            this.errorTextBox.Visible = true;

        }

        private void leaveRoomButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomListMenu roomListMenu = new RoomListMenu();
            roomListMenu.ShowDialog();
            this.Close();
        }
        public void createRoomWorked()
        {
            this.Hide();
            RoomMenu roomMenu = new RoomMenu();
           roomMenu.Admin();
            roomMenu.ShowDialog();
            this.Close();
        }
        private bool CheckTextBoxInput(string str1 , string str2)
        {
            bool bothInt = false;
            int num;
            if(int.TryParse(str1 , out num) && int.TryParse(str2, out num))
            {
                bothInt = true;
            }
            return bothInt;
        }
    }
}
