namespace Trivia_Client
{
    partial class ResultMenu
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
            this.components = new System.ComponentModel.Container();
            this.winners = new System.Windows.Forms.ListBox();
            this.leave = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // winners
            // 
            this.winners.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.winners.FormattingEnabled = true;
            this.winners.ItemHeight = 29;
            this.winners.Location = new System.Drawing.Point(21, 69);
            this.winners.Name = "winners";
            this.winners.Size = new System.Drawing.Size(767, 352);
            this.winners.TabIndex = 0;
            this.winners.Visible = false;
            this.winners.SelectedIndexChanged += new System.EventHandler(this.winners_SelectedIndexChanged);
            // 
            // leave
            // 
            this.leave.Location = new System.Drawing.Point(807, 337);
            this.leave.Name = "leave";
            this.leave.Size = new System.Drawing.Size(122, 77);
            this.leave.TabIndex = 1;
            this.leave.Text = "button1";
            this.leave.UseVisualStyleBackColor = true;
            this.leave.Visible = false;
            this.leave.Click += new System.EventHandler(this.leave_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBox1.Location = new System.Drawing.Point(61, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(469, 38);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "waiting for other players";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Trivia_Client.Properties.Resources.IdoMeleh;
            this.pictureBox1.Location = new System.Drawing.Point(21, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ResultMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 427);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.leave);
            this.Controls.Add(this.winners);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ResultMenu";
            this.Text = "ResultMenu";
            this.Load += new System.EventHandler(this.ResultMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox winners;
        private System.Windows.Forms.Button leave;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}