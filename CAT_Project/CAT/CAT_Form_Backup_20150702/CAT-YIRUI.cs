using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fengyuan.DBCResolver;

namespace CAT_Form
{
    public partial class CatForm : Form
    {
        public CatForm()
        {
            InitializeComponent();

        }


        /// <summary>
        /// 在标题栏中显示版本号
        /// OnLoad触发Load事件，该事件是窗口第1次被显示之前发生的。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            //显示主窗口名称
            Version v = new Version(Application.ProductVersion);
            this.Text = "CAN Analysis Tool-YIRUI";//string.Format("CAN Analysis Tool-YIRUI {0:#}.{1:#}",v.Major,v.Minor);

            this.tsbNew.Tag = menuFileNew;
            this.tsbDBC.Tag = menuFileLoadDbc;
            this.tsbOpen.Tag = menuFileLoadProject;
            this.tsbHelp.Tag = menuHelpAbout;
            
            base.OnLoad(e);
        }

        private void toolStripOpen_Click(object sender, EventArgs e)
        {

        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "请选择DBC文件";
            dlg.Filter = "DBC files (*.dbc)|*.dbc";
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;
                DbcManager manager = new DbcManager(path);
                manager.GenerateDbcTreeView(dbcTreeView);
                // dbcTreeView.ExpandAll();//展开所有节点
            }
            dlg.Dispose();

        }

        private void menuFileLoadDbc_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "请选择DBC文件";
            dlg.Filter = "DBC files (*.dbc)|*.dbc";
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.FileName;
                DbcManager manager = new DbcManager(path);
                manager.GenerateDbcTreeView(dbcTreeView);
                // dbcTreeView.ExpandAll();//展开所有节点
            }
            dlg.Dispose();
        }

        private void tsb_Click(Object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;
            if(item != null)
            {
                ToolStripMenuItem mItem = item.Tag as ToolStripMenuItem;
                if (mItem != null)
                    mItem.PerformClick();
            }
        }


    }
}/*-----------End--------------*/
