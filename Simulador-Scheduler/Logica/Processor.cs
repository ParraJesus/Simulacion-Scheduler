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
        #region Attributes
        //registro de procesos que maneja el procesador 
        private List<RegProcess> processes = new List<RegProcess>();

        //Variables que controlan los páneles de la experiencia de usuario
        private List<ListProcess> listProcesses = new List<ListProcess>();
        private System.Windows.Forms.Timer progressBarUpdateTimer;
        private int currentListProcessIndex = 0;

        //Variables para medir el tiempo en ejecución
        private float initialTime = 0;
        private float currentTime = 0;
        private Stopwatch stopwatch = new Stopwatch(); 
        #endregion

        public Processor()
        {
            //Instancia el timer
            progressBarUpdateTimer = new System.Windows.Forms.Timer();
            progressBarUpdateTimer.Interval = 500; //tiempo en milisegundos
            progressBarUpdateTimer.Tick += ProgressBarUpdateTimer_Tick;
        }

        public void processingProcesses()
        {
            //Cuando llega al procesador, el proceso se cambia de estado a ejecutando
            foreach (var process in processes) 
            {
                process.State = RegProcess.ProcessState.Running;
            }

            //Comienza la cuenta del tiempo y el timer
            progressBarUpdateTimer.Start();
            stopwatch.Start();
        }

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

                //Cuando termina todo el ciclo de una barra de carga, se iguala el tiempo inicial con tiempo total
                //Ahora el tiempo inicial es el tiempo total anterior
                initialTime = currentTime;

                // Si la barra de progreso ha alcanzado el 100%, pasa a la siguiente
                currentListProcessIndex++;

                // Cuando se llega al final de la lista, se detiene el Timer y el stopWatch
                if (currentListProcessIndex >= listProcesses.Count)
                {
                    progressBarUpdateTimer.Stop();
                    stopwatch.Stop();
                }
            }
        }


        #region GetSet
        public List<RegProcess> Processes { get => processes; set => processes = value; }
        public List<ListProcess> ListProcesses { get => listProcesses; set => listProcesses = value; } 
        #endregion
    }
}
