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
    
    public partial class GameMenu : Form
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
        private int TimeLeft = 0;
        private int QuestionsLeft = 0;
        private int AnswerTimeout = 0;
        private int LastAnswerId = 0;
        public GameMenu(int questionCount, int answerTimeout)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            QuestionsLeft = questionCount;
            AnswerTimeout = answerTimeout;
            TimeLeft = answerTimeout;
            RequestHandler.GetQuestion(this);
        }

        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            TimeLeft--;
            TimeBox.Text = TimeLeft.ToString();
            if (TimeLeft == 0) // if the time ended
            {
                UpdateAnswerColor(1, false);
                UpdateAnswerColor(2, false);
                UpdateAnswerColor(3, false);
                UpdateAnswerColor(4, false);
                LastAnswerId = -1;
                RequestHandler.SubmitAnswer(-1, this);
            }
        }

        public void UpdateQuestion(String Question, Dictionary<int, String> Answers)
        {
            QuestionsLeft--;
            QuestionsLeftBox.Text = QuestionsLeft.ToString();
            QuestionBox.Text = Question;
            TimeLeft = AnswerTimeout;
            this.AnswerBox1.Text = Answers[1];
            this.AnswerBox2.Text = Answers[2];
            this.AnswerBox3.Text = Answers[3];
            this.AnswerBox4.Text = Answers[4];
            ResetAnswers();
            QuestionTimer.Start();
        }

        public void UpdateCorrectAnswer(int CorrectAnswerId)
        {
            QuestionTimer.Stop();
            UpdateAnswerColor(CorrectAnswerId, true);
            if(LastAnswerId == CorrectAnswerId) // if the answer was correct
                CorrectAnswersBox.Text = (int.Parse(CorrectAnswersBox.Text) + 1).ToString();
            TimeLeft = 5; // show results for 5 secs
            ResultTimer.Start();
        }

        private void ResultTimer_Tick(object sender, EventArgs e)
        {
            TimeLeft--;
            if(TimeLeft == 0)
            {
                ResultTimer.Stop();
                RequestHandler.GetQuestion(this);
            }
        }

        public void UpdateAnswerColor(int AnswerId, bool IsRight)
        {
            Console.WriteLine(AnswerId);
            Button answer = null;
            PictureBox VButton = null;

            switch(AnswerId)
            {
                case (1):
                    answer = AnswerBox1;
                    VButton = V1;
                    break;
                case (2):
                    answer = AnswerBox2;
                    VButton = V2;
                    break;
                case (3):
                    answer = AnswerBox3;
                    VButton = V3;
                    break;
                case (4):
                    answer = AnswerBox4;
                    VButton = V4;
                    break;

            }
            VButton.Visible = true;

            if (IsRight)
            {
                answer.ForeColor = Color.FromName("Green");
                VButton.Image = Trivia_Client.Properties.Resources.vmark;
            }            
            else
            {
                answer.ForeColor = Color.FromName("Red");
                VButton.Image = Trivia_Client.Properties.Resources.xmark;
            }

        }

        private void Answer1_Click(object sender, EventArgs e)
        {
            if (QuestionTimer.Enabled) // if no answer has been submited yet
            {
                QuestionTimer.Stop();
                UpdateAnswerColor(1, false);
                LastAnswerId = 1;
                RequestHandler.SubmitAnswer(1, this);
            }
        }

        private void Answer2_Click(object sender, EventArgs e)
        {
            if (QuestionTimer.Enabled) // if no answer has been submited yet
            {
                QuestionTimer.Stop();
                UpdateAnswerColor(2, false);
                LastAnswerId = 2;
                RequestHandler.SubmitAnswer(2, this);
            }
        }

        private void Answer3_Click(object sender, EventArgs e)
        {
            if (QuestionTimer.Enabled) // if no answer has been submited yet
            {
                QuestionTimer.Stop();
                UpdateAnswerColor(3, false);
                LastAnswerId = 3;
                RequestHandler.SubmitAnswer(3, this);
            }
        }

        private void Answer4_Click(object sender, EventArgs e)
        {
            if(QuestionTimer.Enabled) // if no answer has been submited yet
            {
                QuestionTimer.Stop();
                UpdateAnswerColor(4, false);
                LastAnswerId = 4;
                RequestHandler.SubmitAnswer(4, this);
            }            
        }

        private void ResetAnswers()
        {
            AnswerBox1.ForeColor = Color.FromArgb(78, 184, 206);
            AnswerBox2.ForeColor = Color.FromArgb(78, 184, 206);
            AnswerBox3.ForeColor = Color.FromArgb(78, 184, 206);
            AnswerBox4.ForeColor = Color.FromArgb(78, 184, 206);
            V1.Visible = false;
            V2.Visible = false;
            V3.Visible = false;
            V4.Visible = false;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            QuestionTimer.Stop();
            RequestHandler.LeaveGame(this);
        }

        public void QuitWorked()
        {
            this.Hide();
            RoomListMenu roomListMenu = new RoomListMenu();
            roomListMenu.ShowDialog();
            this.Close();
        }

        private void GameMenu_Load(object sender, EventArgs e)
        {

        }
        public void NeedResults()
        {
            this.Hide();
            ResultMenu resultMenu = new ResultMenu();
            resultMenu.ShowDialog();
            this.Close();
        }
    }
}
