using System.Diagnostics;

/*
 * 
 * HECHO POR JESUS GABRIEL PARRA
 * 
 */

namespace Scheduler_Simulator.Logica
{
    public class Scheduler
    {

        #region Attributes
        List<RegProcess> processes = new List<RegProcess>(); //Lista de procesos que se van a manejar
        List<Processor> processors = new List<Processor>(); //Lista de procesadores con los que se van a trabajar

        List<int> processesIndex = new List<int>(); //Lista de índices que relacionan los procesadores con los procesos 
        #endregion

        #region Constructors

        //Constructor para cuando se quieren asignar los procesos de manera automática
        public Scheduler(List<Processor> processors, List<RegProcess> processes)
        {
            this.processors = processors;
            this.processes = processes;

            assignProcessesAutomatically();
        }

        //Constructor para cuando se quieren asignar los procesos de manera manual
        public Scheduler(List<Processor> processors, List<RegProcess> processes, List<int> processesIndex)
        {
            this.processors = processors;
            this.processes = processes;
            this.processesIndex = processesIndex;

            assignProcessesManually();
        } 
        #endregion

        //Método para ordenar los procesos por prioridad
        public List<RegProcess> orderbyPriority()
        {
            List<RegProcess> sortedProcesses = processes.OrderByDescending(p => p.Priority).ToList();
            return sortedProcesses;
        }

        //Distribuir para cada procesador un número igual de procesos
        public void assignProcessesAutomatically()
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

                List<RegProcess> processesForProcessor = processes.GetRange(startIndex, numProcesses);
                processor.Processes = processesForProcessor;
                startIndex += numProcesses;

                Debug.WriteLine("procesos del procesador: " + processor.Processes.Count);
            }
        }

        //El usuario puede escoger a qué procesador va cada proceso
        public void assignProcessesManually()
        {
            for (int i = 0; i < processes.Count; i++)
            {
                int index = processesIndex[i];

                if (index >= 0 && index < processors.Count)
                {
                    if (processors[index].Processes == null)
                    {
                        processors[index].Processes = new List<RegProcess>();
                    }

                    processors[index].Processes.Add(processes[i]);
                }
                else
                {
                    Console.WriteLine("Error: El índice de procesador está fuera de rango para el proceso en la posición " + i);
                }
            }
        }

        //Imprime todos los procesos dentro de un procesador
        public void showProcesses(int procesor) 
        {
            if (procesor < processors.Count)
            {
                Debug.WriteLine("procesos dentro del procesador " + procesor + ": ");

                for (int i = 0; i < processors[procesor].Processes.Count; i++)
                {
                    Debug.WriteLine(processors[procesor].Processes[i].Name + ", " + processors[procesor].Processes[i].Priority);
                }
            }
            else Debug.WriteLine("No existe tal procesador");
        }

        #region GetSet
        public List<RegProcess> Processes { get => processes; set => processes = value; }
        public List<Processor> Processors { get => processors; set => processors = value; } 
        #endregion
    }
}
