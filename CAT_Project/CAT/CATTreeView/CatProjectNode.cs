using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fengyuan.DBCResolver;

namespace Fengyuan.CATTreeView
{
    public class CatProjectNode : TreeNode
    {
        private CatFaultParentNode _faultParentNode;
        private TreeNode _dbcNode;
        private TreeNode _ascNode;

        public CatFaultParentNode FaultParentNode
        {
            get { return _faultParentNode; }
        }


        public TreeNode AscNode
        {
            get { return _ascNode; } 
        }

        public TreeNode DbcNode
        {
            get { return _dbcNode; }
        }
        private string _projectDir;

        public CatProjectNode(string name)
            : base(name)
        {
            this.Text = name;
            _faultParentNode = this.CreateChildNodes();
            _faultParentNode.CreateChildNodes();
            this.ExpandAll();
            this.ImageKey = "project";
            this.SelectedImageKey = "project";

            //
            _ascNode = new TreeNode();
            this.Nodes.Add(_ascNode);
            _ascNode.Text = "ASC文件";


            


        }

        public CatFaultParentNode CreateChildNodes()
        {
            CatFaultParentNode node = new CatFaultParentNode();
            node.Text = "监测类型";
            this.Nodes.Add(node);
            return node;
        }

        public void CreateDbcNode(DbcManager manager)
        {
            _dbcNode = new TreeNode();
            _dbcNode.ImageKey = "dbc";
            _dbcNode.SelectedImageKey = "dbc";
            _dbcNode.Text = "DBC";
            this.Nodes.Add(_dbcNode);
            for (int i = 0; i < manager.MessageCount; i++)
            {
                CatDbcMsgNode msgNode = new CatDbcMsgNode();
                msgNode.Text = manager.MessageArray[i].MessageName + "(0x" +Convert.ToString( manager.MessageArray[i].MessageId,16)+")";
                _dbcNode.Nodes.Add(msgNode);

                for (int j = 0; j < manager.MessageArray[i].Count; j++)
                {
                    CatDbcSignalNode signalNode = new CatDbcSignalNode();
                    signalNode.Text = manager.MessageArray[i][j].SignalName;
                    signalNode.Signal = manager.MessageArray[i][j];
                    msgNode.Nodes.Add(signalNode);
                   // TreeNode child = msgNode.Nodes.Add(manager.MessageArray[i][j].SignalName);
                  //  child.Tag = manager.MessageArray[i][j];
                }
            }


        }
    }
}
