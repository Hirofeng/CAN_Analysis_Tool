using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fengyuan.DBCResolver;
namespace Fengyuan.CATTreeView
{
    public class CatDbcSignalNode : TreeNode
    {
        private bool _isAddedToListView;

        public bool IsAddedToListView
        {
            get { return _isAddedToListView; }
            set { _isAddedToListView = value; }
        }
        private DbcSignal _signal;

        public DbcSignal Signal
        {
            get { return _signal; }
            set { _signal = value; }
        }
        public CatDbcSignalNode()
        {
            this.ImageKey = "signal";
            this.SelectedImageKey = "signal";
        }
    }
}
