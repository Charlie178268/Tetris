using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Tetris
{
    class Palette
    {
        private int _width = 10;/*画板宽度*/
        private int _height = 15;/*画板高度*/
        private Color[,] coorArr;/*固定砖块数组*/
        private Color disColor;/*背景色*/
        private Graphics gpPalette;/*砖块活动画板*/
        private Graphics gpReady;/*下一个砖块样式画板*/
        private AddBlock addBlock;/*产生砖块*/
        private Block runBlock;/*正在活动的砖块*/
        private Block readyBlock;/*下一个砖块*/
        private int rectPixel;/*单元格像素*/

        private System.Timers.Timer timerBlock;/*控制方块下移的定时器*/
        private int timeSpan = 300;/*定时器的时间间隔*/

        public Palette(int x, int y, int pix, Color c, Graphics gpp, Graphics gpr)
        {
            _width = x;
            _height = y;
            disColor = c;
            gpPalette = gpp;
            gpReady = gpr;
            rectPixel = pix;
            coorArr = new Color[_width, _height];
        }

        public void Start()
        {
            /*画正在运行的砖块*/
            addBlock = new AddBlock();
            runBlock = addBlock.GetBlock();
            runBlock._xPos = _width / 2;
            /*处理砖块不顶格出现问题
              找到砖块格子的最大y坐标，然后把它赋给中心点坐标
            */
            int y = 0;
            for (int i=0; i<runBlock.Length; i++)
            {
                if (runBlock[i].Y > y)
                {
                    y = runBlock[i].Y;
                }
            }
            runBlock._yPos = y;
            gpPalette.Clear(disColor);
            runBlock.Paint(gpPalette);
            /*画准备出现的砖块*/
            Thread.Sleep(20);/*调用睡眠函数，防止间隔太短，随机数产生的一样*/
            readyBlock = addBlock.GetBlock();
            readyBlock._xPos = 2;/*中心点刚好是0、0点*/
            readyBlock._yPos = 2;
            gpReady.Clear(disColor);
            readyBlock.Paint(gpReady);

            /*初始化并启动定时器*/
            timerBlock = new System.Timers.Timer(timeSpan);
            timerBlock.Elapsed += new ElapsedEventHandler(OnTimeEvent);
            timerBlock.AutoReset = true;
            timerBlock.Start();
        }

        private void OnTimeEvent(object obj, ElapsedEventArgs e)
        {
            CheckAndOverBlock();
            MoveDown();
        }
        /// <summary>
        /// 砖块向下移动
        /// </summary>
        /// <returns></returns>
        public bool MoveDown()
        {
            int xPos = runBlock._xPos;
            int yPos = runBlock._yPos+1;
            for (int i=0; i<runBlock.Length; i++)
            {
                /*判断砖块是否到达最底部*/
                if (yPos-runBlock[i].Y > _height - 1)
                {
                    return false;
                }
                /*判断是否有砖块挡着*/
                if (!coorArr[xPos+runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                {
                    return false;
                }
            }
            runBlock.Erase(gpPalette);/*擦除原来的砖块*/
            runBlock._yPos++;
            runBlock.Paint(gpPalette);/*画新的砖块*/
            return true;
        }
        /// <summary>
        /// 砖块向左移动
        /// </summary>
        /// <returns></returns>
        public bool MoveLeft()
        {
            int xPos = runBlock._xPos-1;
            int yPos = runBlock._yPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                /*判断砖块是否到达最左边*/
                if (xPos + runBlock[i].X < 0)
                {
                    return false;
                }
                /*判断是否有砖块挡着*/
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                {
                    return false;
                }
            }
            runBlock.Erase(gpPalette);/*擦除原来的砖块*/
            runBlock._xPos--;
            runBlock.Paint(gpPalette);/*画新的砖块*/
            return true;
        }
        /// <summary>
        /// 向右移动
        /// </summary>
        /// <returns></returns>
        public bool MoveRight()
        {
            int xPos = runBlock._xPos + 1;
            int yPos = runBlock._yPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                /*判断砖块是否到达最右边*/
                if (xPos + runBlock[i].X > _width-1)
                {
                    return false;
                }
                /*判断是否有砖块挡着*/
                if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                {
                    return false;
                }
            }
            runBlock.Erase(gpPalette);/*擦除原来的砖块*/
            runBlock._xPos++;
            runBlock.Paint(gpPalette);/*画新的砖块*/
            return true;
        }
        /// <summary>
        /// 顺时针旋转
        /// </summary>
        /// <returns></returns>
        public bool RotateWise()
        {
            for (int i=0; i<runBlock.Length; i++)
            {
                /*换算旋转之后的砖块坐标，x=y,y=-x*/
                int x = runBlock._xPos + runBlock[i].Y;
                int y = runBlock._yPos + runBlock[i].X;
                /*判断左右边界*/
                if (x<0 || x > _width - 1)
                {
                    return false;
                }
                /*判断上下边界*/
                if (y<0 || y > _height - 1)
                {
                    return false;
                }
                /*判断是否有方块重合*/
                if (!coorArr[x, y].IsEmpty)
                {
                    return false;
                }
            }
            runBlock.Erase(gpPalette);/*擦除原来的砖块*/
            runBlock.RotateWise();
            runBlock.Paint(gpPalette);/*画新的砖块*/
            return true;
        }
        /// <summary>
        /// 逆时针旋转
        /// </summary>
        /// <returns></returns>
        public bool RotateAntiWise()
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                /*换算旋转之后的砖块坐标，x=-y,y=x*/
                int x = runBlock._xPos - runBlock[i].Y;
                int y = runBlock._yPos - runBlock[i].X;
                /*判断左右边界*/
                if (x < 0 || x > _width - 1)
                {
                    return false;
                }
                /*判断上下边界*/
                if (y < 0 || y > _height - 1)
                {
                    return false;
                }
                /*判断是否有方块重合*/
                if (!coorArr[x, y].IsEmpty)
                {
                    return false;
                }
            }
            runBlock.Erase(gpPalette);/*擦除原来的砖块*/
            runBlock.RotateAntiWise();
            runBlock.Paint(gpPalette);/*画新的砖块*/
            return true;
        }
        /*丢下砖块*/
        public void Drop()
        {
            timerBlock.Stop();
            while (MoveDown()) ;
            timerBlock.Start();
        }
        /// <summary>
        /// 画背景
        /// </summary>
        /// <param name="gp"></param>
        private void PaintBg(Graphics gp)
        {
            gp.Clear(Color.Black);/*首先清空画板*/
            for (int i=0; i<_height; i++)
            {
                for (int j=0; j<_width; j++)
                {
                    if (!coorArr[j, i].IsEmpty)
                    {
                        SolidBrush sb = new SolidBrush(coorArr[j, i]);
                        gp.FillRectangle(sb, j*rectPixel+1, i*rectPixel+1,
                                        rectPixel-2,rectPixel-2);
                    }
                }
            }
        }
        /// <summary>
        /// 重绘活动画板调用
        /// </summary>
        /// <param name="gp"></param>
        public void PaintPalette(Graphics gp)
        {
            PaintBg(gp);/*首先画固定的背景*/
            if (runBlock != null)
            {
                runBlock.Paint(gp);/*再画活动的砖块*/
            }
        }
        /// <summary>
        /// 重绘准备画板调用
        /// </summary>
        /// <param name="gp"></param>
        public void PaintReady(Graphics gp)
        {
            if (readyBlock != null)
            {
                readyBlock.Paint(gp);/*再画活动的砖块*/
            }
        }
        /// <summary>
        /// 检查砖块是否到底或者底部碰到其他砖块，如果是就把它写入背景里。
        /// </summary>
        public void CheckAndOverBlock()
        {
            bool over = false;
            for (int i=0; i<runBlock.Length; i++)
            {
                int x = runBlock._xPos + runBlock[i].X;
                int y = runBlock._yPos - runBlock[i].Y;
                /*到底*/
                if (y == _height - 1)
                {
                    over = true;
                    break;
                }
                /*底部碰到其他砖块*/
                if (!coorArr[x, y + 1].IsEmpty)
                {
                    over = true;
                    break;
                }
            }

            if (over)
            {
                /*给背景颜色数组赋值*/
                for (int i=0; i < runBlock.Length; i++)
                {
                    coorArr[runBlock._xPos + runBlock[i].X, runBlock._yPos - runBlock[i].Y] = runBlock._blockColor;
                }
                CheckAndDelGullRow();/*检查和消除满行*/
                /*产生新的砖块*/
                runBlock = readyBlock;
                runBlock._xPos = _width / 2;
                /*处理砖块不顶格出现问题
                  找到砖块格子的最大y坐标，然后把它赋给中心点坐标
                */
                int y = 0;
                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (runBlock[i].Y > y)
                    {
                        y = runBlock[i].Y;
                    }
                }
                runBlock._yPos = y;
                /*检查新产生的砖块所占用的地方是否已经有砖块，如果有，则游戏结束*/
                for (int i=0; i<runBlock.Length; i++)
                {
                    if (!coorArr[runBlock._xPos + runBlock[i].X, runBlock._yPos - runBlock[i].Y].IsEmpty)
                    {
                        /*游戏结束*/
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.Alignment = StringAlignment.Center;
                        gpPalette.DrawString("游戏结束,壮士请从头再来!",
                            new Font("微软雅黑", 25f),
                            new SolidBrush(Color.White),
                            new Rectangle(0, _height*rectPixel/2-100, _width*rectPixel, rectPixel*10));
                        timerBlock.Stop();
                        return;
                    }
                }
                runBlock.Paint(gpPalette);
                /*获取新的准备砖块*/
                readyBlock = addBlock.GetBlock();
                readyBlock._xPos = 2;/*中心点刚好是0、0点*/
                readyBlock._yPos = 2;
                gpReady.Clear(Color.Black);
                readyBlock.Paint(gpReady);
            }
        }
        /// <summary>
        /// 检查并删除满行
        /// </summary>
        private void CheckAndDelGullRow()
        {
            /*找出当前砖块所在行的范围*/
            int lowRow = runBlock._yPos - runBlock[0].Y;/*当前砖块所在y的最小值*/
            int highRow = lowRow;/*当前砖块所在y的最大值*/
            for (int i=1; i<runBlock.Length; i++)
            {
                int y = runBlock._yPos - runBlock[i].Y;/*砖块的y值*/
                if (y < lowRow)
                {
                    lowRow = y;
                }
                if (y > highRow)
                {
                    highRow = y;
                }
            }
            bool repaint = false;/*判断是否重画标志*/
            for (int i=lowRow; i<=highRow; i++)/*行循环*/
            {
                bool rowFull = true;
                for (int j=0; j<_width; j++)
                {
                    if (coorArr[j, i].IsEmpty)
                    {
                        rowFull = false;
                        break;
                    }
                }
                if (rowFull)/*如果有满行*/
                {
                    repaint = true;
                    /*消除一行，只需要把上一行的值赋给下一行，把第0行清空就行了*/
                    for (int k= i; k>0; k--)
                    {
                        for (int j=0; j<_width; j++)
                        {
                            coorArr[j, k] = coorArr[j, k - 1];
                        }
                        /*清空第0行*/
                        for (int j=0; j<_width; j++)
                        {
                            coorArr[j, 0] = Color.Empty;
                        }
                    }
                }
                if (repaint)
                {
                    PaintBg(gpPalette);
                }
            }
        }
        /// <summary>
        /// 暂停游戏
        /// </summary>
        public void PauseGame()
        {
            if (timerBlock.Enabled == true)
            {
                timerBlock.Enabled = false;
            }
        }
        /// <summary>
        /// 恢复游戏
        /// </summary>
        public void ResumeGame()
        {
            if (timerBlock.Enabled == false)
            {
                timerBlock.Enabled = true;
            }
        }
        /// <summary>
        /// 关闭游戏函数,实际上应该专门实现一个释放模式，这里为了代码方便，直接手动调用
        /// </summary>
        public void Close()
        {
            timerBlock.Close();/*关闭定时器*/
            gpPalette.Dispose();/*释放画布资源*/
            gpReady.Dispose();
        }
    }
}
