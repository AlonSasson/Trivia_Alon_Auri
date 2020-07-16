using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Trivia_Client
{
    public partial class ResultMenu : Form
    {
        public ResultMenu()
        {
            InitializeComponent();
        }

        private void leave_Click(object sender, EventArgs e)
        {
            RequestHandler.LeaveGame(this);
        }
        public void QuitWorked()
        {
            this.Hide();
            RoomListMenu roomListMenu = new RoomListMenu();
            roomListMenu.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ResultMenu_Load(object sender, EventArgs e)
        {
        }
        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\auri\trivia_alon_auri\Trivia_Client\Resources\drum.mp3‬");
            simpleSound.Play();
        }
        public void UpdateResults(List<string> results)
        {
            playSimpleSound();
            winners.Visible = true;
            leave.Visible = true;
            textBox1.Visible = false;
            foreach(string result in results)
            {
                winners.Items.Add(result);
            }
        }

        private void winners_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            RequestHandler.GetGameResults(this);
        }
    }
}
