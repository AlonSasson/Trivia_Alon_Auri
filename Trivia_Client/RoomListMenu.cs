using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace Trivia_Client
{
    public partial class RoomListMenu : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
             int nLeftRect,     // x-coordinate of upper-left corner
             int nTopRect,      // y-coordinate of upper-left corner
             int nRightRect,    // x-coordinate of lower-right corner
             int nBottomRect,   // y-coordinate of lower-right corner
             int nWidthEllipse, // height of ellipse
             int nHeightEllipse // width of ellipse
        );
        public RoomListMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            runThread();
        }
        private BackgroundWorker updateThread;
        private void runThread()
        {
            updateThread = new BackgroundWorker();
            updateThread.WorkerSupportsCancellation = true;
            updateThread.DoWork += UpdateScreen;
            updateThread.RunWorkerAsync();
        }
        public void showErrorBox(String errorToShow)
        {
            Action action = () => this.errorTextBox.Text = errorToShow;
            errorTextBox.Invoke(action);

            action = () => this.errorTextBox.Visible = true;
            errorTextBox.Invoke(action);

        }
        public void LogoutWorked()
        {
            this.Hide();
            StopUpdate();
            LoginMenu loginMenu = new LoginMenu();
            loginMenu.ShowDialog();
            this.Close();
        }

      
        public void JoinRoomWorked()
        {
            this.Hide();
            StopUpdate();
            RoomMenu roomMenu = new RoomMenu();
            roomMenu.Member();
            roomMenu.ShowDialog();
            this.Close();
        }

        public void addRooms(List<string> rooms)
        {
            bool nameNotInList = true;

            foreach (object name in RoomList.Items)
            {
                nameNotInList = true;
                foreach (string room in rooms)
                {
                    if (name.ToString().Equals(room))
                    {
                        nameNotInList = false;
                    }

                }
                if (nameNotInList)
                {
                    PlayerList.Items.Remove(name);
                }
            }
            nameNotInList = true;
            foreach (string roomName in rooms)
            {
                for (int i =0;i<RoomList.Items.Count;i++)
                {
                    if (RoomList.Items[i].ToString().Equals(roomName))
                        nameNotInList = false;
                }
                if (nameNotInList)
                {
                    Action action = () => RoomList.Items.Add(roomName);
                    RoomList.Invoke(action);
                }
            }

        }
        // updates the room on the screen
        private void UpdateScreen(object sender, EventArgs e)
        {
            while (true)
            {
                Thread.Sleep(10000);
                if (updateThread.CancellationPending)
                    break;
                RequestHandler.GetRooms(this);

            }
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
            StopUpdate();
            if(RoomList.SelectedItems.Count != 0) // if a room has been selected
            {
                RequestHandler.GetPlayersInRoom(RoomList.SelectedItem.ToString(), this);
            }
            runThread();
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            if (RoomList.SelectedItems.Count != 0) // if a room has been selected
                RequestHandler.JoinRoom(RoomList.SelectedItem.ToString(), this);
        }

        public void ShowPlayers(List<string> list)
        {
            bool nameNotInList = true;

            foreach(object name in PlayerList.Items)
            {
                nameNotInList = true;
                foreach(string playerName in list)
                {
                    if(name.ToString().Equals(playerName))
                    {
                        nameNotInList = false;
                    }
                    
                }
                if(nameNotInList)
                {
                    PlayerList.Items.Remove(name);   
                }
            }
            nameNotInList = true;
            foreach (string playerName in list)
           {
                foreach(object name in PlayerList.Items)
                {
                    if (name.ToString().Equals(playerName))
                        nameNotInList = false;
                }
                if(nameNotInList)
                    PlayerList.Items.Add(playerName);
                
            }
            PlayerList.Visible = true;
        }

        private void RoomListMenu_MouseClick(object sender, MouseEventArgs e)
        {
            PlayerList.Visible = false;
        }

        private void RoomList_MouseClick(object sender, MouseEventArgs e)
        {
            PlayerList.Location = e.Location;
        }

        private void errorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RoomListMenu_Load(object sender, EventArgs e)
        {

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StopUpdate();
            CreateRoomMenu roomMenu = new CreateRoomMenu();
            roomMenu.ShowDialog();
            this.Close();
        }
        public void ClearList()
        {
            Action action = () => RoomList.Items.Clear();
            RoomList.Invoke(action); 
        }

        private void StatsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StopUpdate();
            StatisticsMenu StatsMenu = new StatisticsMenu();
            StatsMenu.ShowDialog();
            this.Close();
        }

        private void stats_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            StopUpdate();
            StatisticsMenu StatsMenu = new StatisticsMenu();
            StatsMenu.ShowDialog();
            this.Close();
        }
    }
}
