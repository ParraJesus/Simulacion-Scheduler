using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 
 * HECHO POR JESUS GABRIEL PARRA
 * LABORATORIO DE SISTEMAS OPERATIVOS
 * 
 */

namespace Scheduler_Simulator.Logica
{
    public class RegProcess
    {
        #region Attributes
        public enum ProcessState
        {
            Waiting,        //Esperando
            Running,        //Ejecutando
            Blocked,        //Bloqueado
            Terminated      //Terminado
        }

        private string name = "";
        private int priority = 1;
        private float waitTime = 0; //Tiempo de espera
        private float burstTime = 0; //Tiempo de ráfaga
        private ProcessState state = ProcessState.Waiting;
        #endregion

        #region Constructor
        public RegProcess(){}

        public RegProcess(string name, int priority)
        {
            this.name = name;
            this.priority = priority;
        }
        #endregion

        #region GetSet
        public string Name { get => name; set => name = value; }
        public int Priority { get => priority; set => priority = value; }
        public float WaitTime { get => waitTime; set => waitTime = value; }
        public float BurstTime { get => burstTime; set => burstTime = value; }
        public ProcessState State { get => state; set => state = value; }
        #endregion

    }
}
