using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Fengyuan.CatDialogForms
{
    public partial class CatPathDialog:Form
    {
        private string _path;

        public string CANoeFilePath
        {
            get { return _path; }
            set { this.pathEditText.Text = value; }
        }

        public CatPathDialog()
        {
            InitializeComponent();
            
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "请选择CANoe工程文件";
            dlg.Filter = "CANoe Project (*.cfg)|*.cfg";
            dlg.Multiselect = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.pathEditText.Text = dlg.FileName;
                _path = dlg.FileName;
               // Path.get
            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            //base.OnClosing(e);
            if(DialogResult==DialogResult.OK)
            {
                if (!Directory.Exists(Path.GetDirectoryName(_path)))
                {
                    MessageBox.Show("请导入正确的文件路径！","路径出错",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
           
                
        }
    }
}
