using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaTerminalPuntoVentas
{
    static class Program
    {
        /// <summary>
        /// Parámetros requeridos de la aplicación
        /// Vista es el punto deentrada a la aplicación en donde se realizan las actividades del software.
        /// </summary>
        private static CapaVista.Vista Vista;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            start();
        }

        public static void start(){
            Vista = new CapaVista.Vista();
            while(Vista.Cerrar.Equals(false)){
                Vista.Iniciar();
            }
            GC.Collect();
        }
    }
}
