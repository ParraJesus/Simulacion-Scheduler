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

        private float initialTime = 0;
        private float currentTime = 0;
        private Stopwatch stopwatch = new Stopwatch();

        public Processor()
        {
            progressBarUpdateTimer = new System.Windows.Forms.Timer();
            progressBarUpdateTimer.Interval = 500; //tiempo en milisegundos
            progressBarUpdateTimer.Tick += ProgressBarUpdateTimer_Tick;
            
        }

        public void processingProcesses()
        {
            foreach (var process in processes) 
            {
                process.State = RegProcess.ProcessState.Running;
            }
            progressBarUpdateTimer.Start();

            stopwatch.Start();
        }

        /*
        private void ProgressBarUpdateTimer_Tick(object sender, EventArgs e)
        {
            ListProcess currentListProcess = listProcesses[currentListProcessIndex];

            // Si la barra de progreso actual no ha alcanzado el 100%
            if (currentListProcess.ProgressBarValue < 100)
            {
                // Incrementa la barra de progreso en 10
                currentListProcess.ProgressBarValue += 10;

                currentTime += 10;
            }
            else
            {

                //Actualizar los datos de los procesos y de los páneles de procesos
                
                processes[currentListProcessIndex].State = RegProcess.ProcessState.Terminated;
                listProcesses[currentListProcessIndex].State = RegProcess.ProcessState.Terminated.ToString();

                processes[currentListProcessIndex].WaitTime = initialTime % 2;
                listProcesses[currentListProcessIndex].WaitTime = initialTime.ToString();

                
                processes[currentListProcessIndex].BurstTime = currentTime % 2;
                listProcesses[currentListProcessIndex].BurstTime = currentTime.ToString();
                
                initialTime = currentTime;

                // Si la barra de progreso ha alcanzado el 100%, pasa a la siguiente
                currentListProcessIndex++;

                // Si hemos llegado al final de la lista, reinicia desde el principio
                if (currentListProcessIndex >= listProcesses.Count)
                {
                    progressBarUpdateTimer.Stop();
                }
            }
        }*/

        private void ProgressBarUpdateTimer_Tick(object sender, EventArgs e)
        {
            ListProcess currentListProcess = listProcesses[currentListProcessIndex];

            // Si la barra de progreso actual no ha alcanzado el 100%
            if (currentListProcess.ProgressBarValue < 100)
            {
                // Incrementa la barra de progreso en 10
                currentListProcess.ProgressBarValue += 10;

                currentTime += (float) stopwatch.Elapsed.TotalSeconds;
            }
            else
            {

                //Actualizar los datos de los procesos y de los páneles de procesos

                processes[currentListProcessIndex].State = RegProcess.ProcessState.Terminated;
                listProcesses[currentListProcessIndex].State = RegProcess.ProcessState.Terminated.ToString();

                processes[currentListProcessIndex].WaitTime = initialTime % 2;
                listProcesses[currentListProcessIndex].WaitTime = initialTime.ToString();


                processes[currentListProcessIndex].BurstTime = currentTime % 2;
                listProcesses[currentListProcessIndex].BurstTime = currentTime.ToString();

                initialTime = currentTime;

                // Si la barra de progreso ha alcanzado el 100%, pasa a la siguiente
                currentListProcessIndex++;

                // Si hemos llegado al final de la lista, reinicia desde el principio
                if (currentListProcessIndex >= listProcesses.Count)
                {
                    progressBarUpdateTimer.Stop();
                }
            }
        }


        public List<RegProcess> Processes { get => processes; set => processes = value; }
        public List<ListProcess> ListProcesses { get => listProcesses; set => listProcesses = value; }
    }
}
