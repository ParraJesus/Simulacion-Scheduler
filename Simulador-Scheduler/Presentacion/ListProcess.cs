using System.ComponentModel;

/*
 * 
 * HECHO POR JESUS GABRIEL PARRA
 * 
 */

namespace Scheduler_Simulator.Presentacion
{
    public partial class ListProcess : UserControl
    {

        #region Attributes
        private string name = "";
        private string state = "";
        private string waitTime;
        private string burstTime; 
        #endregion

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

        [Category("Custom Props")]
        public int ProgressBarValue
        {
            get { return pbState.Value; }
            set { pbState.Value = value; }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
