using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Fengyuan.CatAnalyzer;
namespace Fengyuan.CatForm
{
    public class CatProjectManager
    {
        /// <summary>
        /// 工程文件涵盖的内容是否发生过修改
        /// </summary>
        public bool HasChanged
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string DbcPath
        {
            get;
            set;
        }

        public string AscPath
        {
            get;
            set;
        }

        /// <summary>
        /// 引用一个GlobatTimeout监控器
        /// </summary>
        public GlobalTimeoutMonitor GlobalTimeout
        {
            get;
            set;
        }

        public CatProjectManager()
        {
            HasChanged = true;//测试用
            //this.Name = "Project 1";
        }


        public  DialogResult  AskForSave()
        {
            if(this.HasChanged)
            {
                string msg;
                if (Name == null)
                    msg = "是否要保存所做的修改？";
                else
                    msg = "是否要保存工程文件" + Name + "?";

                DialogResult result = MessageBox.Show(msg, "是否保存",
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question);
                return result;
            }
            return DialogResult.No;
        }
        /// <summary>
        /// 保存工程文件
        /// </summary>
        public void Save(string fullName, bool overwrite)
        {
            if (fullName == null)
                throw new ArgumentNullException("Full name");
            if (File.Exists(fullName) && !overwrite)
                throw new ArgumentException("该工程文件已存在");

            ProjectStorage.WriteProjectFile(this, fullName);

        }


   }
}
  

