using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;



namespace Fengyuan.DBCResolver
{
    public class DbcManager
    {
        private string _dbcFilePath;
        private FileStream _fileStream;
        private StreamReader _streamReader;
        private string _fileString;
        private int _messageCount;

        private DbcMessage[] _messageArray = new DbcMessage[100];

        public int MessageCount
        {
            get { return _messageCount; }
        }

        public DbcMessage[] MessageArray
        {
            get { return _messageArray; }
        }

        public DbcManager(string filePath)
        {
            _dbcFilePath = filePath;
            try
            {
                _fileStream = new FileStream(filePath, FileMode.Open);
                _streamReader = new StreamReader(_fileStream);
                _fileString = _streamReader.ReadToEnd();

                GetDbcMessageInfo();

                _streamReader.Close();
                _streamReader.Dispose();
                _fileStream.Dispose();

            }
            catch(IOException e)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(e.ToString());
                //]]return;

            }

        }


        /// <summary>
        /// 
        /// </summary>
        private void GetDbcMessageInfo()
        {
            string[] sentences = _fileString.Split('\n');
            string[] wordToMatch = { "BO_", "SG_" };

            //提取出dbc文件中以"BO_"和"SG_"开头的行，这些行分别代表message和signal


            var sentenceQuery = from sentence in sentences
                                let w = sentence.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                                                        StringSplitOptions.RemoveEmptyEntries)
                                //   where w.First().ToString() == "BO_"
                                where w.Intersect(wordToMatch).Count() > 0
                                select sentence;


            sentenceQuery = from sentence in sentenceQuery
                            let w = sentence.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },
                                                    StringSplitOptions.RemoveEmptyEntries)
                            where (w.First().ToString() == "BO_") || (w.First().ToString() == "SG_")
                            select sentence;

   

            string[] w1 = new String[30];
            int index = 0;
             DbcSignal signal;
            foreach(string line in sentenceQuery)
            {
                w1 = line.Split(new char[] { ' ', ';', ':', ',', '|', '@', '(', ')', '[', ']', '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                if(w1[0].Equals("BO_"))
                {
                    //if(index!=0) 
                    //    index++;
                    _messageArray[index] = new DbcMessage(w1[2]);
                    _messageArray[index].MessageId = (ushort)Convert.ToDecimal(w1[1]);
                    _messageArray[index].MessageSize = (byte)Convert.ToDecimal(w1[3]);
                    index++;
                }
                else if(w1[0].Equals("SG_"))
                {
                    signal = _messageArray[index-1].Add(w1[1]);
                    signal.Size = SearchDbcSignalSize(line);
                    signal.StartBit = SearchDbcSignalStartBit(line);       
                    signal.Maximum = SearchDbcSignalMaximun(line);
                    signal.Minimum = SearchDbcSignalMinimun(line); 
                }

            }
            _messageCount = index;
            
        }
        /// <summary>
        /// 正则表达式搜索signal的长度
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private byte SearchDbcSignalSize(string input)
        {
            string delimited = @"(.+)\u007c(.+)\@";
            Match match = Regex.Match(input, delimited);
            return (byte)Convert.ToDecimal(match.Groups[2].Value);
         

        }
        /// <summary>
        /// 正则表达式搜索signal的起始位
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private byte SearchDbcSignalStartBit(string input)
        {
            string delimited = @"(.+):(.+)\@";
            Match match = Regex.Match(input, delimited);

            string subLine = match.Groups[2].Value;
            string[] w = subLine.Split('|');
            return (byte)Convert.ToDecimal(w[0]);
        }
        /// <summary>
        /// 正则表达式搜索signal的最大值。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private double SearchDbcSignalMinimun(string input)
        {
            string delimited = @"(.+)\[(.+)\u007c";
            Match match = Regex.Match(input, delimited);
            return Convert.ToDouble(match.Groups[2].Value);
        }

        /// <summary>
        /// 正则表达式搜索signal的最小值。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private double SearchDbcSignalMaximun(string input)
        {
            string delimited = @"(.+)\u007c(.+)\]";
            Match match = Regex.Match(input, delimited);
            return Convert.ToDouble(match.Groups[2].Value);
        }






        /// <summary>
        /// 生成包含dbc信息的treeview
        /// </summary>
        public void GenerateDbcTreeView(TreeView tree)
        {
            TreeNode root = tree.Nodes.Add("DBC File");
            for (int i = 0; i < _messageCount; i++)
            {
                TreeNode node = root.Nodes.Add(_messageArray[i].MessageName);
                
                for (int j = 0; j < _messageArray[i].Count; j++)
                {
                    TreeNode child = node.Nodes.Add(_messageArray[i][j].SignalName);
                    child.Tag = _messageArray[i][j];
                }
            }


        }
        /// <summary>
        /// 测试用。向控制台显示Dbc信息结构
        /// </summary>
        public void DisplayDbc2Console()
        {
           // Console.WriteLine(_fileString);
            for (int i = 0; i < _messageCount; i++)
            {
                Console.WriteLine(_messageArray[i].MessageName + " id: " + _messageArray[i].MessageId + " size: " + _messageArray[i].MessageSize);
                for(int j=0;j<_messageArray[i].Count;j++)
                {
                   // Console.WriteLine(_messageArray[i][j].SignalName+" min: "+_messageArray[i][j].Minimum+" max: "+_messageArray[i][j].Maximum);
                    Console.WriteLine(_messageArray[i][j].SignalName + " size: " + _messageArray[i][j].Size + " startbit: " + _messageArray[i][j].StartBit);
                }
            }
            
        }

    }
}
