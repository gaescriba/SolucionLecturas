using System;
using LecturaModel;
using ServidorSocketUtils;
using LecturaModel.DAL;
using MedidorModel;
using MedidorModel.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Sockets;
using System.Threading;

namespace SolucionLecturas.Comunicacion
{
    public class HebraServidor
    {
        private ILecturaDAL lecturaDAL = LecturaDALArchivos.GetInstancia();
        public void Ejecutar()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            ServerSocket serverSocket = new ServerSocket(puerto);
            Console.WriteLine("Iniciando server en el puerto {0}", puerto);
            if (serverSocket.Start())
            {
                while (true)
                {
                    Console.WriteLine("Esperando Cliente...");
                    Socket cliente = serverSocket.ObtenerCliente();
                    Console.WriteLine("Cliente recibido");

                    //esto estaba en generar comunicacion
                    ClienteCom clienteCom = new ClienteCom(cliente);
                    HebraCliente clienteThread = new HebraCliente(clienteCom);
                    Thread t = new Thread(new ThreadStart(clienteThread.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                }
            }
            else
            {
                Console.WriteLine("No se puede levantar server en {0}", puerto);
            }
        }
    }
}

