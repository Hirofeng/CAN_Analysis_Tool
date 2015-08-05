using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fengyuan.CatForm
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            this.processBarTimer.Start();
            this.progressBar.Value = 20;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.processBarTimer.Stop();
            this.timer1.Stop();
            this.Close();
        }

        private void processBarTimer_Tick(object sender, EventArgs e)
        {
            this.progressBar.Increment(1);
        }
    }
}
