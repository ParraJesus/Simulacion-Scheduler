using System.Diagnostics;
using static System.Windows.Forms.AxHost;

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

        public Processor()
        {

        }

        public void processingProcesses()
        {
            foreach (RegProcess process in processes)
            {
                process.State = RegProcess.ProcessState.Running;

                //process.WaitTime = (float)stopwatch.Elapsed.TotalSeconds;

            }
        }

        public List<RegProcess> Processes { get => processes; set => processes = value; }
    }
}
