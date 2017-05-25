namespace Tetris
{
    partial class Form_game
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
            this.pbRun = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.startBtn = new System.Windows.Forms.Button();
            this.pbReady = new System.Windows.Forms.Label();
            this.pauseBtn = new System.Windows.Forms.Button();
            this.configBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbRun
            // 
            this.pbRun.BackColor = System.Drawing.Color.Black;
            this.pbRun.Location = new System.Drawing.Point(12, 12);
            this.pbRun.Name = "pbRun";
            this.pbRun.Size = new System.Drawing.Size(200, 300);
            this.pbRun.TabIndex = 0;
            this.pbRun.TabStop = false;
            this.pbRun.Paint += new System.Windows.Forms.PaintEventHandler(this.pbRun_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.configBtn);
            this.panel1.Controls.Add(this.pauseBtn);
            this.panel1.Controls.Add(this.startBtn);
            this.panel1.Controls.Add(this.pbReady);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(217, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 322);
            this.panel1.TabIndex = 1;
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(29, 136);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "开始游戏";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // pbReady
            // 
            this.pbReady.BackColor = System.Drawing.Color.Black;
            this.pbReady.Location = new System.Drawing.Point(16, 12);
            this.pbReady.Name = "pbReady";
            this.pbReady.Size = new System.Drawing.Size(100, 100);
            this.pbReady.TabIndex = 0;
            this.pbReady.Text = "label1";
            this.pbReady.Paint += new System.Windows.Forms.PaintEventHandler(this.pbReady_Paint);
            // 
            // pauseBtn
            // 
            this.pauseBtn.Location = new System.Drawing.Point(29, 166);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(75, 23);
            this.pauseBtn.TabIndex = 2;
            this.pauseBtn.Text = "暂停";
            this.pauseBtn.UseVisualStyleBackColor = true;
            this.pauseBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // configBtn
            // 
            this.configBtn.Location = new System.Drawing.Point(29, 195);
            this.configBtn.Name = "configBtn";
            this.configBtn.Size = new System.Drawing.Size(75, 23);
            this.configBtn.TabIndex = 3;
            this.configBtn.Text = "配置游戏";
            this.configBtn.UseVisualStyleBackColor = true;
            this.configBtn.Click += new System.EventHandler(this.configBtn_Click);
            // 
            // Form_game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 322);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pbRun);
            this.KeyPreview = true;
            this.Name = "Form_game";
            this.Text = "俄罗斯方块";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_game_FormClosing);
            this.Load += new System.EventHandler(this.Form_game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_game_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbRun)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRun;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label pbReady;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button pauseBtn;
        private System.Windows.Forms.Button configBtn;
    }
}