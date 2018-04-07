using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabajo2.COMMON.Entidades;
using Trabajo2.COMMON.Interfaces;

namespace Trabajo2.Dal
{
   public  class RepositorioMedicamentos : IRepositorio<Medicamentos>
    {
        private string DBName = "Trabajo.db";
        private string TableName = "Medicamentos";
        public List<Medicamentos> Read
        {
            get
            {
                List<Medicamentos> datos = new List<Medicamentos>();
                using (var db = new LiteDatabase(DBName))
                {
                    datos = db.GetCollection<Medicamentos>(TableName).FindAll().ToList();
                }
                return datos;
            }
        }

        public bool Create(Medicamentos entidad)
        {
            entidad.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Medicamentos>(TableName);
                    coleccion.Insert(entidad);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                int r;
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Medicamentos>(TableName);
                    r = coleccion.Delete(e => e.Id == id);
                }
                return r > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(Medicamentos entidadModificada)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var coleccion = db.GetCollection<Medicamentos>(TableName);
                    coleccion.Update(entidadModificada);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
