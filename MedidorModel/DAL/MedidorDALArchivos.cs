using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel.DAL
{
    public class MedidorDALArchivos : IMedidorDAL
    {
        private MedidorDALArchivos() { }
        private static MedidorDALArchivos instancia;
        public static IMedidorDAL GetInstancia()
        {
            if (instancia == null)
            {

                instancia = new MedidorDALArchivos();


            }
            return instancia;

        }

        private static string url = Directory.GetCurrentDirectory();
        private static string archivo = url + "/Medidores.txt";

        public List<Medidor> ObtenerMedidores()
        {
            List<Medidor> lista = new List<Medidor>();
            Medidor medidor1 = new Medidor();
            Medidor medidor2 = new Medidor();
            Medidor medidor3 = new Medidor();
            medidor1.IdMedidor = "1234";
            medidor2.IdMedidor = "5678";
            medidor3.IdMedidor = "9012";
            lista.Add(medidor1);
            lista.Add(medidor2);
            lista.Add(medidor3);
            return lista;
        }



    }
}
