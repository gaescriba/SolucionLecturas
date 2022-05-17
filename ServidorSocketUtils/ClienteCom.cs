using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServidorSocketUtils
{
    public class ClienteCom
    {
        private Socket client;
        private StreamReader reader;
        private StreamWriter writer;
        public ClienteCom(Socket socket)
        {
            this.client = socket;
            Stream stream = new NetworkStream(this.client);
            this.reader = new StreamReader(stream);
            this.writer = new StreamWriter(stream);
        }

        //<CR><LF>
        public bool Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public String Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Desconectar()
        {
            try
            {
                this.client.Close();
            }
            catch (Exception ex)
            {

            }
        }



    }
}
