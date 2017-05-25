using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class Form_game : Form
    {
        public Form_game()
        {
            InitializeComponent();
        }

        private Palette p;
        private Keys keyDown;
        private Keys keyDrop;
        private Keys keyLeft;
        private Keys keyRight;
        private Keys keyRotateWise;
        private Keys keyRotateAntiWise;
        private Color bgColor; /*画板背景色*/
        private int paletteWidth;/*画板宽度*/
        private int paletteHeight;/*画板高度*/
        private int pixel;/*每单元格像素*/

        private void startBtn_Click(object sender, EventArgs e)
        {
            /*在开始的过程中又点击开始则重新开始*/
            if (p != null)
            {
                p.Close();
            }
            p = new Palette(paletteWidth-1, paletteHeight, pixel, bgColor,
                Graphics.FromHwnd(pbRun.Handle), Graphics.FromHwnd(pbReady.Handle));
            p.Start();
        }

        private void pbRun_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.PaintPalette(e.Graphics);
            }
        }

        private void pbReady_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.PaintReady(e.Graphics);
            }
        }

        private void Form_game_Load(object sender, EventArgs e)
        {
            /*读取xml中的参数信息，赋给私有成员变量*/
            Config config = new Config();
            config.LoadFromXmlFile();
            keyDown = config.keyDown;
            keyLeft = config.keyLeft;
            keyRight = config.keyRight;
            keyRotateWise = config.keyRotateWise;
            keyRotateAntiWise = config.keyRotateAntiWise;
            keyDrop = config.keyDrop;
            bgColor = config.bgColor;
            paletteHeight = config.HGridNum;
            paletteWidth = config.VGridNum;
            pixel = config.Pixel;

            /*根据画板的长度和宽度信息动态的改变窗体及画板的大小*/
            this.Width = paletteWidth * pixel + pbReady.Width + 40;
            this.Height = paletteHeight * pixel + 60;
            pbRun.Width = paletteWidth * pixel;
            pbRun.Height = paletteHeight * pixel;
        }

        private void Form_game_KeyDown(object sender, KeyEventArgs e)
        {
            if (p == null)
            {
                return;
            }
            /*屏蔽回车键，因为玩游戏点击开始按钮之后，焦点就一直在开始按钮上，
            这时按回车会再次点击开始按钮*/
            if (e.KeyValue == 32)
            {
                e.Handled = true;
            }
            if (e.KeyCode == keyDown)
            {
                p.MoveDown();
            }else if (e.KeyCode == keyLeft)
            {
                p.MoveLeft();
            }else if (e.KeyCode == keyRight)
            {
                p.MoveRight();
            }else if (e.KeyCode == keyRotateWise)
            {
                p.RotateWise();
            }else if (e.KeyCode == keyRotateAntiWise)
            {
                p.RotateAntiWise();
            }else if (e.KeyCode == keyDrop)
            {
                p.Drop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p == null)
            {
                return;
            }
            if (pauseBtn.Text == "暂停")
            {
                p.PauseGame();
                pauseBtn.Text = "继续";
            }else if(pauseBtn.Text == "继续")
            {
                p.ResumeGame();
                pauseBtn.Text = "暂停";
            }
        }

        private void configBtn_Click(object sender, EventArgs e)
        {
            /*首先使游戏暂停*/
            if (pauseBtn.Text == "暂停")
            {
                pauseBtn.PerformClick();/*点击暂停按钮*/
            }
            /*自动析构*/
            using (Form_config configForm = new Form_config())
            {
                configForm.ShowDialog();/*使用ShowDialog方法，
                                        即只有关闭这个打开的窗体后才能执行下一步的代码*/
            }
        }

        private void Form_game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (p != null)
            {
                p.Close();
            }
        }
    }
}
