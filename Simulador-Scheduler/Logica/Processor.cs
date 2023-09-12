using System;
using System.Collections.Generic;
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

        public Processor(){}

        public Processor(List<RegProcess> processes)
        {
            this.Processes = processes;
        }

        public void Process() 
        {
            RegProcess process = new RegProcess();
            for(int i = 0; i < processes.Count; i++) 
            {
                process = processes[i];

                switch (process.State) 
                {
                    case Logica.RegProcess.ProcessState.Waiting:
                        process.State = Logica.RegProcess.ProcessState.Running;
                        break;

                    case Logica.RegProcess.ProcessState.Blocked:
                        process.State = Logica.RegProcess.ProcessState.Running;
                        break;
                }
            }

            
        }

        public List<RegProcess> Processes { get => processes; set => processes = value; }
    }
}
