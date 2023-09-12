using Simulador_Scheduler;
using System.Diagnostics;

/*
 * 
 * HECHO POR JESUS GABRIEL PARRA
 * 
 */

namespace Scheduler_Simulator.Logica
{

    public static class Program
    {
        [STAThread]
        static void Main()
        {
            /*
            RegProcess p1 = new RegProcess("a", 1);
            RegProcess p2 = new RegProcess("b", 2);
            RegProcess p3 = new RegProcess("c", 3);
            RegProcess p4 = new RegProcess("d", 4);
            RegProcess p5 = new RegProcess("e", 5);

            Processor pr1 = new Processor();
            Processor pr2 = new Processor();
            Processor pr3 = new Processor();

            // Crear la lista de procesos y procesadores
            List<RegProcess> processes = new List<RegProcess> { p1, p2, p3, p4, p5 };  // Aquí agregas tus procesos
            List<Processor> processors = new List<Processor> { pr1 , pr2};  // Aquí agregas tus procesadores

            // Crear una instancia de Scheduler y distribuir los procesos
            Scheduler scheduler = new Scheduler(processors, processes);
            */

            ApplicationConfiguration.Initialize();
            Application.Run(new GuiScheduler());       
        }
    }
}