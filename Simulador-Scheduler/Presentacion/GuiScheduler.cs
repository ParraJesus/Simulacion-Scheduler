using Scheduler_Simulator.Logica;
using Scheduler_Simulator.Presentacion;
using System.Diagnostics;
using System.Windows.Forms;

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

        private Scheduler scheduler;
        public GuiScheduler()
        {
            InitializeComponent();
            inicializeDgvProcess();
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
                MessageBox.Show("La prioridad debe ser un número válido.");
                return;
            }

            processList.Add(new RegProcess()
            {
                Name = name,
                Priority = int.Parse(txtPriority.Text.Trim())
            });

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
            }
            confirmProcessorsMode();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (processList.Count > 0 && processorList.Count > 0) {
                scheduler = new(processorList, processList);
                startMode();

                populateItems();
            }
        }

        private void txtPriority_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número o una tecla de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, suprime la tecla presionada
                e.Handled = true;
            }
            else
            {
                // Si es un número, verifica el rango permitido
                int enteredValue;
                if (int.TryParse(txtPriority.Text + e.KeyChar, out enteredValue))
                {
                    if (enteredValue < 1 || enteredValue > 5)
                    {
                        // Si el valor está fuera del rango, suprime la tecla presionada
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtProcessors_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada no es un número o una tecla de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Si no es un número ni una tecla de control, suprime la tecla presionada
                e.Handled = true;
            }
            else
            {
                // Si es un número, verifica el rango permitido
                int enteredValue;
                if (int.TryParse(txtPriority.Text + e.KeyChar, out enteredValue))
                {
                    if (enteredValue < 1 || enteredValue > 8)
                    {
                        // Si el valor está fuera del rango, suprime la tecla presionada
                        e.Handled = true;
                    }
                }
            }
        }

        private void confirmProcessorsMode()
        {
            if (processorList.Count > 0)
            {
                btnConfirmProcessors.Enabled = false;
                txtProcessors.Enabled = false;
            }
        }
        private void startMode()
        {
            btnConfirmProcessors.Enabled = false;
            txtProcessors.Enabled = false;
            txtName.Enabled = false;
            txtPriority.Enabled = false;
            btnAddProcess.Enabled = false;
        }

        private void populateItems() 
        {
            ListProcessor[] listProcessors = new ListProcessor[processorList.Count];

            Debug.WriteLine(processorList.Count);
            
            for (int i = 0; i < listProcessors.Length; i++) 
            {
                listProcessors[i] = new ListProcessor();
                listProcessors[i].NucleusNumber = i.ToString();

                if (flowLayoutPanel1.Controls.Count > 0) 
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else flowLayoutPanel1.Controls.Add(listProcessors[i]);
            }
        }
    }
}