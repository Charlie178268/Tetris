using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Tetris
{
    class Config
    {
        public Keys keyDown { get; set; }
        public Keys keyDrop { get; set; }
        public Keys keyLeft { get; set; }
        public Keys keyRight{ get; set; }
        public Keys keyRotateWise { get; set; }
        public Keys keyRotateAntiWise { get; set; }
        public Color bgColor { get; set; }
        private int _hGridNum;
        private int _vGridNum;
        private int _pixel;
        public int HGridNum
        {
            get { return _hGridNum; }
            set
            {
                if (value>=15 && value <= 50)
                {
                    _hGridNum = value;
                }
            }
        }
        public int VGridNum
        {
            get { return _vGridNum; }
            set
            {
                if (value >= 10 && value <= 50)
                {
                    _vGridNum = value;
                }
            }
        }
        public int Pixel
        {
            get { return _pixel; }
            set
            {
                if (value>=10 && value <= 30)
                {
                    _pixel = value;
                }
            }
        }
        public BlockArr blocksArr = new BlockArr();/*砖块集合*/
        /// <summary>
        /// 从xml读取信息
        /// </summary>
        public void LoadFromXmlFile()
        {
            XmlTextReader reader;
            if (File.Exists("GameSet.xml"))
            {
                /*优先读取外部的xml文件*/
                reader = new XmlTextReader("GameSet.xml");
            }
            else
            {
                /*如果外部的xml文件不存在，则从嵌入资源内读取xml*/
                Assembly asm = Assembly.GetExecutingAssembly();/*获取嵌入式程序集*/
                Stream sm = asm.GetManifestResourceStream("Tetris.GameSet.xml");/*找到xml文件并以此创建流*/
                reader = new XmlTextReader(sm);     
            }
            string key = "";
            try
            {
                while (reader.Read())/*读到文件末尾结束*/
                {
                    /*判断如果当前节点的类型，如果是枚举的节点类型(成对出现)*/
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.Name)
                        {
                            case "Code":
                                key = reader.ReadElementContentAsString().Trim();  
                                blocksArr.AddBlock(key, "");
                                break;
                            case "Color":
                                blocksArr[key] = reader.ReadElementContentAsString().Trim();
                                break;
                            case "KeyDown":
                                keyDown = (Keys)Convert.ToInt32(reader.ReadElementContentAsString().Trim());
                                break;
                            case "KeyLeft":
                                keyLeft = (Keys)Convert.ToInt32(reader.ReadElementContentAsString().Trim());
                                break;
                            case "KeyRight":
                                keyRight = (Keys)Convert.ToInt32(reader.ReadElementContentAsString().Trim());
                                break;
                            case "KeyDrop":
                                keyDrop = (Keys)Convert.ToInt32(reader.ReadElementContentAsString().Trim());
                                break;
                            case "KeyRotateWise":
                                keyRotateWise = (Keys)Convert.ToInt32(reader.ReadElementContentAsString().Trim());
                                break;
                            case "KeyRotateAntiWise":
                                keyRotateAntiWise = (Keys)Convert.ToInt32(reader.ReadElementContentAsString().Trim());
                                break;
                            case "HGridNum":
                                _hGridNum = Convert.ToInt32(reader.ReadElementContentAsString().Trim());
                                break;
                            case "VGridNum":
                                _vGridNum = Convert.ToInt32(reader.ReadElementContentAsString().Trim());
                                break;
                            case "GridPixel":
                                _pixel = Convert.ToInt32(reader.ReadElementContentAsString().Trim());
                                break;
                            case "BgColor":
                                bgColor = Color.FromArgb(Convert.ToInt32(reader.ReadElementContentAsString().Trim()));
                                break;
                        }
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
        /// <summary>
        /// 保存信息到xml文件中
        /// </summary>
        public void SaveToXmlFile()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Block></Block>");/*将根节点写入xml文档*/
            XmlNode root = doc.SelectSingleNode("Block");
            /*写砖块信息*/
            for (int i=0; i<blocksArr.lengh; i++)
            {
                XmlElement xelType = doc.CreateElement("Type");
                XmlElement xelCode = doc.CreateElement("Code");
                XmlElement xelColor = doc.CreateElement("Color");
                xelType.AppendChild(xelCode);
                xelType.AppendChild(xelColor);
                xelCode.InnerText = blocksArr[i].GetCodeStr();
                xelColor.InnerText = blocksArr[i].GetColorStr();
                root.AppendChild(xelType);
            }
            /*保存键位*/
            XmlElement xelKey = doc.CreateElement("Key");
            XmlElement xelKeyDown = doc.CreateElement("KeyDown");
            xelKeyDown.InnerText = Convert.ToInt32(keyDown).ToString();
            xelKey.AppendChild(xelKeyDown);

            XmlElement xelKeyLeft = doc.CreateElement("KeyLeft");
            xelKeyLeft.InnerText = Convert.ToInt32(keyLeft).ToString();
            xelKey.AppendChild(xelKeyLeft);

            XmlElement xelKeyRight = doc.CreateElement("KeyRight");
            xelKeyRight.InnerText = Convert.ToInt32(keyRight).ToString();
            xelKey.AppendChild(xelKeyRight);

            XmlElement xelKeyDrop = doc.CreateElement("KeyDrop");
            xelKeyDrop.InnerText = Convert.ToInt32(keyDrop).ToString();
            xelKey.AppendChild(xelKeyDrop);

            XmlElement xelKeyRotateWise = doc.CreateElement("KeyRotateWise");
            xelKeyRotateWise.InnerText = Convert.ToInt32(keyRotateWise).ToString();
            xelKey.AppendChild(xelKeyRotateWise);

            XmlElement xelKeyRotateAntiWise = doc.CreateElement("KeyRotateAntiWise");
            xelKeyRotateAntiWise.InnerText = Convert.ToInt32(keyRotateAntiWise).ToString();
            xelKey.AppendChild(xelKeyRotateAntiWise);

            root.AppendChild(xelKey);
            /*保存环境信息*/
            XmlElement xelEnvment = doc.CreateElement("Envment");
            XmlElement xelHGridNum = doc.CreateElement("HGridNum");
            xelHGridNum.InnerText = _hGridNum.ToString();
            xelEnvment.AppendChild(xelHGridNum);

            XmlElement xelVGridNum = doc.CreateElement("VGridNum");
            xelVGridNum.InnerText = _vGridNum.ToString();
            xelEnvment.AppendChild(xelVGridNum);

            XmlElement xelGridPixel = doc.CreateElement("GridPixel");
            xelGridPixel.InnerText = _pixel.ToString();
            xelEnvment.AppendChild(xelGridPixel);

            XmlElement xelBgColor = doc.CreateElement("BgColor");
            xelBgColor.InnerText = bgColor.ToArgb().ToString();
            xelEnvment.AppendChild(xelBgColor);

            root.AppendChild(xelEnvment);

            doc.Save("GameSet.xml");
        }
    }
}
