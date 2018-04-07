using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo2.COMMON.Entidades;
using Trabajo2.COMMON.Interfaces;

namespace Trabajo2.BIZ
{
    public class ManejadorMedicamentos : IManejadorMedicamentos
    {
        IRepositorio<Medicamentos> repositorio;
        public ManejadorMedicamentos(IRepositorio<Medicamentos> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Medicamentos> Listar => repositorio.Read;

        public bool Agregar(Medicamentos entidad)
        {
            return repositorio.Create(entidad);
        }

        public Medicamentos BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }

        public List<Medicamentos> MedicamentosDeCategoria(string categoria)
        {
            return Listar.Where(e => e.Categoria == categoria).ToList();
        }

        public bool Modificar(Medicamentos entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
