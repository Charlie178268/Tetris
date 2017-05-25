using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class BlockInfo
    {
        public BitArray bCode
        {
            get;
            set;
        }
        public Color bColor
        {
            get;
            set;
        }
        /// <summary>
        /// 返回砖块形状信息的字符串
        /// </summary>
        /// <returns></returns>
        public string GetCodeStr()
        {
            StringBuilder sb = new StringBuilder(25);
            foreach (bool i in bCode)
            {
                sb.Append(i?'1':'0');
            }
            return sb.ToString();
        }
        public string GetColorStr()
        {
            return Convert.ToString(bColor.ToArgb());
        }
    }
}
