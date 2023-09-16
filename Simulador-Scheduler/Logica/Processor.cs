using Scheduler_Simulator.Presentacion;
using System.Diagnostics;
using System.Windows.Forms;

/*
 * 
 * HECHO POR JESUS GABRIEL PARRA
 * 
 */

namespace Scheduler_Simulator.Logica
{
    public class Processor
    {
        private List<RegProcess> processes = new List<RegProcess>();

        private List<ListProcess> listProcesses = new List<ListProcess>();

        private System.Windows.Forms.Timer progressBarUpdateTimer;

        private int currentListProcessIndex = 0;

        public Processor()
        {
            progressBarUpdateTimer = new System.Windows.Forms.Timer();
            progressBarUpdateTimer.Interval = 2000; // 2 segundos
            progressBarUpdateTimer.Tick += ProgressBarUpdateTimer_Tick;
            
        }

        public void processingProcesses()
        {
            foreach (var process in processes) 
            {
                process.State = RegProcess.ProcessState.Running;
            }
            progressBarUpdateTimer.Start();
        }

        private void ProgressBarUpdateTimer_Tick(object sender, EventArgs e)
        {
            ListProcess currentListProcess = listProcesses[currentListProcessIndex];

            // Si la barra de progreso actual no ha alcanzado el 100%
            if (currentListProcess.ProgressBarValue < 100)
            {
                // Incrementa la barra de progreso en 10
                currentListProcess.ProgressBarValue += 10;
            }
            else
            {
                // Si la barra de progreso ha alcanzado el 100%, pasa a la siguiente
                currentListProcessIndex++;

                // Si hemos llegado al final de la lista, reinicia desde el principio
                if (currentListProcessIndex >= listProcesses.Count)
                {
                    currentListProcessIndex = 0;
                }
            }
        }

        public List<RegProcess> Processes { get => processes; set => processes = value; }
        public List<ListProcess> ListProcesses { get => listProcesses; set => listProcesses = value; }
    }
}
