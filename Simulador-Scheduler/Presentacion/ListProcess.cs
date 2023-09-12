using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler_Simulator.Presentacion
{
    public partial class ListProcess : UserControl
    {
        private string name;
        private string state;
        public ListProcess()
        {
            InitializeComponent();
        }

        [Category("Custom Props")]
        public string Name
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

    }
}
