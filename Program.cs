using LecturaModel.DAL;
using LecturaModel;
using MedidorModel;
using MedidorModel.DAL;
using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolucionLecturas.Comunicacion;
using System.Threading;

namespace SolucionLecturas
{
    class Program
    {
        private static ILecturaDAL lecturaDAL = LecturaDALArchivos.GetInstancia();
        private static IMedidorDAL medidorDAL = MedidorDALArchivos.GetInstancia();
        static bool Menu()
        {

            bool continuar = true;
            Console.WriteLine("Igrese opcion");
            Console.WriteLine("########################################");
            Console.WriteLine("1. Ingresar \n 2. Mostrar \n 3. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Ingresar();
                    break;
                case "2":
                    Mostrar();
                    break;
                case "3":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Ingrese de nuevo");
                    break;
            }
            return continuar;


        }


        public static void Main(String[] args)
        {

            HebraServidor hebra = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.Start();

            while (Menu()) ;
        }

        static void Ingresar()
        {
            bool containsSearchResult = false;
            Console.WriteLine("Ingrese identificador de medidor: ");
            string medidor = Console.ReadLine().Trim();

            List<Medidor> medidora = null;
            lock (medidorDAL)
            {
                medidora = medidorDAL.ObtenerMedidores();
            }
            while (!containsSearchResult)
            {
                for (int i = 0; i < medidora.Count; i++)
                {

                    if (containsSearchResult = medidora[i].ToString().Equals(medidor))
                    {
                        break;

                    }
                }
                if (containsSearchResult == true)
                {
                    break;

                }
                else
                {
                    Console.WriteLine("idetificador invalido, intente nuevamente ");
                    medidor = Console.ReadLine().Trim();
                }
            }
            Console.WriteLine("Ingrese Fecha de ingresos:");
            string fecha = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese valor de consumo :");
            string consumo = Console.ReadLine().Trim();
            Lectura lectura = new Lectura()
            {
                IdMedidor = medidor,
                FechaIngreso = (DateTime)Convert.ChangeType(fecha, typeof(DateTime)),
                ValorConsumo = consumo
            };

            lock (lecturaDAL)
            {
                lecturaDAL.AgregarLectura(lectura);
            }

        }

        static void Mostrar()
        {
            List<Lectura> lecturas = null;
            lock (lecturaDAL)
            {
                lecturas = lecturaDAL.ObtenerLecturas();
            }
            foreach (Lectura lectura in lecturas)
            {
                Console.WriteLine(lectura);
            }
        }

    }
}
