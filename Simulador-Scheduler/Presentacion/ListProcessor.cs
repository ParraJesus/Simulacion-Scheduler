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
    public partial class ListProcessor : UserControl
    {
        public ListProcessor()
        {
            InitializeComponent();
        }

        private string nucleusNumber;

        [Category("Custom Props")]
        public string NucleusNumber
        {
            get { return nucleusNumber; }
            set { nucleusNumber = value; lblNucleus.Text = value; }
        }

    }
}
