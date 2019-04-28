using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Setup
{
    class dealXML
    {
        //存放路径变量
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

        //安装路径
        public string CATDefaultInstalPath = "D:\\DS17\\B419";

        //存放路径值
        public string tempCATInstallPath = "";
        public string tempCATDLLPath = "";
        public string tempCATICPath = "";
        public string tempCATCommandPath = "";
        public string tempCATDictionaryPath = "";
        public string tempCATDocView = "";
        public string tempCATReffilesPath = "";
        public string tempCATFontPath = "";
        public string tempCATGalaxyPath = "";
        public string tempCATGraphicPath = "";
        public string tempCATMsgCatalogPath = "";
        public string tempCATFeatureCatalogPath = "";
        public string tempCATDefaultCollectionStandard = "";
        public string tempCATKnowledgePath = "";
        public string tempCATStartupPath = "";
        public string tempCATW3ResourcesPath = "";
        public string tempCATReconcilePath = "";
        public string tempCATReferenceSettingPath = "";
        public string tempCATUserSettingPath = "";
        public string tempCATCollectionStandard = "";
        public string tempCATTemp = "";
        public string tempCATErrorLog = "";
        public string tempCATReport = "";
        public string tempCATDisciplinePath = "";
        public string tempUSER_HOME = "";
        public string tempJAVA_HOME = "";
        public string tempCLASSPATH_JDBC = "";
        public string tempCLASSPATH = "";
        public string tempPATH = "";

        public Dictionary<string, string> mapcontent = new Dictionary<string, string>();

        //env路径
        public string envPath = "";
        //env文件名,形式以ENV_开头
        public string envName = "ENV_";
        //安装路径，与CATDefaultInstalPath什么关系
        string installPath = "";
        //执行命令的参数
        string runStyle = "";
        //计算机用户登录名，用于license文件
        private string loginName = System.Environment.UserName;
        //计算机名称，用于license文件
        private string computerName = System.Environment.MachineName;


            /*
         * @author:ljx
         * @descripiton:处理License节点，首先写入配置文件，然后查询是否存在lic文件及其内容是否正确。
         * @input:node 根节点
         * @return:
         * @tip：未完成
         */
        private void dealwithLic(XmlNode node)
        {
            XmlNodeList skillNodeList = node.ChildNodes;
            foreach (XmlNode item in skillNodeList)
            {
                if ("License".Equals(item.Name))
                {
                    XmlNodeList subSkillNodeList = item.ChildNodes;
                    foreach (XmlNode item1 in subSkillNodeList)
                    {
                        if (null != item1.Attributes)
                        {
                            string name = item1.Attributes["name"].Value + "=";
                            string path = item1.Attributes["value"].Value;
                            dealWithFixDic(name, path, item1.Attributes["mode"].Value, item1.Attributes["location"].Value);
                            //StreamReader sr1 = new StreamReader(path);
                            //String test = sr1.ReadLine();
                            //string path = "C:\\ENV1.txt";
                            if (System.IO.File.Exists(path))
                            {
                                StreamReader sr1 = new StreamReader(path);
                                String test = sr1.ReadLine();
                                //string line = sr.ReadLine();
                                while (test != null)
                                {
                                    string[] licInfo = test.Split(' ');
                                    if (loginName.Equals(test))
                                    {
                                        break;
                                    }
                                }


                            }
                            else
                            {
                                StreamWriter sW1 = new StreamWriter(path);
                                sW1.WriteLine("test");
                                sW1.Close();
                            }

                        }
                    }

                }
            }
        }

        /*
     * @authonr: ljx
     * @description:根据envpath,envname,installpaty,runstyle生成命令并通过cmd运行,
     * @input:运行的命令行字符串
     * @return:
     */
        public void runCmd()
        {
            if ("".Equals(installPath) || "".Equals(envPath))
            {
                System.Console.WriteLine("runCmd::the installPath or envPath is empty!");
                return;
            }
            //string str = Console.ReadLine();
            string commond = installPath + " -run \"3DEXPERIENCE\" -env " + envName + " -direnv " + "\"" + envPath + "\"" + " -" + runStyle;
            System.Console.WriteLine("com:" + commond);
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(commond + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令



            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();


            Console.WriteLine(output);
        }


        /*
         * @autor:ljx
         * @description:将路径内容写进mapcontent中
         * @input:
         * @return:
         */
        public void defatulDic()
        {
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

        /*
        * @author:ljx
        * @description:初始化临时路径
        * @input:
        * @return;
        */
        public void initTempPath()
        {
            tempCATInstallPath = "";
            tempCATDLLPath = "";
            tempCATICPath = "";
            tempCATCommandPath = "";
            tempCATDictionaryPath = "";
            tempCATDocView = "";
            tempCATReffilesPath = "";
            tempCATFontPath = "";
            tempCATGalaxyPath = "";
            tempCATGraphicPath = "";
            tempCATMsgCatalogPath = "";
            tempCATFeatureCatalogPath = "";
            tempCATDefaultCollectionStandard = "";
            tempCATKnowledgePath = "";
            tempCATStartupPath = "";
            tempCATW3ResourcesPath = "";
            tempCATReconcilePath = "";
            tempCATReferenceSettingPath = "";
            tempCATUserSettingPath = "";
            tempCATCollectionStandard = "";
            tempCATTemp = "";
            tempCATErrorLog = "";
            tempCATReport = "";
            tempCATDisciplinePath = "";
            tempUSER_HOME = "";
            tempJAVA_HOME = "";
            tempCLASSPATH_JDBC = "";
            tempCLASSPATH = "";
            tempPATH = "";
        }
        /*
         * @author:ljx
         * @description:从xml中获取config节点信息，并调用dealWithFixDic更新mapcontent内容
         * @input:
         * @return:
         */
        public void dealConfig(XmlNode node)
        {
            //得到根结点下面的子节点的集合 <skill>
            XmlNodeList skillNodeList = node.ChildNodes;
            foreach (XmlNode item in skillNodeList)
            {
                if ("config".Equals(item.Name))
                {
                    XmlNodeList subSkillNodeList = item.ChildNodes;
                    foreach (XmlNode item1 in subSkillNodeList)
                    {
                        if (null != item1.Attributes)
                        {
                            dealWithFixDic(item1.Attributes["name"].Value, item1.Attributes["value"].Value, item1.Attributes["mode"].Value, item1.Attributes["location"].Value);
                        }
                    }

                }
            }
        }

        /*
         * @author: ljx
         * @description:根据mapcontent写env.txt
         * @input:
         *  path:env.txt的存放路径
         *  name:name
         * @return:
         * @tip:
         *  1、采用强制写策略，每次都把旧的env删除，重新写
         *  2、path和name是不是可以从xml直接获取，可以的话，输入不需要。
         */
        public void writeENV(string path, string name)
        {
            if ("".Equals(path) || "ENV_".Equals(name))
            {
                System.Console.WriteLine("writeENV::the name or the path is empty!");
                return;
            }
            string fullpath = path + "\\" + name + ".txt";
            //测试用的路径
            fullpath = "C:\\ENV.txt";
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

            //dealWithFixDic("SWIEEMBDXmlSettingPath", "D:\\DS17\\CAADev\\MBD\\01GL\\SWIEEMBDXmlSetting.xml", "new", "0");
            //dealWithFixDic("CNEXTOUTPUT", "console", "new", "0");
            //dealWithFixDic("CAAResourcePath", "D:\\DS17\\CAADev\\MEE\\01WEIBO\\config_file", "new", "0");
            //("CETCFASConfig", "D:\\DS17\\CAADev\\MBD\\05FDE\\win_b64\\resources\\graphic", "new", "0");
            //dealWithFixDic("DSLS_CONFIG", "D:\\DS17\\Licenses\\DSLicSrv.txt", "new", "0");
            foreach (var item in mapcontent)
            {
                sW1.WriteLine(item.Key + item.Value);
            }



            sW1.Close();

        }

        /*
         * @author:ljx
         * @description:根据选中的包写路径内容
         * @input:
         *  input:选中的包的路径列表
         * @return:
         */
        public void dealWithCAAPackage(List<string> input)
        {
            if (0 == input.Count)
            {
                System.Console.WriteLine("dealWithCAAPackage::the size of input is 0");
                return;
            }

            for (int i = 0; i < input.Count; i++)
            {
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

        /*
        * @author: ljx
        * @description:根据用户选择，处理business节点，从xml中获取需要的包，获取envfile的名称（通过value拼写得到）;处理startup节点，获取安装路径和运行设置；
        *              处理envfile节点，获取envfile路径；处理caapackage节点，获取需要的包的路径，与business节点呼应。
        * 
        */
        public void getPackage(string style, XmlNode node, List<string> testlist)
        {
            if (null == node || "".Equals(style))
            {
                System.Console.WriteLine("getPackage::the input is empty!");
                return;
            }
            List<string> temp = new List<string>();
            //得到根结点下面的子节点的集合 <skill>
            XmlNodeList skillNodeList = node.ChildNodes;
            foreach (XmlNode item in skillNodeList)
            {
                //从startup节点，获取安装路径和运行设置
                if ("startup".Equals(item.Name))
                {
                    XmlNodeList subSkillNodeList = item.ChildNodes;
                    foreach (XmlNode item1 in subSkillNodeList)
                    {
                        if ("installpath".Equals(item1.Name))
                        {
                            if (null != item1.Attributes)
                            {
                                installPath = item1.Attributes["value"].Value;
                            }
                        }
                        if ("parameter".Equals(item1.Name))
                        {
                            if (null != item1.Attributes)
                            {
                                runStyle = item1.Attributes["value"].Value;
                            }
                        }
                    }
                }

                //从envfile节点，获取envfile路径
                if ("envfile".Equals(item.Name))
                {
                    if (null != item.Attributes)
                    {
                        envPath += item.Attributes["path"].Value;
                    }
                }

                //System.Console.WriteLine("tt:" + item.Attributes["name"].Value);
                //处理business节点，根据用户选中获取需要加装的包，用于在caapackage节点中获取包路径
                if ("business".Equals(item.Name))
                {
                    XmlNodeList subSkillNodeList = item.ChildNodes;
                    foreach (XmlNode item1 in subSkillNodeList)
                    {
                        if (null != item1.Attributes)
                        {
                            string t = item1.Attributes["id"].Value;
                            if (style.Equals(item1.Attributes["name"].Value))
                            {
                                //System.Console.WriteLine("aa:" + item1.Attributes["name"].Value);
                                XmlNodeList subsubSkillNodeList = item1.ChildNodes;
                                foreach (XmlNode item2 in subsubSkillNodeList)
                                {
                                    if (null != item2.Attributes)
                                    {
                                        temp.Add(item2.Attributes["name"].Value);
                                    }

                                }
                                envName += item1.Attributes["value"].Value;
                            }
                        }

                    }
                }
                //处理caapackage节点，根据business节点中获取的包名称，在caapackage节点下获取需要加装包的路径
                if ("caapackage".Equals(item.Name))
                {
                    XmlNodeList subSkillNodeList = item.ChildNodes;
                    //foreach (string s in temp) {
                    foreach (XmlNode item1 in subSkillNodeList)
                    {
                        if (null != item1.Attributes)
                        {
                            if (temp.Contains(item1.Attributes["name"].Value))
                            {
                                testlist.Add(item1.Attributes["path"].Value);
                            }
                        }
                    }
                    //}

                }

            }

        }

        /*
         * @author:ljx
         * @description:针对路径修改策略，修改mapcontent中的内容，包括路径的增加，修改，新增路径等
         * @input:
         *  name:路径名称
         *  value:路径字符串
         *  mode:操作类型，包括add,modify,new
         *  loc:描述add的插入位置，0表示插在原有路径前，1表示查找原有路径后
         * @return:
         */
        private void dealWithFixDic(string name, string value, string mode, string loc = "0")
        {
            if ("".Equals(name) || "".Equals(value) || "".Equals(mode))
            {
                System.Console.WriteLine("dealWithFixDic::some input is empty!");
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
                else
                {
                    System.Console.WriteLine("dealWithFixDic::loc input is error!");
                    System.Console.WriteLine("dealWithFixDic::the name is: " + name);
                    return;
                }
            }
            else if ("modify".Equals(mode))
            {
                name += "=";
                mapcontent[name] = value;
            }
            else if ("new".Equals(mode))
            {
                name += "=";
                mapcontent[name] = value;
            }
            else
            {
                System.Console.WriteLine("dealWithFixDic::mode input is error!");
                System.Console.WriteLine("dealWithFixDic::the name is: " + name);
                return;
            }
        }

        /*
         * @author:ljx
         * @description:根据选中的包处理CATInstallPath路径
         * @input:
         *  input:包的路径字符串
         * @reutrn：
         */
        private void dealWithCATInstallPath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATInstallPath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATInstallPath))
            {
                tempCATInstallPath = input + "\\win_b64;";
            }
            else
            {
                tempCATInstallPath += input;
                tempCATInstallPath += "\\win_b64;";
            }


        }
        /*
         * @author:ljx
         * @description:根据选中的包处理CATDLLPath路径
         * @input:
         *  input:包的路径字符串
         * @reutrn：
         */
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
            else
            {
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
            else
            {
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
            else
            {
                tempCATCommandPath += input;
                tempCATCommandPath += "\\win_b64\\code\\command;";
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
            else
            {
                tempCATDictionaryPath += input;
                tempCATDictionaryPath += "\\win_b64\\code\\dictionary;";
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
            else
            {
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
            else
            {
                tempCATReffilesPath += input;
                tempCATReffilesPath += "\\win_b64\\reffiles;";
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
            else
            {
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
            else
            {
                tempCATGalaxyPath += "\\win_b64\\resources\\galaxy;";
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
            else
            {
                tempCATGraphicPath += input;
                tempCATGraphicPath += "\\win_b64\\resources\\AppDescription;";
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
            else
            {
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
            else
            {
                tempCATFeatureCatalogPath += input;
                tempCATFeatureCatalogPath += "\\win_b64\\resources\\featurecatalog;";
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
            else
            {
                tempCATDefaultCollectionStandard += input;
                tempCATDefaultCollectionStandard += "\\win_b64\\resources\\standard;";
            }


        }
        private void dealWithCATKnowledgePath(string input)
        {
            if (null == input)
            {
                System.Console.WriteLine("dealWithCATKnowledgePath::the size of input is null");
                return;
            }
            if ("".Equals(tempCATKnowledgePath))
            {
                tempCATKnowledgePath = input + "\\win_b64\\resources\\knowledge;";
            }
            else
            {
                tempCATKnowledgePath += input;
                tempCATKnowledgePath += "\\win_b64\\resources\\knowledge;";
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
            else
            {
                tempCATStartupPath += input;
                tempCATStartupPath += "\\win_b64\\startup;";
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
            if ("".Equals(tempCATReferenceSettingPath))
            {
                tempCATReferenceSettingPath = input + "\\win_b64\\startup\\Settings;";
            }
            else
            {
                tempCATReferenceSettingPath += input;
                tempCATReferenceSettingPath += "\\win_b64\\startup\\Settings;";
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
        /*
         * @author:ljx
         * @description:根据选中的包处理PATH路径
         * @input:
         *  input:包的路径字符串
         * @reutrn：
         */
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
            else
            {
                tempPATH += input;
                tempPATH += "\\win_b64\\code\\bin;";
                tempPATH += input;
                tempPATH += "\\win_b64\\code\\command;";
            }
        }
    }
}
