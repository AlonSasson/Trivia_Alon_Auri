using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Trivia_Client
{
    public partial class StatisticsMenu : Form
    {
        public StatisticsMenu()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RoomListMenu roomListMenu = new RoomListMenu();
            roomListMenu.ShowDialog();
            this.Close();
        }

        private void StatisticsMenu_Load(object sender, EventArgs e)
        {
            RequestHandler.GetStatistics(this);
        }

        public void ShowScores(List<String> Scores)
        {
            String Name;
            String Score;
            int NameLength = 0;
            foreach (String UserScore in Scores)
            {
                NameLength = UserScore.LastIndexOf(":");
                Name = UserScore.Substring(1, NameLength - 2);
                this.Names.Items.Add(Name);
                Score = UserScore.Substring(NameLength + 2, UserScore.Length - NameLength - 2);
                this.Scores.Items.Add(Score);
            }
        }

        public void ShowStatistics(String Statistics)
        {
            Dictionary<String, double> Stats = JsonConvert.DeserializeObject<Dictionary<String, double>>(Statistics);
            this.TimeBox.Text = Stats["avg_answer_time"].ToString();
            this.CorrectAnsBox.Text = Stats["correct_answers"].ToString();
            this.TotalAnsBox.Text = Stats["total_answers"].ToString();
            this.GamesBox.Text = Stats["games_played"].ToString();
            this.ScoreBox.Text = Stats["score"].ToString();
        }
    }
}
