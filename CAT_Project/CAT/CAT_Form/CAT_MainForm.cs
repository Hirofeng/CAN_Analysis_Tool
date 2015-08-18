using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fengyuan.DBCResolver;
using Fengyuan.CATTreeView;
using Fengyuan.CatDialogForms;
using System.IO;
using System.Threading;
using Fengyuan.CatAnalyzer;
namespace Fengyuan.CatForm
{
    public partial class CatForm : Form
    {
        
        private string _canoeFilePath;

        //CANoe objects
        private CANoe.Application mCANoeApp;
        private CANoe.Measurement mCANoeMeasurement;

        //Cat工程文件
       // private CatProjectManager CatProjectManager;

        public CatProjectManager CatProject
        {
            get;
            set;
        }

        public CatForm()
        {
            InitializeComponent();
          // Control.CheckForIllegalCrossThreadCalls = false;
            ConsoleWriteLine("..........................CAT启动成功！..........................");
            ConsoleWriteLine("..........................欢迎使用CAT！..........................");
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
           // this.Text = "CAN Analysis Tool-YIRUI";//string.Format("CAN Analysis Tool-YIRUI {0:#}.{1:#}",v.Major,v.Minor);
            SetTitleBar();
            this.tsbNew.Tag = menuFileNew;
            this.tsbDBC.Tag = menuFileLoadDbc;
            this.tsbOpen.Tag = menuFileLoadProject;
            this.tsbHelp.Tag = menuHelpAbout;
            this.tsbStartCanoe.Tag = menuCanoeStart;
            this.tsbSave.Tag = menuFileSave;

            //SetBindings();//Test
            
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
           // if(String.IsNullOrEmpty(_catProject.DbcPath))
           // { 
            CatProjectNode pNode = this.dbcTreeView.TopNode as CatProjectNode;

            if (pNode != null)
            {
                if (pNode.DbcNode != null)
                {
                   DialogResult result = MessageBox.Show("是否导入新的DBC文件？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                   if (result == DialogResult.No)
                       return;
                   else
                   {
                       pNode.DbcNode.Remove();
                   }

                }
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Title = "请选择DBC文件";
                    dlg.Filter = "DBC files (*.dbc)|*.dbc";
                    dlg.Multiselect = false;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        string path = dlg.FileName;
                        DbcManager manager = new DbcManager(path);
                        pNode.CreateDbcNode(manager);
                        CatProject.DbcPath = path;
                    }
                    dlg.Dispose();
              

            }
            else
            {
                MessageBox.Show("请先创建工程！");
            }
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





        /// <summary>
        /// 创建新的CAT工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            if (CatProject == null || SaveAndCloseProject())
            {
                CatProject = new CatProjectManager();//创建新的工程
                //this.Text = this.Text + "Project 1"; //更新界面标题，使用默认工程文件名
                
                CatProjectNode pNode = this.dbcTreeView.AddProjectNode("Project 1");
                SetTitleBar();
              
             
                //关联TreeView节点与TabPage
                for (int i=0; i < gTabControl.TabPages.Count;i++ )
                {
                    CatFaultNode node = pNode.FaultParentNode.Nodes[i] as CatFaultNode;
                    node.FalutTabPage = gTabControl.TabPages[i];
                }


                

                    //显示TabPages
                this.gTabControl.Visible = true;
                //---------------Test Code--------------------------
                CatProject.GlobalTimeout = new GlobalTimeoutMonitor();
               // _catProject.GlobalTimeout.Channel = "hello";
                CatProject.GlobalTimeout.Platform = "SVW_PQ25";//PlatformType.SVW_PQ25;
                SetBindings();
                //------------------------------------------------------
            }
        }


        private bool SaveAndCloseProject()
        {
            DialogResult result = CatProject.AskForSave();
            if (result == DialogResult.Yes)
                SaveProject();
            else if (result == DialogResult.Cancel)
                return false;

            this.dbcTreeView.Nodes.RemoveAt(0);//清除工程的TreeView

            return true;

        }
        /// <summary>
        /// 保存CAT工程文件
        /// </summary>
        private void SaveProject()
        {

            if (String.IsNullOrEmpty(CatProject.Name))
                SaveAsProject();
            else
                SaveProject(CatProject.Name);

        }

        /// <summary>
        /// 根据字符名保存CAT工程文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProject(string fullPath)
        {
            CatProject.Name = Path.GetFileNameWithoutExtension(fullPath);
            try
            {
                CatProject.Save(fullPath,true);
            }
            catch(Exception e)
            {

            }
        }

        /// <summary>
        /// 创建另存为对话框
        /// </summary>
        private void SaveAsProject()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "保存CAT工程";
            dlg.Filter = "CAT files (*.cnf)|*.cnf";
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                SaveProject(dlg.FileName);
                SetTitleBar();
            }
            dlg.Dispose();


        }
        /// <summary>
        /// 1.更新界面标题栏内容
        /// 2.更新TreeView Project节点名称
        /// </summary>
        private void SetTitleBar()
        {
            if (CatProject != null)
            {
                this.Text = string.Format("CAT- {0}{1}", String.IsNullOrEmpty(CatProject.Name) ? "Untitled" : CatProject.Name,CatProject.HasChanged?"*":"");
                //更新TreeView的Project Node名字
                this.dbcTreeView.Nodes[0].Text = string.Format("{0}", String.IsNullOrEmpty(CatProject.Name) ? "Untitled" : CatProject.Name);
            }
            else
            {
                this.Text = "CAN Analysis Tool-YIRUI";
            }
        }

        private void dbcTreeView_DoubleClick(object sender, EventArgs e)
        {
            CatTreeView tree = sender as CatTreeView;

           
            if (tree.SelectedNode is CatFaultNode)
            {
                CatFaultNode node = tree.SelectedNode as CatFaultNode;
                gTabControl.SelectedTab = node.FalutTabPage;

               // gTabControl.
             
            }   
            else if(tree.SelectedNode is CatDbcSignalNode)
            {
                CatDbcSignalNode signalNode = tree.SelectedNode as CatDbcSignalNode;
                if (!signalNode.IsAddedToListView) //信号只能添加一次
                {
                    ListViewItem item = new ListViewItem(signalNode.Signal.SignalName);
                    item.Tag = signalNode;
                    item.SubItems.Add(signalNode.Parent.Text); //列表显示所属消息名称
                    item.SubItems.Add(signalNode.Signal.Maximum.ToString());
                    item.SubItems.Add(signalNode.Signal.Minimum.ToString());

                    catlistView.Items.Add(item);
                    signalNode.IsAddedToListView = true;
                    
                }

            }
           
        }

        private void tabCxtMenuClose_Click(object sender, EventArgs e)
        {
           // catTabControl.SelectedTab.Hide();
            //TabPage page = sender as TabPage;
           // page.Hide();
           // tabPage2.
        }

        private void TabPageContentTest(TabPage tabPage)
        {
            // 
            // tabPage1
            // 
       
            tabPage.Location = new System.Drawing.Point(4, 23);
          //  tabPage.Name = "tabPage1";
            tabPage.Padding = new System.Windows.Forms.Padding(3);
          //  tabPage.Size = new System.Drawing.Size(661, 250);
          //  tabPage.TabIndex = 0;
         //   tabPage.Text = "tabPage1";
            tabPage.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            Button button11 = new Button();
            button11.Location = new System.Drawing.Point(60, 52);
            button11.Name = "button1";
            button11.Size = new System.Drawing.Size(75, 23);
            button11.TabIndex = 0;
            button11.Text = "button1";
            button11.UseVisualStyleBackColor = true;
            // 
            // label1
            //
            Label label11 = new Label();
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(242, 62);
            label11.Name = "label1";
            label11.Size = new System.Drawing.Size(41, 12);
            label11.TabIndex = 1;
            label11.Text = "label1";
            // 
            // textBox1
            // 
            TextBox textBox11 = new TextBox();
            textBox11.Location = new System.Drawing.Point(439, 53);
            textBox11.Name = "textBox1";
            textBox11.Size = new System.Drawing.Size(100, 21);
            textBox11.TabIndex = 2;
            // 
            // radioButton1
            // 
            RadioButton radioButton11  = new RadioButton();
            radioButton11.AutoSize = true;
            radioButton11.Location = new System.Drawing.Point(60, 195);
            radioButton11.Name = "radioButton1";
            radioButton11.Size = new System.Drawing.Size(95, 16);
            radioButton11.TabIndex = 3;
            radioButton11.TabStop = true;
            radioButton11.Text = "radioButton1";
            radioButton11.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            //
            CheckBox checkBox11 = new CheckBox();
            checkBox11.AutoSize = true;
            checkBox11.Location = new System.Drawing.Point(244, 194);
            checkBox11.Name = "checkBox1";
            checkBox11.Size = new System.Drawing.Size(78, 16);
            checkBox11.TabIndex = 4;
            checkBox11.Text = "checkBox1";
            checkBox11.UseVisualStyleBackColor = true;

            tabPage.Controls.Add(checkBox11);
            tabPage.Controls.Add(radioButton11);
            tabPage.Controls.Add(textBox11);
            tabPage.Controls.Add(label11);
            tabPage.Controls.Add(button11);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            TabPage page = box.Parent as TabPage;
            
                foreach (Control control in page.Controls)
                {
                    control.Enabled = box.Checked;
                }

                box.Enabled = true;
            
        }

        private void signalCxtMenu_Opening(object sender, CancelEventArgs e)
        {
         
         
  

        }
        //TODO TreeView上下文菜单
        private void addSignalCtxMenu_Click(object sender, EventArgs e)
        {

            if ( this.dbcTreeView.SelectedNode.Text == "ASC文件")
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "请添加.asc文件";
                dlg.Filter = "ASC files (*.asc)|*.asc";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TreeNode node = new TreeNode();
                    this.dbcTreeView.SelectedNode.Nodes.Add(node);
                    node.Text = dlg.FileName;
                }
                dlg.Dispose();
            }
          
        }
        
        private void listViewCtxDelete_Click(object sender, EventArgs e)
        {

        }

        private void catlistView_DoubleClick(object sender, EventArgs e)
        {
            ListView list = sender as ListView;
            CatDbcSignalNode signal = list.FocusedItem.Tag as CatDbcSignalNode;
            list.FocusedItem.Remove();
            signal.IsAddedToListView = false;
        }
        /// <summary>
        /// 选择CANoe工程文件的路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCANoePath_Click(object sender, EventArgs e)
        {
            CatPathDialog dlg = new CatPathDialog();

            dlg.CANoeFilePath = _canoeFilePath;
            
            if(dlg.ShowDialog()==DialogResult.OK)
            {         
                    _canoeFilePath = dlg.CANoeFilePath;
          
                
            }

            

        }
        /// <summary>
        /// 启动CANoe软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCanoeStart_Click(object sender, EventArgs e)
        {
            if (_canoeFilePath == null)
            {
                MessageBox.Show("请先导入正确的CANoe工程文件路径！","CANoe启动失败",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {


                // Init new CANoe application.
                mCANoeApp = new CANoe.Application();

                // Init measurement object.
                mCANoeMeasurement = mCANoeApp.Measurement;

                // Stopps a running measurement.
                if (mCANoeMeasurement.Running)
                {
                    mCANoeMeasurement.Stop();
                }

                if (mCANoeApp != null)
                {
                    
                    // Open the demo configuration.
                    mCANoeApp.Open(_canoeFilePath, true, true);
                   
                    // Make sure the configuration was successfully loaded.
                    CANoe.OpenConfigurationResult ocresult = mCANoeApp.Configuration.OpenConfigurationResult;
                    if (ocresult.result == 0)
                    {
                        ConfigurationOpened();
                    }
                }
            }
            

        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            if(CatProject!=null)
                SaveProject();

        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            if(CatProject!=null)
                SaveAsProject();
        }

        private void delDbcTreeCxt_Click(object sender, EventArgs e)
        {
            

        }
        /// <summary>
        /// 创建About对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            using (AboutBox dlg = new AboutBox())
            {
               
                dlg.Owner = this;
                dlg.ShowDialog();
            }
        }

        private void CatForm_Load(object sender, EventArgs e)
        {
          /*  SplashForm splash = new SplashForm();
            splash.ShowDialog();
           * */
        }

        private void listViewCtxDelete_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            


        }

        private void listViewCtxMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            if (item != null)
            {
                CatDbcSignalNode signal = this.catlistView.FocusedItem.Tag as CatDbcSignalNode;
                this.catlistView.FocusedItem.Remove();
                signal.IsAddedToListView = false;
           
            }
        }

        /// <summary>
        /// 配置界面的显示参数与数据源绑定
        /// </summary>
        private void SetBindings()
        {
            this.bindingCat.DataSource = CatProject.GlobalTimeout;
            
            //cbxPlatform.
            this.cbxPlatform.DataBindings.Add("Text", bindingCat, "Platform");
            this.cbxChannel.DataBindings.Add("Text", bindingCat, "Channel");

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            this.tabPage1.Focus();
        }

        private void cbxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tabPage1.Focus();
        }

        private void cbxPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tabPage1.Focus();
        }

        private void tsbReport_Click(object sender, EventArgs e)
        {
            this.gTabControl.Visible = false;
        }

        private void tsbTestStart_Click(object sender, EventArgs e)
        {
            if (mCANoeMeasurement != null)
            {
                //启动CANoe工作
                if (!mCANoeMeasurement.Running)
                {
                    mCANoeMeasurement.Start();


                    //显示CANoe Measurement启动结果
                    string result = mCANoeMeasurement.Running ? "成功!" : "失败!";
                    MessageBox.Show("工程启动" + result); // TODO XIANSHI


                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ConsoleLoadDot();
        }

        /*----------------------------------------------------------------
         * Console控制台的功能方法
         * ---------------------------------------------------------------
         */

        /// <summary>
        /// 向CAT的Console写一行字符串内容。写完自动换行。
        /// </summary>
        /// <param name="text"></param>
        private void ConsoleWriteLine(string text)
        {
            consoleTextBox.AppendText(text+"\n");
        }

        /// <summary>
        /// 清除Console内所有内容。
        /// </summary>
        private void ConsoleClrAll()
        {
            consoleTextBox.Clear();
        }




        private void ConsoleLoadDot()
        {
            int dotNum = 10;
                                                                    //TODO 这里其实是委托UI线程来操纵控件
            this.consoleTextBox.BeginInvoke(new Action(() =>
            {
                consoleTextBox.AppendText("正在打开CANoe");
            }));
            
            for (;;)
            {
                this.consoleTextBox.BeginInvoke(new Action(() =>
                {
                    consoleTextBox.AppendText(" .");
                }));
                    
                Thread.Sleep(10);
                     
            }
        }
        //TODO TreeView右键事件
        private void dbcTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X,e.Y);
            TreeNode tn = this.dbcTreeView.GetNodeAt(point);
            this.dbcTreeView.SelectedNode = tn;
            if (e.Button == MouseButtons.Right)
            {
                treeCxtMenu.Show(this.dbcTreeView.PointToScreen(point));
            }
        }


    }
}/*-----------End--------------*/
