using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    class BlockArr
    {
        private ArrayList blkArr = new ArrayList();/*保存砖块*/
        /*保存砖块长度*/
        public int lengh
        {
            get;
            private set;
        }
        /*根据下标返回BlockInfo信息*/
        public BlockInfo this[int index]
        {
            get
            {
                return (BlockInfo)blkArr[index];
            }
        }
        /*根据Block code给相应的砖块设置颜色,索引器，code是参数，value是值*/
        public string this[string code]
        {
            set
            {
                /*如果颜色值为空，直接返回*/
                if (value == "")
                {
                    return;
                }
                for (int i=0; i < blkArr.Count; i++)
                {
                    if (((BlockInfo)blkArr[i]).GetCodeStr() == code)
                    {
                        /*如果所设置的颜色不属于Color类型，引发异常*/
                        try
                        {
                            ((BlockInfo)blkArr[i]).bColor = Color.FromArgb(Convert.ToInt32(value));
                        }
                        catch(System.FormatException)
                        {
                            MessageBox.Show("颜色信息异常!请删除xml文件，并重新生成","异常信息",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 把字符串(砖块code)装换为BitArray
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private BitArray StrToBitArr(string str)
        {
            if (str.Length != 25)
            {
                throw new System.FormatException("砖块样式信息不合法!请删除xml文件并重新生成!");
            }
            BitArray ba = new BitArray(25);
            for (int i=0; i<25; i++)
            {
                ba[i] = (str[i] == '1') ? true : false;
            }
            return ba;
        }
        /// <summary>
        /// 添加一个砖块信息
        /// </summary>
        /// <param name="ba"></param>
        /// <param name="c"></param>
        public void AddBlock(BitArray ba, Color c)
        {
            if (ba.Length != 25)
            {
                throw new System.FormatException("砖块样式信息不合法!请删除xml文件并重新生成!");
            }
            BlockInfo blk = new BlockInfo();
            blk.bCode = ba;
            blk.bColor = c;
            blkArr.Add(blk);
            lengh++;
        }
        /// <summary>
        /// 添加一个砖块信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="c"></param>
        public void AddBlock(string code, string c)
        {
            if (code.Length != 25)
            {
                throw new System.FormatException("砖块样式信息不合法!请删除xml文件并重新生成!");
            }
            Color cl;
            if (!String.IsNullOrEmpty(c))
            {
                cl = Color.FromArgb(Convert.ToInt32(c));
            }
            else
            {
                cl = Color.Empty;/*颜色是空的*/
            }
            BlockInfo blk = new BlockInfo();
            blk.bCode = StrToBitArr(code);
            blk.bColor = cl;
            blkArr.Add(blk);
            lengh++;
        }
    }
}
