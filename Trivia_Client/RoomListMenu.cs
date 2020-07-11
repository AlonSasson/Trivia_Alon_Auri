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
    public partial class RoomListMenu : Form
    {
        private BackgroundWorker updateThread = new BackgroundWorker();
        public RoomListMenu()
        {
            InitializeComponent();
            updateThread.DoWork += UpdateScreen;
            updateThread.RunWorkerAsync();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void RoomList_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void errorTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        public void showErrorBox(String errorToShow)
        {
            this.errorTextBox.Text = errorToShow;
            this.errorTextBox.Visible = true;
        }
        public void LogoutWorked()
        {
            this.Hide();
            LoginMenu loginMenu = new LoginMenu();
            loginMenu.ShowDialog();
            this.Close();
        }
        private void RoomList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RoomListMenu_Load(object sender, EventArgs e)
        {

        }
        public RoomMenu JoinRoomWorked()
        {
            this.Hide();
            RoomMenu roomMenu = new RoomMenu();
            roomMenu.ShowDialog();
            this.Close();
            return roomMenu;
        }
        public RoomMenu createRoomWorked()
        {
            this.Hide();
            RoomMenu roomMenu = new RoomMenu();
            roomMenu.ShowDialog();
            this.Close();
            return roomMenu;
        }
        public void addRooms(List<string> rooms)
        {
            this.RoomList.Items.Add(rooms);
        }
        // updates the room on the screen
        private void UpdateScreen(object sender, EventArgs e)
        {
            while (true)
                RequestHandler.GetRooms(this);
        }

        // aborts the update thread
        private void StopUpdate()
        {
            updateThread.CancelAsync();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            RequestHandler.Logout(this);
        }

        private void RoomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequestHandler.GetPlayersInRoom(RoomList.SelectedItem.ToString(), this);
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            RequestHandler.JoinRoom(RoomList.SelectedItem.ToString(), this);
        }
    }
}
