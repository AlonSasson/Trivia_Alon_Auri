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
            this.SuspendLayout();
            // 
            // winners
            // 
            this.winners.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.winners.FormattingEnabled = true;
            this.winners.ItemHeight = 29;
            this.winners.Location = new System.Drawing.Point(21, 62);
            this.winners.Name = "winners";
            this.winners.Size = new System.Drawing.Size(767, 352);
            this.winners.TabIndex = 0;
            this.winners.Visible = false;
            this.winners.SelectedIndexChanged += new System.EventHandler(this.winners_SelectedIndexChanged);
            // 
            // leave
            // 
            this.leave.Location = new System.Drawing.Point(666, 361);
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
            this.textBox1.Location = new System.Drawing.Point(69, 18);
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
            // ResultMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.leave);
            this.Controls.Add(this.winners);
            this.Name = "ResultMenu";
            this.Text = "ResultMenu";
            this.Load += new System.EventHandler(this.ResultMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox winners;
        private System.Windows.Forms.Button leave;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
    }
}