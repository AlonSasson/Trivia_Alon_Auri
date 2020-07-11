using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trivia_Client
{
    public partial class RoomMenu : Form
    {
        private BackgroundWorker updateThread = new BackgroundWorker();
        private BackgroundWorker roomChangeThread = new BackgroundWorker();
        public RoomMenu()
        {
            InitializeComponent();
            updateThread.DoWork += UpdateScreen;
            updateThread.RunWorkerAsync();
            roomChangeThread.DoWork += CheckRoomChange;
            roomChangeThread.RunWorkerAsync();
        }

        // updates the room on the screen
        private void UpdateScreen(object sender, EventArgs e)
        {

        }

        // aborts the update thread
        private void StopUpdate()
        {
            updateThread.CancelAsync();
        }

        // checks for a change in the room (start / leave)
        private void CheckRoomChange(object sender, EventArgs e)
        {

        }
        // stops checking for a change in the room (start / leave)
        private void StopRoomChangeCheck()
        {
            roomChangeThread.CancelAsync();
        }
        public void leaveRoomWorked()
        {
            this.Hide();
            StopRoomChangeCheck();
            StopUpdate();
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

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (StartButton.Visible)
                RequestHandler.StartGame(this);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if(CloseButton.Visible)
                RequestHandler.CloseRoom(this);
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

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            if (LeaveButton.Visible)
                RequestHandler.LeaveRoom(this);
        }

     
    }
}
