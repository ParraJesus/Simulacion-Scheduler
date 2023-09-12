using Scheduler_Simulator.Logica;
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

namespace Scheduler_Simulator.Presentacion
{
    public partial class ListProcessor : UserControl
    {
        private List<RegProcess> processes;
        private string nucleusNumber;
        public ListProcessor(List<RegProcess> processes)
        {
            InitializeComponent();

            this.processes = processes;

            populateItems();
        }

        private void populateItems()
        {
            ListProcess[] listProcess = new ListProcess[processes.Count];

            for (int i = 0; i < listProcess.Length; i++)
            {
                listProcess[i] = new ListProcess();
                listProcess[i].Name = listProcess[i].Name;
                listProcess[i].State = listProcess[i].State;

                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else flowLayoutPanel1.Controls.Add(listProcess[i]);
            }
        }

        [Category("Custom Props")]
        public string NucleusNumber
        {
            get { return nucleusNumber; }
            set { nucleusNumber = value; lblNucleus.Text = value; }
        }

    }
}
