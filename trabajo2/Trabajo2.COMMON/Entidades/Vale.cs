using System;
using System.Collections.Generic;
using System.Text;

namespace Trabajo2.COMMON.Entidades
{
    public class Vale:Base
    {
        public string Rfc { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Cliente { get; set; }
        // public DateTime FechaHora { get; set; }
        //public List<Medicamentos> medicamentosV { get; set; }
        public override string ToString()
        {
            return Rfc + Telefono;
        }
    }
}
