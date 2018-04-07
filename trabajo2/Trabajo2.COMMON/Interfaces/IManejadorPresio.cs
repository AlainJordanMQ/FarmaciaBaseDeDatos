using System;
using System.Collections.Generic;
using System.Text;
using Trabajo2.COMMON.Entidades;

namespace Trabajo2.COMMON.Interfaces
{
    public interface IManejadorPresio : IManejadorGenerico<Presio>
    {
        List<Presio> MedicamentosDeCategoria(string categoria);
    }
}
