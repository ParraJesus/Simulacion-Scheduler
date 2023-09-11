using Simulador_Scheduler;
using System.Diagnostics;

namespace Scheduler_Simulator.Logica
{

    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Process p1 = new Process("a", 1, Process.ProcessState.Waiting);
            Process p2 = new Process("b", 2, Process.ProcessState.Waiting);
            Process p3 = new Process("c", 3, Process.ProcessState.Waiting);
            Process p4 = new Process("d", 4, Process.ProcessState.Waiting);
            Process p5 = new Process("e", 5, Process.ProcessState.Waiting);

            Processor pr1 = new Processor();
            Processor pr2 = new Processor();
            Processor pr3 = new Processor();

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            // Crear la lista de procesos y procesadores
            List<Process> processes = new List<Process>{p1, p2, p3, p4, p5};  // Aquí agregas tus procesos
            List<Processor> processors = new List<Processor> { pr1, pr2, pr3};  // Aquí agregas tus procesadores

            // Crear una instancia de Scheduler y distribuir los procesos
            Scheduler scheduler = new Scheduler(processors, processes);
            scheduler.DistributeProcesses();
            scheduler.showProcesses(0);
            scheduler.showProcesses(1);
            scheduler.showProcesses(2);
        }
    }
}