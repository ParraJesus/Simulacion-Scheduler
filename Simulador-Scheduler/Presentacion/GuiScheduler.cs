using Scheduler_Simulator.Logica;
using Scheduler_Simulator.Presentacion;
using System.Threading;

/*
* 
* HECHO POR JESUS GABRIEL PARRA
* 
*/

namespace Simulador_Scheduler
{
    public partial class GuiScheduler : Form
    {
        private List<Processor> processorList = new List<Processor>();
        private List<RegProcess> processList = new List<RegProcess>();

        List<int> processesIndex = new List<int>();

        private Scheduler scheduler;
        public GuiScheduler()
        {
            InitializeComponent();
            inicializeDgvProcess();

            startMode();
        }

        public void inicializeDgvProcess() 
        {
            dgvProcess.AutoGenerateColumns = false;

            dgvProcess.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Nombre"
            });

            dgvProcess.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Priority",
                HeaderText = "Prioridad"
            });

            dgvProcess.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "State",
                HeaderText = "Estado"
            });;

            dgvProcess.DataSource = processList;
        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("El nombre del proceso no puede estar en blanco.");
                return;
            }
            if (!int.TryParse(txtPriority.Text.Trim(), out int priority))
            {
                MessageBox.Show("La prioridad debe ser un n�mero v�lido.");
                return;
            }

            processList.Add(new RegProcess()
            {
                Name = name,
                Priority = int.Parse(txtPriority.Text.Trim())
            });

            processesIndex.Add(int.Parse(cbNucleus.Text));   

            dgvProcess.DataSource = null;
            dgvProcess.DataSource = processList;
        }

        private void btnConfirmProcessors_Click(object sender, EventArgs e)
        {
            int processorsNumber = int.Parse(txtProcessors.Text.Trim());
            if(processorsNumber <= 0) processorsNumber= 1;

            for (int i = 0; i < processorsNumber; i++)
            {
                processorList.Add(new Processor());
                cbNucleus.Items.Add(i.ToString());
            }
            cbNucleus.SelectedIndex = 0;
            confirmProcessorsMode();
        }

        
        private void btnStartSim_Click(object sender, EventArgs e)
        {
            if (processList.Count > 0 && processorList.Count > 0)
            {
                if(rbAuto.Checked) scheduler = new(processorList, processList);

                if (rbManual.Checked) scheduler = new(processorList, processList, processesIndex);

                foreach(Processor processor in processorList) 
                {
                    processor.processingProcesses();
                }
                populateItems();
                startSimulationMode();
            }
        }
        
        /*
        private void btnStartSim_Click(object sender, EventArgs e)
        {
            if (processList.Count > 0 && processorList.Count > 0)
            {
                if (rbAuto.Checked) scheduler = new Scheduler(processorList, processList);
                if (rbManual.Checked) scheduler = new Scheduler(processorList, processList, processesIndex);

                List<Thread> threads = new List<Thread>();

                foreach (Processor processor in processorList)
                {
                    Thread thread = new Thread(() =>
                    {
                        processor.processingProcesses();
                    });

                    threads.Add(thread);
                    thread.Start();
                }

                // Esperar a que todos los hilos terminen antes de continuar
                foreach (Thread thread in threads)
                {
                    thread.Join();
                }

                populateItems();
                startSimulationMode();
            }
        }
        */

        private void txtPriority_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un n�mero o una tecla de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un n�mero ni una tecla de control, suprime la tecla presionada
                e.Handled = true;
            }
            else
            {
                // Si es un n�mero, verifica el rango permitido
                int enteredValue;
                if (int.TryParse(txtPriority.Text + e.KeyChar, out enteredValue))
                {
                    if (enteredValue < 1 || enteredValue > 5)
                    {
                        // Si el valor est� fuera del rango, suprime la tecla presionada
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtProcessors_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un n�mero o una tecla de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un n�mero ni una tecla de control, suprime la tecla presionada
                e.Handled = true;
            }
            else
            {
                // Si es un n�mero, verifica el rango permitido
                int enteredValue;
                if (int.TryParse(txtPriority.Text + e.KeyChar, out enteredValue))
                {
                    if (enteredValue < 1 || enteredValue > 8)
                    {
                        // Si el valor est� fuera del rango, suprime la tecla presionada
                        e.Handled = true;
                    }
                }
            }
        }

        private void populateItems()
        {
            ListProcessor[] listProcessors = new ListProcessor[processorList.Count];

            for (int i = 0; i < listProcessors.Length; i++)
            {
                listProcessors[i] = new ListProcessor(processorList[i].Processes, processorList[i]);
                listProcessors[i].NucleusNumber = i.ToString();

                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else flowLayoutPanel1.Controls.Add(listProcessors[i]);
            }
        }

        private void confirmProcessorsMode()
        {
            if (processorList.Count > 0)
            {
                btnConfirmProcessors.Enabled = false;
                txtProcessors.Enabled = false;

                txtName.Enabled = true;
                txtPriority.Enabled = true;
                btnAddProcess.Enabled = true;
                btnStart.Enabled = true;

                rbAuto.Enabled = true;
                rbAuto.Checked = true;

                rbManual.Enabled = true;
            }


        }

        private void startSimulationMode()
        {
            //btnStart.Enabled = false;
            btnConfirmProcessors.Enabled = false;
            txtProcessors.Enabled = false;
            txtName.Enabled = false;
            txtPriority.Enabled = false;
            btnAddProcess.Enabled = false;

            rbAuto.Enabled = false;
            rbManual.Enabled = false;
            cbNucleus.Enabled = false;
        }

        private void startMode()
        {
            btnConfirmProcessors.Enabled = true;
            txtProcessors.Enabled = true;
            txtName.Enabled = false;
            txtPriority.Enabled = false;
            btnAddProcess.Enabled = false;
            btnStart.Enabled = false;

            rbAuto.Enabled = false;
            rbManual.Enabled = false;
            cbNucleus.Enabled = false;
        }

        private void rbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbManual.Checked) cbNucleus.Enabled = true;
            else cbNucleus.Enabled = false;
        }

        private void rbAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbAuto.Checked) cbNucleus.Enabled = true;
            else cbNucleus.Enabled = false;
        }
    }
}