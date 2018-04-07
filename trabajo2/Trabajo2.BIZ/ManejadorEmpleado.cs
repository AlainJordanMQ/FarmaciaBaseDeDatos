using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo2.COMMON.Entidades;
using Trabajo2.COMMON.Interfaces;

namespace Trabajo2.BIZ
{
    public class ManejadorEmpleado : IManejadorEmpleados
    {
        IRepositorio<Empleado> repositorio;
        public ManejadorEmpleado(IRepositorio<Empleado> repo)
        {
            repositorio = repo;

        }

        public List<Empleado> Listar => repositorio.Read;

        public bool Agregar(Empleado entidad)
        {
            return repositorio.Create(entidad);
        }

        public Empleado BuscarPorId(string id)
        {
            return Listar.Where(e => e.Id == id).SingleOrDefault();
        }

        public bool Eliminar(string id)
        {
            return repositorio.Delete(id);
        }

        public bool Modificar(Empleado entidad)
        {
            return repositorio.Update(entidad);
        }
    }
}
