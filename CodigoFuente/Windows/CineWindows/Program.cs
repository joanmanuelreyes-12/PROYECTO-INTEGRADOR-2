using System;
using System.Windows.Forms;

namespace ProyectoIntegrador2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormPrincipal());
        }
    }
}
