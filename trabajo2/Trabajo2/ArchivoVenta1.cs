using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo2.BIZ;
using Trabajo2.Dal;
using Trabajo2.COMMON.Entidades;

namespace Trabajo2
{
    class ArchivoVenta1
    {
        ManejadorVales manejadorVales = new ManejadorVales(new RepositorioVale());
        public bool Genrar(string nombreCliente, string RFC, string Tel, string Direccion, string Email, string Empleado, List<Vale> listar, string[] Medicamentos, string ruta, int contador, double totalPagar, double DineroRecibido, double cambio, double[] Costos)
        {

            try
            {
                StreamWriter archivo = new StreamWriter(nombreCliente);
                archivo.WriteLine("Mi Pequeño Enfermito");
                archivo.WriteLine("Fecha: " + DateTime.Now.ToLongDateString());
                archivo.WriteLine("Cliente: " + nombreCliente);
                archivo.WriteLine("RFC: " + RFC);
                archivo.WriteLine("Telefono: " + Tel);
                archivo.WriteLine("Direccion: " + Direccion);
                archivo.WriteLine("Email: " + Email);
                archivo.WriteLine("Empeado: " + Empleado);
                archivo.WriteLine("Total a Pagar: {0}", totalPagar);
                archivo.WriteLine("Dinero Recibido: {0}", DineroRecibido);
                archivo.WriteLine("Cambio: {0}", cambio);
                archivo.WriteLine();
                archivo.WriteLine("================================================");
                archivo.WriteLine("Lista de medicamentos comprados");

                for (int i = 1; i < contador; i++)
                {
                    archivo.WriteLine("{0}--{1}", Medicamentos[i], Costos[i + 1]);
                }
                archivo.WriteLine();

                // archivo.WriteLine("\nCant.\tDescripcion\tPrecio\tImporte");


                /* for (int filas = 0; filas < datos.GetLength(1); filas++)
                 {
                     for (int columnsa = 0; columnsa < datos.GetLength(0); columnsa++)
                     {
                         archivo.Write("{0}\t", datos[columnsa, filas]);
                     }
                     archivo.WriteLine();
                 }*/
                /*archivo.WriteLine("total: $" + cantidadVenta);
                archivo.WriteLine("Su pago: $" + cantidad);
                archivo.WriteLine("Cambio: $" + cambio);*/
                archivo.WriteLine("--------------GRACIAS POR COMPRAR CON NOSOTROS-----------------");
                archivo.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }





        /* internal bool Genrar(string text1, string text2, string text3, string text4, string v)
         {
             throw new NotImplementedException();
         }*/
    }
}
