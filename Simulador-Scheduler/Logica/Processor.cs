using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler_Simulator.Logica
{
    internal class Processor
    {
        private List<Process> processes = new List<Process>();

        public Processor(){}

        public Processor(List<Process> processes)
        {
            this.Processes = processes;
        }

        public void Process() 
        {
            Process process = new Process();
            for(int i = 0; i < processes.Count; i++) 
            {
                process = processes[i];

                switch (process.State) 
                {
                    case Logica.Process.ProcessState.Waiting:
                        process.State = Logica.Process.ProcessState.Running;
                        break;

                    case Logica.Process.ProcessState.Blocked:
                        process.State = Logica.Process.ProcessState.Running;
                        break;
                }
            }
        }

        public List<Process> Processes { get => processes; set => processes = value; }
    }
}
