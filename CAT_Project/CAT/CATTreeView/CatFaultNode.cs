using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Fengyuan.CATTreeView
{
  
    public class CatFaultNode:TreeNode
    {

        private TabPage _tabPage;
    
 
        public TabPage FalutTabPage
        {
            get { return _tabPage; }
            set { _tabPage = value; }
        }
    }
}
