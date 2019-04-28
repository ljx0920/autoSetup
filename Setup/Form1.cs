using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Setup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.comboBox1.Items.Add("生产环境");
            this.comboBox1.Items.Add("测试环境");
            this.comboBox1.Items.Add("其他服务器");

            this.comboBox2.Items.Add("全功能");
            this.comboBox2.Items.Add("结构设计");
            this.comboBox2.Items.Add("三维设计");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Environment.UserName
            //System.Console.WriteLine("io:" + computerName);
            //envPath = "";
            //installPath = "";
            //runStyle = "";
            //envName = "ENV_";
            dealXML test = new dealXML();
            test.mapcontent.Clear();
            test.initTempPath();
            XmlDocument xmlDoc = new XmlDocument();
            //选择要加载解析的xml文档
            //xmlDoc.Load("skillinfo.txt");
            xmlDoc.LoadXml(File.ReadAllText("C:\\CATIA_Config.xml"));//传递一个字符串（xml格式的字符串）
            //得到根结点 <skills>
            XmlNode rootNode = xmlDoc.FirstChild;//获取第一个结点 
            XmlNodeList node = xmlDoc.ChildNodes;

            //得到根结点下面的子节点的集合 <skill>
            XmlNodeList skillNodeList = rootNode.ChildNodes;
            List<string> testlist = new List<string>();
            string role = comboBox2.Text;
            //XmlNode selectNode ;
            string selectServer = comboBox1.Text;
            
            foreach (XmlNode node1 in node) {
                if (null != node1.Attributes) {
                    if (selectServer.Equals(node1.Attributes["name"].Value)) {
                        test.getPackage(role, node1, testlist);
                        testlist.Add(test.CATDefaultInstalPath);
                        test.dealWithCAAPackage(testlist);
                        test.defatulDic();
                        test.dealConfig(node1);
                    }
                }
            }




            //testlist.Add("D:\\DS17\\CAADev\\MBD\\04FTA");
            //testlist.Add("D:\\DS17\\CAADev\\MBD\\01GL");


            //XmlNode configNode = node[1].ChildNodes[];
            string envPath = "";
            string envName = "";
            
            test.writeENV(test.envPath, test.envName);

            test.runCmd();
            System.Console.WriteLine("succ!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
