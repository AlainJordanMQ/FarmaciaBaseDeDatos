using System;
using System.Collections.Generic;
using System.Text;

namespace Trabajo2.COMMON.Entidades
{
    public class Medicamentos: Base
    {
        public double CantidadVenta { get; set; }
        public double CantidadCompra { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }


        public override string ToString()
        {

            return Nombre + "||" + Categoria;

        }
    }
}
