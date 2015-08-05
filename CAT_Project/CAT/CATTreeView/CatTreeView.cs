using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Fengyuan.CATTreeView
{
    public class CatTreeView:TreeView
    {

        private CatProjectNode _projectNode;

      /*  public string TreeProjectName
        {
            get { return _projectNode.Text; }
            set 
            {
                    _projectNode.Text = value;
               
            }
        }*/
        /// <summary>
        /// 创建工程项目节点。只允许软件上存在一个工程节点。
        /// </summary>
        /// <returns></returns>
        public CatProjectNode AddProjectNode(string name)
        {
            if (this.Nodes.Count != 0)
                return null;
            else
            {
                 _projectNode = new CatProjectNode(name);
                this.Nodes.Add(_projectNode);
                return _projectNode;
                
            }
        }

    }
}
