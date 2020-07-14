namespace Trivia_Client
{
    partial class StatisticsMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsMenu));
            this.BackButton = new System.Windows.Forms.Button();
            this.Names = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Scores = new System.Windows.Forms.ListBox();
            this.Positions = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.TimeBox = new System.Windows.Forms.TextBox();
            this.CorrectAnsBox = new System.Windows.Forms.TextBox();
            this.TotalAnsBox = new System.Windows.Forms.TextBox();
            this.GamesBox = new System.Windows.Forms.TextBox();
            this.ScoreBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("David", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.BackButton.ForeColor = System.Drawing.Color.Black;
            this.BackButton.Location = new System.Drawing.Point(391, 474);
            this.BackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(257, 71);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Back To Rooms";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Names
            // 
            this.Names.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.Names.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Names.Font = new System.Drawing.Font("David", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Names.FormattingEnabled = true;
            this.Names.ItemHeight = 36;
            this.Names.Location = new System.Drawing.Point(81, 119);
            this.Names.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Names.Name = "Names";
            this.Names.Size = new System.Drawing.Size(191, 180);
            this.Names.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox1.Location = new System.Drawing.Point(81, 11);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(257, 54);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Top Scores";
            // 
            // Scores
            // 
            this.Scores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.Scores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Scores.Font = new System.Drawing.Font("David", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Scores.FormattingEnabled = true;
            this.Scores.ItemHeight = 36;
            this.Scores.Location = new System.Drawing.Point(290, 119);
            this.Scores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Scores.Name = "Scores";
            this.Scores.Size = new System.Drawing.Size(191, 180);
            this.Scores.TabIndex = 6;
            // 
            // Positions
            // 
            this.Positions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.Positions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Positions.Font = new System.Drawing.Font("David", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Positions.FormattingEnabled = true;
            this.Positions.ItemHeight = 36;
            this.Positions.Items.AddRange(new object[] {
            "1#",
            "2#",
            "3#",
            "4#",
            "5#"});
            this.Positions.Location = new System.Drawing.Point(28, 119);
            this.Positions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Positions.Name = "Positions";
            this.Positions.Size = new System.Drawing.Size(47, 180);
            this.Positions.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Trivia_Client.Properties.Resources.LightCrown;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = global::Trivia_Client.Properties.Resources.IdoMeleh;
            this.pictureBox1.Location = new System.Drawing.Point(81, 82);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // NameBox
            // 
            this.NameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NameBox.Location = new System.Drawing.Point(733, 24);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(100, 38);
            this.NameBox.TabIndex = 9;
            this.NameBox.Text = "Name";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox2.Location = new System.Drawing.Point(541, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(270, 38);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Average Time";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox3.Location = new System.Drawing.Point(541, 163);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(270, 38);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "Correct Answers";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox4.Location = new System.Drawing.Point(541, 207);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(270, 38);
            this.textBox4.TabIndex = 9;
            this.textBox4.Text = "Total Answers";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox5.Location = new System.Drawing.Point(541, 251);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(270, 38);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "Games Played";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBox6.Location = new System.Drawing.Point(541, 295);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(270, 38);
            this.textBox6.TabIndex = 9;
            this.textBox6.Text = "Score";
            // 
            // TimeBox
            // 
            this.TimeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.TimeBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TimeBox.Location = new System.Drawing.Point(840, 119);
            this.TimeBox.Name = "TimeBox";
            this.TimeBox.Size = new System.Drawing.Size(140, 38);
            this.TimeBox.TabIndex = 9;
            // 
            // CorrectAnsBox
            // 
            this.CorrectAnsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.CorrectAnsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CorrectAnsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CorrectAnsBox.Location = new System.Drawing.Point(840, 163);
            this.CorrectAnsBox.Name = "CorrectAnsBox";
            this.CorrectAnsBox.Size = new System.Drawing.Size(140, 38);
            this.CorrectAnsBox.TabIndex = 9;
            // 
            // TotalAnsBox
            // 
            this.TotalAnsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.TotalAnsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TotalAnsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TotalAnsBox.Location = new System.Drawing.Point(840, 207);
            this.TotalAnsBox.Name = "TotalAnsBox";
            this.TotalAnsBox.Size = new System.Drawing.Size(140, 38);
            this.TotalAnsBox.TabIndex = 9;
            // 
            // GamesBox
            // 
            this.GamesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.GamesBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GamesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.GamesBox.Location = new System.Drawing.Point(840, 251);
            this.GamesBox.Name = "GamesBox";
            this.GamesBox.Size = new System.Drawing.Size(140, 38);
            this.GamesBox.TabIndex = 9;
            // 
            // ScoreBox
            // 
            this.ScoreBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.ScoreBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScoreBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ScoreBox.Location = new System.Drawing.Point(840, 295);
            this.ScoreBox.Name = "ScoreBox";
            this.ScoreBox.Size = new System.Drawing.Size(140, 38);
            this.ScoreBox.TabIndex = 9;
            // 
            // StatisticsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(164)))));
            this.ClientSize = new System.Drawing.Size(1004, 567);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.ScoreBox);
            this.Controls.Add(this.GamesBox);
            this.Controls.Add(this.TotalAnsBox);
            this.Controls.Add(this.CorrectAnsBox);
            this.Controls.Add(this.TimeBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Scores);
            this.Controls.Add(this.Positions);
            this.Controls.Add(this.Names);
            this.Controls.Add(this.BackButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatisticsMenu";
            this.Text = "Trivia!";
            this.Load += new System.EventHandler(this.StatisticsMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ListBox Names;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox Scores;
        private System.Windows.Forms.ListBox Positions;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox TimeBox;
        private System.Windows.Forms.TextBox CorrectAnsBox;
        private System.Windows.Forms.TextBox TotalAnsBox;
        private System.Windows.Forms.TextBox GamesBox;
        private System.Windows.Forms.TextBox ScoreBox;
    }
}