using Simulador_Scheduler;
using System.Diagnostics;

/*
 * 
 * HECHO POR JESUS GABRIEL PARRA
 * Laboratorio de sistemas operativos
 * 
 */

namespace Scheduler_Simulator.Logica
{

    public static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new GuiScheduler());       
        }
    }
}