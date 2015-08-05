using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Fengyuan.CATTreeView
{
    public class CatDbcMsgNode:TreeNode
    {
        public CatDbcMsgNode()
        {
            this.ImageKey = "message";
            this.SelectedImageKey = "message"; 
        }
     
    }
}
