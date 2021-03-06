﻿using System;
using System.Collections.Generic;
using System.Text;
using Trabajo2.COMMON.Entidades;

namespace Trabajo2.COMMON.Interfaces
{
   public  interface IManejadorMedicamentos : IManejadorGenerico<Medicamentos>
    {
        List<Medicamentos> MedicamentosDeCategoria(string categoria);
    }
}
