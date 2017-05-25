namespace Tetris
{
    partial class Form_config
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.evmSet = new System.Windows.Forms.GroupBox();
            this.labelbgColor = new System.Windows.Forms.Label();
            this.textBoxVGrid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxGridPixel = new System.Windows.Forms.TextBox();
            this.textBoxHGrid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.kbSet = new System.Windows.Forms.GroupBox();
            this.textAntiWise = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textwise = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textdrop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textright = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textleft = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textdown = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clearBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.addBrickBtn = new System.Windows.Forms.Button();
            this.bricklistView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colorLabel = new System.Windows.Forms.Label();
            this.BrickStyleLabel = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveBtn = new System.Windows.Forms.Button();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.evmSet.SuspendLayout();
            this.kbSet.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 342);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.evmSet);
            this.tabPage1.Controls.Add(this.kbSet);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(441, 316);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数配置";
            // 
            // evmSet
            // 
            this.evmSet.Controls.Add(this.labelbgColor);
            this.evmSet.Controls.Add(this.textBoxVGrid);
            this.evmSet.Controls.Add(this.label7);
            this.evmSet.Controls.Add(this.label10);
            this.evmSet.Controls.Add(this.textBoxGridPixel);
            this.evmSet.Controls.Add(this.textBoxHGrid);
            this.evmSet.Controls.Add(this.label8);
            this.evmSet.Controls.Add(this.label9);
            this.evmSet.Location = new System.Drawing.Point(230, 21);
            this.evmSet.Name = "evmSet";
            this.evmSet.Size = new System.Drawing.Size(200, 275);
            this.evmSet.TabIndex = 1;
            this.evmSet.TabStop = false;
            this.evmSet.Text = "环境设置";
            // 
            // labelbgColor
            // 
            this.labelbgColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelbgColor.Location = new System.Drawing.Point(99, 147);
            this.labelbgColor.Name = "labelbgColor";
            this.labelbgColor.Size = new System.Drawing.Size(63, 19);
            this.labelbgColor.TabIndex = 19;
            this.labelbgColor.Click += new System.EventHandler(this.labelbgColor_Click);
            // 
            // textBoxVGrid
            // 
            this.textBoxVGrid.Location = new System.Drawing.Point(99, 69);
            this.textBoxVGrid.Name = "textBoxVGrid";
            this.textBoxVGrid.Size = new System.Drawing.Size(63, 21);
            this.textBoxVGrid.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "背景色";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "水平格子数";
            // 
            // textBoxGridPixel
            // 
            this.textBoxGridPixel.Location = new System.Drawing.Point(99, 105);
            this.textBoxGridPixel.Name = "textBoxGridPixel";
            this.textBoxGridPixel.Size = new System.Drawing.Size(63, 21);
            this.textBoxGridPixel.TabIndex = 17;
            // 
            // textBoxHGrid
            // 
            this.textBoxHGrid.Location = new System.Drawing.Point(99, 33);
            this.textBoxHGrid.Name = "textBoxHGrid";
            this.textBoxHGrid.Size = new System.Drawing.Size(63, 21);
            this.textBoxHGrid.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "格子像素";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "垂直格子数";
            // 
            // kbSet
            // 
            this.kbSet.Controls.Add(this.textAntiWise);
            this.kbSet.Controls.Add(this.label6);
            this.kbSet.Controls.Add(this.textwise);
            this.kbSet.Controls.Add(this.label5);
            this.kbSet.Controls.Add(this.textdrop);
            this.kbSet.Controls.Add(this.label4);
            this.kbSet.Controls.Add(this.textright);
            this.kbSet.Controls.Add(this.label3);
            this.kbSet.Controls.Add(this.textleft);
            this.kbSet.Controls.Add(this.label2);
            this.kbSet.Controls.Add(this.textdown);
            this.kbSet.Controls.Add(this.label1);
            this.kbSet.Location = new System.Drawing.Point(8, 21);
            this.kbSet.Name = "kbSet";
            this.kbSet.Size = new System.Drawing.Size(200, 277);
            this.kbSet.TabIndex = 0;
            this.kbSet.TabStop = false;
            this.kbSet.Text = "键盘设置";
            // 
            // textAntiWise
            // 
            this.textAntiWise.Location = new System.Drawing.Point(91, 213);
            this.textAntiWise.Name = "textAntiWise";
            this.textAntiWise.ReadOnly = true;
            this.textAntiWise.Size = new System.Drawing.Size(63, 21);
            this.textAntiWise.TabIndex = 11;
            this.textAntiWise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textdown_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "逆时针旋转";
            // 
            // textwise
            // 
            this.textwise.Location = new System.Drawing.Point(91, 177);
            this.textwise.Name = "textwise";
            this.textwise.ReadOnly = true;
            this.textwise.Size = new System.Drawing.Size(63, 21);
            this.textwise.TabIndex = 9;
            this.textwise.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textdown_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "顺时针旋转";
            // 
            // textdrop
            // 
            this.textdrop.Location = new System.Drawing.Point(91, 141);
            this.textdrop.Name = "textdrop";
            this.textdrop.ReadOnly = true;
            this.textdrop.Size = new System.Drawing.Size(63, 21);
            this.textdrop.TabIndex = 7;
            this.textdrop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textdown_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "丢下";
            // 
            // textright
            // 
            this.textright.Location = new System.Drawing.Point(91, 105);
            this.textright.Name = "textright";
            this.textright.ReadOnly = true;
            this.textright.Size = new System.Drawing.Size(63, 21);
            this.textright.TabIndex = 5;
            this.textright.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textdown_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "向右";
            // 
            // textleft
            // 
            this.textleft.Location = new System.Drawing.Point(91, 69);
            this.textleft.Name = "textleft";
            this.textleft.ReadOnly = true;
            this.textleft.Size = new System.Drawing.Size(63, 21);
            this.textleft.TabIndex = 3;
            this.textleft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textdown_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "向左";
            // 
            // textdown
            // 
            this.textdown.Location = new System.Drawing.Point(91, 33);
            this.textdown.Name = "textdown";
            this.textdown.ReadOnly = true;
            this.textdown.Size = new System.Drawing.Size(63, 21);
            this.textdown.TabIndex = 1;
            this.textdown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textdown_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "向下";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.clearBtn);
            this.tabPage2.Controls.Add(this.updateBtn);
            this.tabPage2.Controls.Add(this.delBtn);
            this.tabPage2.Controls.Add(this.addBrickBtn);
            this.tabPage2.Controls.Add(this.bricklistView);
            this.tabPage2.Controls.Add(this.colorLabel);
            this.tabPage2.Controls.Add(this.BrickStyleLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(441, 316);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "砖块样式配置";
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(83, 274);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(63, 23);
            this.clearBtn.TabIndex = 6;
            this.clearBtn.Text = "清空";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(11, 275);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(63, 23);
            this.updateBtn.TabIndex = 5;
            this.updateBtn.Text = "修改";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(83, 230);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(63, 23);
            this.delBtn.TabIndex = 4;
            this.delBtn.Text = "删除";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addBrickBtn
            // 
            this.addBrickBtn.Location = new System.Drawing.Point(9, 230);
            this.addBrickBtn.Name = "addBrickBtn";
            this.addBrickBtn.Size = new System.Drawing.Size(65, 23);
            this.addBrickBtn.TabIndex = 3;
            this.addBrickBtn.Text = "添加";
            this.addBrickBtn.UseVisualStyleBackColor = true;
            this.addBrickBtn.Click += new System.EventHandler(this.addBrickBtn_Click);
            // 
            // bricklistView
            // 
            this.bricklistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.bricklistView.FullRowSelect = true;
            this.bricklistView.GridLines = true;
            this.bricklistView.LabelEdit = true;
            this.bricklistView.Location = new System.Drawing.Point(164, 6);
            this.bricklistView.MultiSelect = false;
            this.bricklistView.Name = "bricklistView";
            this.bricklistView.Size = new System.Drawing.Size(274, 304);
            this.bricklistView.TabIndex = 2;
            this.bricklistView.UseCompatibleStateImageBehavior = false;
            this.bricklistView.View = System.Windows.Forms.View.Details;
            this.bricklistView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.breaklistView_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编码";
            this.columnHeader1.Width = 195;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "颜色";
            this.columnHeader2.Width = 189;
            // 
            // colorLabel
            // 
            this.colorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colorLabel.Location = new System.Drawing.Point(11, 189);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(140, 23);
            this.colorLabel.TabIndex = 1;
            this.colorLabel.Click += new System.EventHandler(this.colorLabel_Click);
            // 
            // BrickStyleLabel
            // 
            this.BrickStyleLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BrickStyleLabel.Location = new System.Drawing.Point(3, 3);
            this.BrickStyleLabel.Name = "BrickStyleLabel";
            this.BrickStyleLabel.Size = new System.Drawing.Size(155, 155);
            this.BrickStyleLabel.TabIndex = 0;
            this.BrickStyleLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.BrickStyle_Paint);
            this.BrickStyleLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BrickStyle_MouseClick);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(137, 360);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "保存设置";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(240, 360);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 2;
            this.CloseBtn.Text = "取消设置";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // Form_config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 395);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_config";
            this.Text = "配置窗口";
            this.Load += new System.EventHandler(this.Form_config_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.evmSet.ResumeLayout(false);
            this.evmSet.PerformLayout();
            this.kbSet.ResumeLayout(false);
            this.kbSet.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label BrickStyleLabel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ListView bricklistView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button addBrickBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.GroupBox evmSet;
        private System.Windows.Forms.GroupBox kbSet;
        private System.Windows.Forms.TextBox textright;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textleft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAntiWise;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textwise;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textdrop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVGrid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxGridPixel;
        private System.Windows.Forms.TextBox textBoxHGrid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelbgColor;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button CloseBtn;
    }
}

