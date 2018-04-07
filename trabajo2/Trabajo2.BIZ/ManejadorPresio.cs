using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo2.COMMON.Entidades;
using Trabajo2.COMMON.Interfaces;

namespace Trabajo2.BIZ
{
    public class ManejadorPresio : IManejadorPresio
    {
         IRepositorio<Presio> repositorio;
        public ManejadorPresio(IRepositorio<Presio> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Presio> Listar => repositorio.Read;

        public bool Agregar(Presio entidad)
        {
            return repositorio.Create(entidad);
        }

        public Presio BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }

        public List<Presio> MedicamentosDeCategoria(string categoria)
        {
            return Listar.Where(e => e.Categoria == categoria).ToList();
        }

        public bool Modificar(Presio entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
