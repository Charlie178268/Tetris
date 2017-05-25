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
    public partial class Form_config : Form
    {
        public Form_config()
        {
            InitializeComponent();
        }

        private bool[,] brickColorArr = new bool[5, 5];/*声明表示砖块颜色的数组*/
        private Color blockColor = Color.Red;/*砖块的颜色*/
        private Config config = new Config();

        private void BrickStyle_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            gp.Clear(Color.Black);/*设置清屏底色*/
            Pen p = new Pen(Color.White);
            
            /*画横白线*/
            for (int i = 30; i < 155; i += 31)
            {
                gp.DrawLine(p, 1, i, 155, i);
            }
            /*画竖白线*/
            for(int i=30; i<155; i += 31)
            {
                gp.DrawLine(p, i, 1, i, 155);
            }
            /*为防止窗体重绘后方块颜色消失，必须要填充方块*/
            SolidBrush s = new SolidBrush(blockColor);
            for (int xPos=0; xPos<5; xPos++)
            {
                for (int yPos = 0; yPos < 5; yPos++)
                {
                    if (brickColorArr[xPos, yPos])
                    {
                        gp.FillRectangle(s, 31 * xPos, 31 * yPos, 30, 30);
                    }
                }
            }
        }

        private void ClearBoard()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    brickColorArr[i, j] = false;
                }
            }
            BrickStyleLabel.Invalidate();
        }

        private void BrickStyle_MouseClick(object sender, MouseEventArgs e)
        {
            /*右键清空画板*/
            if (e.Button != MouseButtons.Left)
            {
                ClearBoard();
                return;
            }
            /*左键画方块*/
            /*计算出所点击方块的数组坐标,注意这里的逻辑坐标x,y是和数组的xy下标相反的*/
            int xPos, yPos;
            xPos = e.X / 31;
            yPos = e.Y / 31;
            brickColorArr[xPos, yPos] = !brickColorArr[xPos, yPos];
            bool b = brickColorArr[xPos,yPos];
            /*为方块涂颜色*/
            Graphics gp = BrickStyleLabel.CreateGraphics();/*得到label的画板*/
            SolidBrush s = new SolidBrush(b ? blockColor : Color.Black);
            gp.FillRectangle(s, 31 * xPos, 31 * yPos, 30, 30);
            gp.Dispose();/*释放画板*/
        }

        private void colorLabel_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();/*打开颜色对话框*/
            blockColor = colorDialog1.Color;
            colorLabel.BackColor = colorDialog1.Color;
            BrickStyleLabel.Invalidate();/*破坏BrickStyleLabel，使其重画，进而改变颜色*/
        }

        private void addBrickBtn_Click(object sender, EventArgs e)
        {
            /*首先查找图案是否合法，为空或者有不是相接的都提示*/
            bool isEmpty = false;
            foreach (var i in brickColorArr)
            {
                if (i == true)
                {
                    isEmpty = true;
                    break;
                }
            }
            if (!isEmpty)
            {
                MessageBox.Show("图案不能为空！请先点击左边窗格进行绘制！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            /*把方块信息用1和0表示为字符串，大量字符串的连接用到StringBuilder*/
            StringBuilder sb = new StringBuilder(25);
            foreach(var i in brickColorArr)
            {
                sb.Append(i?"1":"0");
            }
            string blockStr = sb.ToString();
            /*检查是否有重复图案*/
            foreach (ListViewItem i in bricklistView.Items)
            {
                if (blockStr == i.SubItems[0].Text)
                {
                    MessageBox.Show("此图案已存在！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            /*把新砖块添加进listview*/
            ListViewItem lvi = new ListViewItem();
            lvi = bricklistView.Items.Add(blockStr);
            lvi.SubItems.Add(Convert.ToString(blockColor.ToArgb()));
        }

        private void breaklistView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)/*避免重复执行事件*/
            {
                /*将颜色信息取出*/
                blockColor = Color.FromArgb(int.Parse(e.Item.SubItems[1].Text));
                colorLabel.BackColor = blockColor;
                /*取出方块信息*/
                string s = e.Item.SubItems[0].Text;
                for(int i=0; i<s.Length; i++)
                {
                    brickColorArr[i / 5, i % 5] = ((s[i] == '1') ? true : false);
                }
                BrickStyleLabel.Invalidate();
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            if (bricklistView.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要删除的对象！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            /*删除被选中的项目，因为我们设置了禁止多行选中，所以被选中项目只能有一个*/
            bricklistView.Items.Remove(bricklistView.SelectedItems[0]);
            ClearBoard();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            /*判断是否被选中*/
            if (bricklistView.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要修改的对象！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            /*判断是否为空*/
            bool isEmpty = false;
            foreach (var i in brickColorArr)
            {
                if (i == true)
                {
                    isEmpty = true;
                    break;
                }
            }
            if (!isEmpty)
            {
                MessageBox.Show("图案不能为空！请先点击左边窗格进行绘制！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            /*修改listview项*/
            StringBuilder sb = new StringBuilder(25);
            foreach (var i in brickColorArr)
            {
                sb.Append(i ? "1" : "0");
            }
            string blockStr = sb.ToString();
            bricklistView.SelectedItems[0].SubItems[0].Text = blockStr;
            bricklistView.SelectedItems[0].SubItems[1].Text = Convert.ToString(blockColor.ToArgb());
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearBoard();
        }

        private void textdown_KeyDown(object sender, KeyEventArgs e)
        {
            /*首先排除掉一些键*/
            if ((e.KeyValue>=33 && e.KeyValue<=40) || (e.KeyValue>=48 && e.KeyValue<=111) ||
                (e.KeyValue >= 186 && e.KeyValue <= 222))
            {
                /*检查是否存在冲突的快捷键*/
                foreach(Control i in kbSet.Controls)
                {
                    TextBox tempCtl = i as TextBox;
                    if (tempCtl!=null && tempCtl.Text != "")
                    {
                        if (tempCtl.Text == e.KeyCode.ToString())
                        {
                            tempCtl.Text = "";
                            tempCtl.Tag = Keys.None;
                        }
                    }
                     (sender as TextBox).Text = e.KeyCode.ToString();
                    (sender as TextBox).Tag = e.KeyValue;
                }
            }
        }

        private void labelbgColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();/*打开颜色对话框*/
            labelbgColor.BackColor = colorDialog1.Color;
        }

        private void Form_config_Load(object sender, EventArgs e)
        {
            config.LoadFromXmlFile();/*读取xml文件*/
            BlockArr bArr = config.blocksArr;
            /*读取砖块样式*/
            ListViewItem newItem = new ListViewItem();
            for (int i=0; i<bArr.lengh; i++)
            {
                newItem = bricklistView.Items.Add(bArr[i].GetCodeStr());
                newItem.SubItems.Add(bArr[i].GetColorStr());
            }
            /*读取键位*/
            textdown.Text = config.keyDown.ToString();
            textdown.Tag = config.keyDown;
            textright.Text = config.keyRight.ToString();
            textright.Tag = config.keyRight;
            textleft.Text = config.keyLeft.ToString();
            textleft.Tag = config.keyLeft;
            textdrop.Text = config.keyDrop.ToString();
            textdrop.Tag = config.keyDrop;
            textwise.Text = config.keyRotateWise.ToString();
            textwise.Tag = config.keyRotateWise;
            textAntiWise.Text = config.keyRotateAntiWise.ToString();
            textAntiWise.Tag = config.keyRotateAntiWise;
            /*读取环境设置*/
            textBoxHGrid.Text = config.HGridNum.ToString();
            textBoxVGrid.Text = config.VGridNum.ToString();
            textBoxGridPixel.Text = config.Pixel.ToString();
            labelbgColor.BackColor = config.bgColor;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            BlockArr bArr = new BlockArr();
            /*从listview中取出信息*/
           
            foreach (ListViewItem item in bricklistView.Items)
            {
                bArr.AddBlock(item.SubItems[0].Text, item.SubItems[1].Text);
            }
            config.bgColor = labelbgColor.BackColor;
            config.blocksArr = bArr;
            config.keyDown = (Keys)textdown.Tag;
            config.keyDrop = (Keys)textdrop.Tag;
            config.keyLeft = (Keys)textleft.Tag;
            config.keyRight = (Keys)textright.Tag;
            config.keyRotateAntiWise = (Keys)textAntiWise.Tag ;
            config.keyRotateWise = (Keys)textwise.Tag;
            config.Pixel = int.Parse(textBoxGridPixel.Text);
            config.VGridNum = int.Parse(textBoxVGrid.Text);
            config.HGridNum = int.Parse(textBoxHGrid.Text);
            config.SaveToXmlFile();
            MessageBox.Show("保存成功!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
