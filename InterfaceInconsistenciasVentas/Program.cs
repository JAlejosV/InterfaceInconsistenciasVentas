using System;

namespace InterfaceInconsistenciasVentas
{
    class Program
    {
        static void Main(string[] args)
        {
            InterfaceInconsistenciasVentasPSAM interfaceInconsistenciasVentasPSAM = new InterfaceInconsistenciasVentasPSAM();

            try
            {
                interfaceInconsistenciasVentasPSAM.IniciarEnvioInconsistencias();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
