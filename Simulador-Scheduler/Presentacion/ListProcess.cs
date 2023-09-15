using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Scheduler_Simulator.Presentacion
{
    public partial class ListProcess : UserControl
    {
        private string name = "";
        private string state = "";
        private string waitTime;
        private string burstTime;


        public ListProcess()
        {
            InitializeComponent();
        }

        #region Custom Props
        [Category("Custom Props")]
        public string ProcessName
        {
            get { return name; }
            set { name = value; lblTitle.Text = value; }
        }

        [Category("Custom Props")]
        public string State
        {
            get { return state; }
            set { state = value; lblState.Text = value; }
        }

        [Category("Custom Props")]
        public string WaitTime
        {
            get { return waitTime; }
            set { waitTime = value; lblWaitTime.Text = value; }
        }

        [Category("Custom Props")]
        public string BurstTime
        {
            get { return waitTime; }
            set { burstTime = value; lblBurstTime.Text = value; }
        }
        #endregion
    }
}
