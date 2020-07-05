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
            while (true)
                RequestHandler.GetPlayersInRoom(this);
        }

        // aborts the update thread
        private void StopUpdate()
        {
            updateThread.CancelAsync();
        }

        // checks for a change in the room (start / leave)
        private void CheckRoomChange(object sender, EventArgs e)
        {
            while (true)
            {
                ResponseHandler.HandelResponse(Communicator.recvResponse(), this);
            }
        }
        // stops checking for a change in the room (start / leave)
        private void StopRoomChangeCheck()
        {
            roomChangeThread.CancelAsync();
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
    }
}
