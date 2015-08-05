using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Fengyuan.CATTreeView
{
    
    public class CatFaultParentNode:TreeNode
    {
        public CatFaultParentNode():base()
        {
            this.ImageKey = "fault";
            this.SelectedImageKey = "fault";
        }
       
        
        public void CreateChildNodes()
        {
            CatFaultNode globalTimeOut = new CatFaultNode();
            globalTimeOut.Text = "Globat Time Out";
            globalTimeOut.ImageKey = "timeout";
            globalTimeOut.SelectedImageKey = "timeout";
            this.Nodes.Add(globalTimeOut);

            CatFaultNode msgTimeout = new CatFaultNode();
            msgTimeout.Text = "Message Time Out";
            msgTimeout.ImageKey = "msgtimeout";
            msgTimeout.SelectedImageKey = "msgtimeout";
            this.Nodes.Add(msgTimeout);

            CatFaultNode chkError = new CatFaultNode();
            chkError.Text = "Check Error";
            chkError.ImageKey = "check";
            chkError.SelectedImageKey = "check";
            this.Nodes.Add(chkError);

            CatFaultNode dlcError = new CatFaultNode();
            dlcError.Text = "DLC Error";
            dlcError.ImageKey = "dlc";
            dlcError.SelectedImageKey = "dlc";
            this.Nodes.Add(dlcError);

            CatFaultNode msgCountError = new CatFaultNode();
            msgCountError.Text = "Message Count Error";
            msgCountError.ImageKey = "msgcount";
            msgCountError.SelectedImageKey = "msgcount";
            this.Nodes.Add(msgCountError);

            CatFaultNode altBitError = new CatFaultNode();
            altBitError.Text = "Alt-Bit Error";
            altBitError.ImageKey = "altbit";
            altBitError.SelectedImageKey = "altbit";
            this.Nodes.Add(altBitError); 
        }

    }

    
}
