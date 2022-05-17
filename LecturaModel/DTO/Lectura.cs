using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaModel
{
    public class Lectura
    {
        private string idMedidor;
        private DateTime fechaIngreso;
        private string valorConsumo;

        public string IdMedidor { get => idMedidor; set => idMedidor = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string ValorConsumo { get => valorConsumo; set => valorConsumo = value; }

        public override string ToString()
        {
            return idMedidor + " " + fechaIngreso + " " + valorConsumo;
        }


    }
}
