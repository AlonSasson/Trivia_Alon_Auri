using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace Trivia_Client
{
    public partial class ResultMenu : Form
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
        public ResultMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
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

        public void UpdateResults(List<string> results)
        {
            winners.Visible = true;
            leave.Visible = true;
            pictureBox1.Visible = true;
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
