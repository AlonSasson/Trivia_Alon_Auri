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
        public RoomListMenu()
        {
            InitializeComponent();
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
    }
}
