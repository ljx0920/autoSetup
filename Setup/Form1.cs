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
        
        public const string CATInstallPath = "CATInstallPath=";
        public const string CATDLLPath = "CATDLLPath=";
        public const string CATICPath = "CATICPath=";
        public const string CATCommandPath = "CATCommandPath=";
        public const string CATDictionaryPath = "CATDictionaryPath=";
        public const string CATDocView = "CATDocView=";
        public const string CATReffilesPath = "CATReffilesPath=";
        public const string CATFontPath = "CATFontPath=";
        public const string CATGalaxyPath = "CATGalaxyPath=";
        public const string CATGraphicPath = "CATGraphicPath=";
        public const string CATMsgCatalogPath = "CATMsgCatalogPath=";
        public const string CATFeatureCatalogPath = "CATFeatureCatalogPath=";
        public const string CATDefaultCollectionStandard = "CATDefaultCollectionStandard=";
        public const string CATKnowledgePath = "CATKnowledgePath=";
        public const string CATStartupPath = "CATStartupPath=";
        public const string CATW3ResourcesPath = "CATW3ResourcesPath=";
        public const string CATReconcilePath = "CATReconcilePath=";
        public const string CATReferenceSettingPath = "CATReferenceSettingPath=";
        public const string CATUserSettingPath = "CATUserSettingPath=";
        public const string CATCollectionStandard = "CATCollectionStandard=";
        public const string CATTemp = "CATTemp=";
        public const string CATErrorLog = "CATErrorLog=";
        public const string CATReport = "CATReport=";
        public const string CATDisciplinePath = "CATDisciplinePath=";
        public const string USER_HOME = "USER_HOME=";
        public const string JAVA_HOME = "JAVA_HOME=";
        public const string CLASSPATH_JDBC = "CLASSPATH_JDBC=";
        public const string CLASSPATH = "CLASSPATH=";
        public const string PATH = "PATH=";

        public const string CATDefaultInstalPath = "D:\\DS17\\B419";

        public  string tempCATInstallPath = "";
        public  string tempCATDLLPath = "";
        public  string tempCATICPath = "";
        public  string tempCATCommandPath = "";
        public  string tempCATDictionaryPath = "";
        public  string tempCATDocView = "";
        public  string tempCATReffilesPath = "";
        public  string tempCATFontPath = "";
        public  string tempCATGalaxyPath = "";
        public  string tempCATGraphicPath = "";
        public  string tempCATMsgCatalogPath = "";
        public  string tempCATFeatureCatalogPath = "";
        public  string tempCATDefaultCollectionStandard = "";
        public  string tempCATKnowledgePath = "";
        public  string tempCATStartupPath = "";
        public  string tempCATW3ResourcesPath = "";
        public  string tempCATReconcilePath = "";
        public  string tempCATReferenceSettingPath = "";
        public  string tempCATUserSettingPath = "";
        public  string tempCATCollectionStandard = "";
        public  string tempCATTemp = "";
        public  string tempCATErrorLog = "";
        public  string tempCATReport = "";
        public  string tempCATDisciplinePath = "";
        public  string tempUSER_HOME = "";
        public  string tempJAVA_HOME = "";
        public  string tempCLASSPATH_JDBC = "";
        public  string tempCLASSPATH = "";
        public  string tempPATH = "";
        Dictionary<string, string> mapcontent = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            
            testlist.Add("D:\\DS17\\CAADev\\MBD\\04FTA");
            testlist.Add("D:\\DS17\\CAADev\\MBD\\01GL");
            testlist.Add(CATDefaultInstalPath);
            dealWithCAAPackage(testlist);

            defatulDic();
            writeENV("C:\\", "ENVTT");

            System.Console.WriteLine("succ!");
        }
        private void defatulDic() {
            mapcontent[CATInstallPath] = tempCATInstallPath;
            mapcontent[CATDLLPath] = tempCATDLLPath;
            mapcontent[CATICPath] = tempCATICPath;
            mapcontent[CATCommandPath] = tempCATCommandPath;
            mapcontent[CATDictionaryPath] = tempCATDictionaryPath;
            mapcontent[CATDocView] = tempCATDocView;
            mapcontent[CATReffilesPath] = tempCATReffilesPath;
            mapcontent[CATFontPath] = tempCATFontPath;
            mapcontent[CATGalaxyPath] = tempCATGalaxyPath;
            mapcontent[CATGraphicPath] = tempCATGraphicPath;
            mapcontent[CATMsgCatalogPath] = tempCATMsgCatalogPath;
            mapcontent[CATFeatureCatalogPath] = tempCATFeatureCatalogPath;
            mapcontent[CATDefaultCollectionStandard] = tempCATDefaultCollectionStandard;
            mapcontent[CATKnowledgePath] = tempCATKnowledgePath;
            mapcontent[CATStartupPath] = tempCATStartupPath;
            mapcontent[CATW3ResourcesPath] = tempCATW3ResourcesPath;
            mapcontent[CATReconcilePath] = tempCATReconcilePath;
            mapcontent[CATReferenceSettingPath] = tempCATReferenceSettingPath;
            mapcontent[CATUserSettingPath] = tempCATUserSettingPath;
            mapcontent[CATCollectionStandard] = tempCATCollectionStandard;
            mapcontent[CATTemp] = tempCATTemp;
            mapcontent[CATErrorLog] = tempCATErrorLog;
            mapcontent[CATReport] = tempCATReport;
            mapcontent[CATDisciplinePath] = tempCATDisciplinePath;
            mapcontent[USER_HOME] = tempUSER_HOME;
            mapcontent[JAVA_HOME] = tempJAVA_HOME;
            mapcontent[CLASSPATH_JDBC] = tempCLASSPATH_JDBC;
            mapcontent[CLASSPATH] = tempCLASSPATH;
            mapcontent[PATH] = tempPATH;

        }
        private void writeENV(string path, string name) {
            if ("".Equals(path) || "".Equals(name)) {
                System.Console.WriteLine("writeENV::the name or the path is empty!");
                return;
            }
            string fullpath = path + "\\" + name+".txt";
            StreamWriter sW1 = new StreamWriter(fullpath);
            //初始化env的文件头
            sW1.WriteLine("!----------------------------------------------------------");
            sW1.WriteLine("!   DASSAULT SYSTEMES  -  ENVIRONMENT FILE");
            sW1.WriteLine("!----------------------------------------------------------");
            sW1.WriteLine("! MODE : Global");
            sW1.WriteLine("! PRODUCT LINE : ");
            sW1.WriteLine("! TMSTMP : 1555919998");
            sW1.WriteLine("! ARGS : -a global ");
            sW1.WriteLine("! MARKETING VERSION : ");
            sW1.WriteLine("!----------------------------------------------------------");
            sW1.WriteLine(" ");
            //sW1.WriteLine("HAHAH");
            dealWithFixDic("SWIEEMBDXmlSettingPath", "D:\\DS17\\CAADev\\MBD\\01GL\\SWIEEMBDXmlSetting.xml", "new", "0");
            dealWithFixDic("CNEXTOUTPUT", "console", "new", "0");
            dealWithFixDic("CAAResourcePath", "D:\\DS17\\CAADev\\MEE\\01WEIBO\\config_file", "new", "0");
            dealWithFixDic("CETCFASConfig", "D:\\DS17\\CAADev\\MBD\\05FDE\\win_b64\\resources\\graphic", "new", "0");
            dealWithFixDic("DSLS_CONFIG", "D:\\DS17\\Licenses\\DSLicSrv.txt", "new", "0");

            foreach (var item in mapcontent) {
                sW1.WriteLine(item.Key + item.Value);
            }
                sW1.Close();

        }
        
        private void dealWithCAAPackage(List<string> input) {
            if (0 == input.Count) {
                System.Console.WriteLine("dealWithCAAPackage::the size of input is 0");
                return ;
            }

            for (int i = 0; i < input.Count; i++) {
                dealWithCATInstallPath(input[i]);
                dealWithCATDLLPath(input[i]);
                dealWithCATICPath(input[i]);
                dealWithCATCommandPath(input[i]);
                dealWithCATDictionaryPath(input[i]);
                dealWithCATDocView(input[i]);
                dealWithCATReffilesPath(input[i]);
                dealWithCATFontPath(input[i]);
                dealWithCATGalaxyPath(input[i]);
                dealWithCATGraphicPath(input[i]);
                dealWithCATMsgCatalogPath(input[i]);
                dealWithCATFeatureCatalogPath(input[i]);
                dealWithCATDefaultCollectionStandard(input[i]);
                dealWithCATKnowledgePath(input[i]);
                dealWithCATStartupPath(input[i]);
                dealWithCATW3ResourcesPath(input[i]);
                dealWithCATReferenceSettingPath(input[i]);
                dealWithPATH(input[i]);
            }

        }
        private void dealWithFixDic(string name, string value, string mode, string loc="0") {
            if ("".Equals(name) || "".Equals(value) || "".Equals(mode)) {
                System.Console.WriteLine("dealWithFixDic::some input is empty!" );
                return;
            }
            value += ";";
            if ("add".Equals(mode))
            {
                name += "=";
                if ("1".Equals(loc))
                {
                   
                    mapcontent[name] += value;
                }
                else if ("0".Equals(loc))
                {
                    mapcontent[name] = value + mapcontent[name];
                }
                else {
                    System.Console.WriteLine("dealWithFixDic::loc input is error!");
                    System.Console.WriteLine("dealWithFixDic::the name is: "+name);
                    return;
                }
            }
            else if ("modify".Equals(mode))
            {
                mapcontent[name] = value;
            }
            else if ("new".Equals(mode))
            {
                name += "=";
                mapcontent[name] = value;
            }
            else {
                System.Console.WriteLine("dealWithFixDic::mode input is error!");
                System.Console.WriteLine("dealWithFixDic::the name is: " + name);
                return;
            }
        }
        private void dealWithCATInstallPath(string input) {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATInstallPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATInstallPath))
            {
                tempCATInstallPath = input + "\\win_b64;";
            }
            else {
                tempCATInstallPath += input;
                tempCATInstallPath+= "\\win_b64;";
            }
            
            
        }
        private void dealWithCATDLLPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATDLLPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATDLLPath))
            {
                tempCATDLLPath = input + "\\win_b64\\code\\bin;";
            }
            else {
                tempCATDLLPath += input;
                tempCATDLLPath += "\\win_b64\\code\\bin;";
            }
            
            
        }
        private void dealWithCATICPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATICPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATICPath))
            {
                tempCATICPath = input + "\\win_b64\\code\\productIC;";
            }
            else {
                tempCATICPath += input;
                tempCATICPath += "\\win_b64\\code\\productIC;";
            }
            

        }
        private void dealWithCATCommandPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCommandPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATCommandPath))
            {
                tempCATCommandPath = input + "\\win_b64\\code\\command;";
            }
            else {
                tempCATCommandPath += input;
                tempCATCommandPath +=  "\\win_b64\\code\\command;";
            }
            
        }
        private void dealWithCATDictionaryPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATDictionaryPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATDictionaryPath))
            {
                tempCATDictionaryPath = input + "\\win_b64\\code\\dictionary;";
            }
            else {
                tempCATDictionaryPath += input;
                tempCATDictionaryPath+= "\\win_b64\\code\\dictionary;";
            }
            
        }
        private void dealWithCATDocView(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATDictionaryPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATDocView))
            {
                tempCATDocView = input + "\\win_b64\\code\\dictionary;";
            }
            else {
                tempCATDocView += input;
                tempCATDocView += "\\win_b64\\code\\dictionary;";
            }
            
        }
        private void dealWithCATReffilesPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATReffilesPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATReffilesPath))
            {
                tempCATReffilesPath = input + "\\win_b64\\reffiles;";
            }
            else {
                tempCATReffilesPath += input;
                tempCATReffilesPath+= "\\win_b64\\reffiles;";
            }
            

        }
        private void dealWithCATFontPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATFontPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATFontPath))
            {
                tempCATFontPath = input + "\\win_b64\\resources\\galaxy;";
            }
            else {
                tempCATFontPath += input;
                tempCATFontPath += "\\win_b64\\resources\\galaxy;";
            }

        }
        private void dealWithCATGalaxyPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATGalaxyPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATGalaxyPath))
            {
                tempCATGalaxyPath = input + "\\win_b64\\resources\\galaxy;";
            }
            else {
                tempCATGalaxyPath+= "\\win_b64\\resources\\galaxy;";
            }

        }
        private void dealWithCATGraphicPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATGraphicPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATGraphicPath))
            {
                tempCATGraphicPath = input + "\\win_b64\\resources\\AppDescription;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic\\icons;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic\\figures;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic\\splashscreens;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic\\symbols;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic\\textures;";
            }
            else {
                tempCATGraphicPath += input;
                tempCATGraphicPath+= "\\win_b64\\resources\\AppDescription;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic\\icons;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic\\figures;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic\\splashscreens;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic\\symbols;";
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\graphic\\textures;";

            }
            


        }
        private void dealWithCATMsgCatalogPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATMsgCatalogPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATMsgCatalogPath))
            {
                tempCATMsgCatalogPath = input + "\\win_b64\\resources\\msgcatalog;";
            }
            else {
                tempCATMsgCatalogPath += input;
                tempCATMsgCatalogPath += "\\win_b64\\resources\\msgcatalog;";
            }
            

        }
        private void dealWithCATFeatureCatalogPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATFeatureCatalogPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATFeatureCatalogPath))
            {
                tempCATFeatureCatalogPath = input + "\\win_b64\\resources\\featurecatalog;";
            }
            else {
                tempCATFeatureCatalogPath += input;
                tempCATFeatureCatalogPath+= "\\win_b64\\resources\\featurecatalog;";
            }
        }
            

        
        private void dealWithCATDefaultCollectionStandard(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATDefaultCollectionStandard::the size of input is null");
                return;
            }
            if ("".Equals(tempCATDefaultCollectionStandard))
            {
                tempCATDefaultCollectionStandard = input + "\\win_b64\\resources\\standard;";
            }
            else {
                tempCATDefaultCollectionStandard += input;
                tempCATDefaultCollectionStandard+= "\\win_b64\\resources\\standard;";
            }
            

        }
        private void dealWithCATKnowledgePath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATKnowledgePath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATKnowledgePath)) {
                tempCATKnowledgePath = input + "\\win_b64\\resources\\knowledge;";
            }
            else {
                tempCATKnowledgePath += input;
                tempCATKnowledgePath+= "\\win_b64\\resources\\knowledge;";
            }

        }
        private void dealWithCATStartupPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATStartupPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATStartupPath))
            {
                tempCATStartupPath = input + "\\win_b64\\startup;";
            }
            else {
                tempCATStartupPath += input;
                tempCATStartupPath+= "\\win_b64\\startup;";
            }
           

        }
        private void dealWithCATW3ResourcesPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATW3ResourcesPath::the size of input is null");
                return;
            }

            tempCATW3ResourcesPath = input + "\\win_b64\\docs;";

        }
        private void dealWithCATReconcilePath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATReconcilePath::the size of input is null");
                return;
            }

            //tempCATReconcilePath = input + "\\win_b64\\docs;";

        }
        private void dealWithCATReferenceSettingPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATReferenceSettingPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATReferenceSettingPath)) {
                tempCATReferenceSettingPath = input + "\\win_b64\\startup\\Settings;";
            }else{
                tempCATReferenceSettingPath += input;
                tempCATReferenceSettingPath+= "\\win_b64\\startup\\Settings;";
            }
            

        }
        private void dealWithCATUserSettingPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATUserSettingPath::the size of input is null");
                return;
            }

            //tempCATUserSettingPath = input + "\\win_b64\\startup\\Settings;";

        }
        private void dealWithCATCollectionStandard(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCollectionStandard::the size of input is null");
                return;
            }

            //tempCATUserSettingPath = input + "\\win_b64\\startup\\Settings;";

        }
        private void dealWithCATTemp(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCollectionStandard::the size of input is null");
                return;
            }

            //tempCATUserSettingPath = input + "\\win_b64\\startup\\Settings;";

        }
        private void dealWithCATErrorLog(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCollectionStandard::the size of input is null");
                return;
            }

            //tempCATUserSettingPath = input + "\\win_b64\\startup\\Settings;";

        }
        private void dealWithCATReport(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCollectionStandard::the size of input is null");
                return;
            }

            //tempCATUserSettingPath = input + "\\win_b64\\startup\\Settings;";

        }
        private void dealWithCATDisciplinePath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCollectionStandard::the size of input is null");
                return;
            }

            //tempCATUserSettingPath = input + "\\win_b64\\startup\\Settings;";

        }
        private void dealWithUSER_HOME(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCollectionStandard::the size of input is null");
                return;
            }

            //tempCATUserSettingPath = input + "\\win_b64\\startup\\Settings;";

        }
        private void dealWithJAVA_HOME(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCollectionStandard::the size of input is null");
                return;
            }

            //tempCATUserSettingPath = input + "\\win_b64\\startup\\Settings;";

        }
        private void dealWithCLASSPATH_JDBC(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCollectionStandard::the size of input is null");
                return;
            }

            //tempCATUserSettingPath = input + "\\win_b64\\startup\\Settings;";

        }
        private void dealWithCLASSPATH(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCollectionStandard::the size of input is null");
                return;
            }

            //tempCATUserSettingPath = input + "\\win_b64\\startup\\Settings;";

        }
        private void dealWithPATH(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATCollectionStandard::the size of input is null");
                return;
            }
            if ("".Equals(tempPATH))
            {
                tempPATH = input + "\\win_b64\\code\\bin;";
                tempPATH += input;
                tempPATH += "\\win_b64\\code\\command;";
            }
            else {
                tempPATH += input;
                tempPATH += "\\win_b64\\code\\bin;";
                tempPATH += input;
                tempPATH += "\\win_b64\\code\\command;";
            }
            
            
        }
    }
}
