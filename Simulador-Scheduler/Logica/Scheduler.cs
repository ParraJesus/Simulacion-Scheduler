using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace Scheduler_Simulator.Logica
{
    internal class Scheduler
    {
        List<Process> processes= new List<Process>(); //Lista de procesos que se van a manejar
        List<Processor> processors= new List<Processor>(); //Lista de procesadores con los que se van a trabajar

        public Scheduler(List<Processor> processors, List<Process> processes) 
        {
            this.processors = processors;
            this.processes = processes;

            this.processes = orderbyPriority();
        }

        //Método para ordenar los procesos por prioridad
        public List<Process> orderbyPriority() 
        {
            List<Process> sortedProcesses = processes.OrderByDescending(p => p.Priority).ToList();
            return sortedProcesses;
        }

        //Distribuir para cada procesador un número igual de procesos
        public void DistributeProcesses()
        {
            Debug.WriteLine("Total de procesadores: " + processors.Count);
            Debug.WriteLine("Total de procesos: " + processes.Count);

            int totalProcessors = processors.Count;                         //Total de procesadores
            int processesPerProcessor = processes.Count / totalProcessors;  //Total de Procesos para cada procesador
            int remainingProcesses = processes.Count % totalProcessors;     //Residuo, si lo hay

            int startIndex = 0;

            foreach (var processor in processors) //Para cada procesador dentro de la lista
            {
                int numProcesses = processesPerProcessor;

                if (remainingProcesses > 0)
                {
                    numProcesses++;
                    remainingProcesses--;   //Se deshace del residuo cuando el número de procesos es impar
                }

                List<Process> processesForProcessor = processes.GetRange(startIndex, numProcesses);
                processor.Processes = processesForProcessor;
                startIndex += numProcesses;

                Debug.WriteLine("procesos del procesador: " + processor.Processes.Count);
            }
        }

        public void showProcesses(int procesor) 
        {
            Debug.WriteLine("procesos dentro del procesador " + procesor + ": ");

            for (int i = 0; i < processors[procesor].Processes.Count; i++)
            {
                    Debug.WriteLine(processors[procesor].Processes[i].Name + ", " + processors[procesor].Processes[i].Priority);
            }
        }

        #region GetSet
        public List<Process> Processes { get => processes; set => processes = value; }
        public List<Processor> Processors { get => processors; set => processors = value; } 
        #endregion
    }
}
