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
    public partial class CreateRoomMenu : Form
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
        public CreateRoomMenu()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            
            if (CheckTextBoxInput(this.usersTextBox.Text, this.timeTextBox.Text) && this.nameTextBox.Text != "")
            {
                RequestHandler.CreateRoom(this.nameTextBox.Text, int.Parse(this.usersTextBox.Text), 10, int.Parse(this.timeTextBox.Text), this);

            }
            else
            {
                if(this.nameTextBox.Text == "")
                    this.errorTextBox.Text = "Name can't be empty";
                else            
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
        private bool CheckTextBoxInput(string str1, string str2)
        {
            bool bothInt = false;
            int num1;
            int num2;
            if (int.TryParse(str1, out num1) && int.TryParse(str2, out num2))
            {
                if(num1 <= 0 || num2 <= 0)
                {
                    return false;
                }
                bothInt = true;
            }
             return bothInt;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void nameTextBox_Click(object sender, EventArgs e)
        {
            this.nameTextBox.Text = "";
            this.pictureBox2.Visible = true;
            this.pictureBox3.Visible = true;
            resetAmountOfPlayers();
            resetTime();
        }
        private void resetNameTextBox()
        {
            this.pictureBox2.Visible = false;
            this.pictureBox3.Visible = false;
        }

        private void errorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void usersTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void amountOfPlayers_Click(object sender, EventArgs e)
        {
            this.usersTextBox.Text = "";
            this.pictureBox5.Visible = true;
            this.pictureBox6.Visible = true;
            resetNameTextBox();
            resetTime();
        }
        private void resetAmountOfPlayers()
        {
            this.pictureBox5.Visible = false;
            this.pictureBox6.Visible = false;
        }

        private void CreateRoomMenu_Load(object sender, EventArgs e)
        {

        }
        private void Time_Click(object sender, EventArgs e)
        {
            this.timeTextBox.Text = "";
            this.pictureBox8.Visible = true;
            this.pictureBox9.Visible = true;
            resetNameTextBox();
            resetAmountOfPlayers();
        }
        private void resetTime()
        {
            this.pictureBox8.Visible = false;
            this.pictureBox9.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
