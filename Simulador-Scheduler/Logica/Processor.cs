using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Processor(){ }

        public Processor(List<RegProcess> processes)
        {
            this.Processes = processes;
        }

        public void processingProcesses()
        {
            Random random = new Random();

            int numeroAleatorio = random.Next(1, 101);

            Debug.WriteLine("Procesador: ");

            foreach (RegProcess process in processes)
            {
                double probabilidad = random.NextDouble();

                if (probabilidad < 0.90)
                {
                    process.State = RegProcess.ProcessState.Running;
                }
                else if (probabilidad < 0.97)
                {
                    process.State = RegProcess.ProcessState.Blocked;
                }
                else
                {
                    process.State = RegProcess.ProcessState.Terminated;
                }

                Debug.WriteLine("Proceso: " + process.State.ToString());
            }
        }

        public List<RegProcess> Processes { get => processes; set => processes = value; }
    }
}
