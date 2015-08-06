using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fengyuan.CatForm
{
    public partial class CatForm : Form
    {
        

        /// <summary>
        /// 完成CANoe被打开后进行的配置工作。
        /// </summary>
        private void ConfigurationOpened()
        {

            try
            {
                CANoe.System CANoeSystem = (CANoe.System) mCANoeApp.System;


            }
            catch (System.Exception)
            {
                MessageBox.Show("Error","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // menuCanoeStart.Enabled = true;
            tsbTestStart.Enabled = true;


            if (mCANoeApp != null)
            {
                
                mCANoeApp.OnQuit += new CANoe._IApplicationEvents_OnQuitEventHandler(CANoeQuit); //注册退出事件

            }

            if (mCANoeMeasurement != null)
            {

                mCANoeMeasurement.OnInit += new CANoe._IMeasurementEvents_OnInitEventHandler(MeasurementInitiated); //注册measurement初始化事件
            }



        }

        private void 

    }
}
