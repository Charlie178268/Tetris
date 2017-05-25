using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Block
    {
        public Point[] bPosInfoArr;/*存放砖块组成信息的数组*/
        public int _xPos { get; set; }/*砖块中心点所在的x坐标*/
        public int _yPos { get; set; }/*砖块中心点所在的y坐标*/
        public Color _blockColor { get; set; }/*砖块颜色*/
        public Color disapperColor;/*消除砖块的颜色*/
        public int rectPix;/*每单元格的像素*/
        public Block() { }
        public Block(Point[] bia, Color bColor, Color disColor, int rp)
        {
            bPosInfoArr = bia;
            _blockColor = bColor;
            disapperColor = disColor;
            rectPix = rp;
        }
        /*提供像数组一样根据索引访问的方法*/
        public Point this[int index]
        {
            get
            {
                return bPosInfoArr[index];
            }
        }
        /*表示bPosInfoArr的长度*/
        public int Length
        {
            get {
                return bPosInfoArr.Length;
            }
        }
        /*顺时针旋转,x=y,y=-x*/
        public void RotateWise()
        {
            int t;
            for (int i=0; i<bPosInfoArr.Length; i++)
            {
                t = bPosInfoArr[i].X;
                bPosInfoArr[i].X = bPosInfoArr[i].Y;
                bPosInfoArr[i].Y = -t;
            }
        }
        /*逆时针旋转,x=-y,y=x*/
        public void RotateAntiWise()
        {
            int t;
            for (int i = 0; i < bPosInfoArr.Length; i++)
            {
                t = bPosInfoArr[i].X;
                bPosInfoArr[i].X = -bPosInfoArr[i].Y;
                bPosInfoArr[i].Y = t;
            }
        }
        /// <summary>
        /// 把一个类似(-1,-1)的坐标点转换成以左上角为0点的矩形区域，方便填充方块。
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Rectangle PointToRectange(Point p)
        {
            /*因为方块之间有间隙，所以要加1和减2*/
            return new Rectangle((p.X + _xPos) * rectPix + 1,
                                 (_yPos - p.Y) * rectPix + 1,
                                 rectPix - 2,
                                 rectPix - 2);
        }
        /// <summary>
        /// 在指定画板上绘制矩形，声明为虚函数是为了方便重写，以后可以画3d的方块等
        /// </summary>
        /// <param name="gp"></param>
        public virtual void Paint(Graphics gp)
        {
            SolidBrush sb = new SolidBrush(_blockColor);
            foreach (Point p in bPosInfoArr)
            {
                /*加入线程锁，是因为我们使用的定时器是一个多线程的，
                有可能导致同时使用Graphics，所以要加锁*/
                lock (gp)
                {
                    gp.FillRectangle(sb, PointToRectange(p));
                }
            }
        }
        /// <summary>
        /// 擦除方块，和绘制砖块不同的是填充的颜色是背景色
        /// </summary>
        /// <param name="gp"></param>
        public void Erase(Graphics gp)
        {
            SolidBrush sb = new SolidBrush(disapperColor);
            foreach(Point p in bPosInfoArr)
            {
                lock (gp)
                {
                    gp.FillRectangle(sb, PointToRectange(p));
                }
            }
        }
    }
}
