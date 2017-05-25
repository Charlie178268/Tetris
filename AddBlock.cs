using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class AddBlock
    {
        public BlockArr bstyleArr;/*存放砖块的样式信息*/
        public Color disColor;/*背景色*/
        public int rectPixel;/*单元格像素*/

        /// <summary>
        /// 在构造函数里读取xml里保存的所有砖块样式信息和背景颜色，单元格像素
        /// </summary>
        public AddBlock()
        {
            Config config = new Config();
            config.LoadFromXmlFile();
            bstyleArr = new BlockArr();
            bstyleArr = config.blocksArr;
            disColor = config.bgColor;
            rectPixel = config.Pixel;
        }

        /// <summary>
        /// 从砖块中随机抽取一个样式返回
        /// </summary>
        /// <returns></returns>
        public Block GetBlock()
        {
            Random rd= new Random();
            int rkey = rd.Next(0, bstyleArr.lengh);
            BitArray ba = bstyleArr[rkey].bCode;
            int bNum = 0;/*砖块样式中被填充的格子的个数*/
            foreach(bool b in ba)
            {
                if (b)
                {
                    bNum++;
                }
            }
            Point[] pArr = new Point[bNum];
            int k = 0;
            /*将0-24中是1的坐标通过换算转换成(-2,-2)这样的逻辑坐标赋给坐标数组*/
            for(int j=0; j<ba.Length; j++)
            {
                if (ba[j])
                {
                    pArr[k].X = j / 5 - 2;
                    pArr[k].Y = 2 - j % 5;
                    k++;
                }
            }
            return new Block(pArr, bstyleArr[rkey].bColor, disColor, rectPixel);
        }
    }
}
