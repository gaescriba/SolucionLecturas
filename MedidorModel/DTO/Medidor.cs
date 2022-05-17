using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorModel
{
    public class Medidor
    {
        private string idMedidor;

        public string IdMedidor { get => idMedidor; set => idMedidor = value; }

        public override string ToString()
        {
            return idMedidor;
        }


    }
}
