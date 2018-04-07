using System;
using System.Collections.Generic;
using System.Text;

namespace Trabajo2.COMMON.Entidades
{
    public class Empleado:Base
    {
        public string Nombre { get; set; }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
