using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace InterfaceInconsistenciasVentas
{
    public class InterfaceInconsistenciasVentasPSAM
    {
        public void IniciarEnvioInconsistencias()
        {
            HttpClient client = new HttpClient();
            string URI = ConfigurationManager.AppSettings["uriBase"].ToString();
            client.BaseAddress = new System.Uri(URI);
            client.DefaultRequestHeaders.Accept.Clear();

            #region USP_LISTA_VENTAS_DIFERENCIAS_CANTIDAD_BDI_OFISIS
            var VentasDiferenciasCantidadResponse = JsonConvert.DeserializeObject(GetSync($"/api/VentasDiferenciasCantidad?envioCorreo=true", client));
            #endregion

            #region USP_LISTA_HUECOS_FACTURACION
            var HuecosFacturacionResponse = JsonConvert.DeserializeObject(GetSync($"/api/HuecosFacturacion?envioCorreo=true", client));
            #endregion

            #region USP_LISTA_VENTAS_DIFERENCIAS_MONTOS_BDI_OFISIS
            var VentasDiferenciasMontosResponse = JsonConvert.DeserializeObject(GetSync($"/api/VentasDiferenciasMontos?envioCorreo=true", client));
            #endregion
        }
        private string GetSync(string apiMetodo, HttpClient http)
        {
            string retorno = "";

            try
            {
                var response = http.GetAsync(apiMetodo).Result;

                if (response.IsSuccessStatusCode)
                {
                    retorno = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    retorno = "";
                }
            }
            catch (Exception ex)
            {
                return retorno = "Error crítico: " + ex.Message;

            }

            return retorno;
        }
    }
}
