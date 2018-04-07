using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Trabajo2.BIZ;
using Trabajo2.COMMON.Entidades;
using Trabajo2.COMMON.Interfaces;
using Trabajo2.Dal;

namespace Trabajo2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }

        IManejadorEmpleados manejadorEmpleados;

        accion accionEmpleados;
        public MainWindow()
        {
            InitializeComponent();
            PonerBotonesEmpleadosEnEdicion(false);
            PonerBotonesMedicamentosEnEdicion(false);
            PonerBotonesValeEnEdicion(false);

            LimpiarCamposDeEmpleados();
            LimpiarCamposoDeMedicamentos();
            LimpiarCamposDeVales();


            manejadorEmpleados = new ManejadorEmpleado(new RepositorioEmpleados());
            manejadorMedicamentos = new ManejadorMedicamentos(new RepositorioMedicamentos());
            manejadorVales = new ManejadorVales(new RepositorioVale());
            ManejadorPresio manejadorPresio = new ManejadorPresio(new RepositorioPresio());

            ActualizarTablaEmpleados();
            ActualizarTablaMedicamentos();
            ActualizarTablaVales();

            cmbVentaPresio.ItemsSource = manejadorPresio.Listar;
            cmbVentaEmpleado.ItemsSource = manejadorEmpleados.Listar;
            cmbVentaMedicamento.ItemsSource = manejadorMedicamentos.Listar;

        }
        private void PonerBotonesValeEnEdicion(bool value)
        {
            btnVentaCancelar.IsEnabled = value;
            btnVentaAceptar.IsEnabled = value;
            btnVentaGenerarVenta.IsEnabled = value;
            btnVentaCalcular.IsEnabled = value;
            btnVentaTotalPagar.IsEnabled = value;
            //  btnVentaSeguirConVenta.IsEnabled = value;
            btnVentaNueva.IsEnabled = !value;
            btnVentaEliminar.IsEnabled = !value;

            txbValeCliente.IsEnabled = value;
            txbValeDireccion.IsEnabled = value;
            txbValeEmail.IsEnabled = value;
            txbValeRFC.IsEnabled = value;
            txbValeTel.IsEnabled = value;
            txbVentaCambio.IsEnabled = value;
            txbVentaDinaroRecibido.IsEnabled = value;
            txbVentaTotalPagar.IsEnabled = value;

            cmbVentaEmpleado.IsEnabled = value;
            cmbVentaMedicamento.IsEnabled = value;
            cmbVentaPresio.IsEnabled = value;
        }

        private void ActualizarTablaVales()
        {
            dtgVale.ItemsSource = null;
            dtgVale.ItemsSource = manejadorVales.Listar;
        }

        private void LimpiarCamposDeVales()
        {
            txbValeCliente.Clear();
            txbValeDireccion.Clear();
            txbValeEmail.Clear();
            txbValeRFC.Clear();
            txbValeTel.Clear();
            txbVentaCambio.Clear();
            txbVentaDinaroRecibido.Clear();
            txbVentaTotalPagar.Clear();

        }

        private void ActualizarTablaMedicamentos()
        {
            dtgMedicamentos.ItemsSource = null;
            dtgMedicamentos.ItemsSource = manejadorMedicamentos.Listar;
        }

        private void LimpiarCamposoDeMedicamentos()
        {
            txbMedicamentosCantidadCompra.Clear();
            txbMedicamentosCantidadVenta.Clear();
            txbMedicamentosCategoria.Clear();
            txbMedicamentosDescripcion.Clear();
            txbMedicamentosId.Text = "";
            txbMedicamentosNombre.Clear();
        }

        private void PonerBotonesMedicamentosEnEdicion(bool value)
        {
            btnMedicamentosCancelar.IsEnabled = value;
            btnMedicamentosEditar.IsEnabled = !value;
            btnMedicamentosEliminar.IsEnabled = !value;
            btnMedicamentosGuardar.IsEnabled = value;
            btnMedicamentosNuevo.IsEnabled = !value;

            txbMedicamentosCantidadCompra.IsEnabled = value;
            txbMedicamentosCantidadVenta.IsEnabled = value;
            txbMedicamentosCategoria.IsEnabled = value;
            txbMedicamentosDescripcion.IsEnabled = value;
            txbMedicamentosNombre.IsEnabled = value;
        }

        private void ActualizarTablaEmpleados()
        {
            dtgEmpleaods.ItemsSource = null;
            dtgEmpleaods.ItemsSource = manejadorEmpleados.Listar;
        }

        private void LimpiarCamposDeEmpleados()
        {
            txbEmpleadosNombre.Clear();
            txbEmpleadosId.Text = "";
        }

        private void PonerBotonesEmpleadosEnEdicion(bool value)
        {
            btnEmpleadosCancelar.IsEnabled = value;
            btnEmpleadosEditar.IsEnabled = !value;
            btnEmpleadosEliminar.IsEnabled = !value;
            btnEmpleadosGuardar.IsEnabled = value;
            btnEmpleadosNuevo.IsEnabled = !value;

            txbEmpleadosNombre.IsEnabled = value;
        }
        //==========================================================================================================================================

        private void btnEmpleadosNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados();
            PonerBotonesEmpleadosEnEdicion(true);
            accionEmpleados = accion.Nuevo;

        }

        private void btnEmpleadosEditar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = dtgEmpleaods.SelectedItem as Empleado;
            if (emp != null)
            {
                txbEmpleadosId.Text = emp.Id;
                txbEmpleadosNombre.Text = emp.Nombre;
                accionEmpleados = accion.Editar;
                PonerBotonesEmpleadosEnEdicion(true);
            }

        }

        private void btnEmpleadosGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionEmpleados == accion.Nuevo)
            {
                Empleado emp = new Empleado()
                {
                    Nombre = txbEmpleadosNombre.Text
                };
                if (manejadorEmpleados.Agregar(emp))
                {
                    MessageBox.Show("Empleado agregado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEmpleados();
                    ActualizarTablaEmpleados();
                    PonerBotonesEmpleadosEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("Empleado No se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empleado emp = dtgEmpleaods.SelectedItem as Empleado;
                emp.Nombre = txbEmpleadosNombre.Text;
                if (manejadorEmpleados.Modificar(emp))
                {
                    MessageBox.Show("Empleado modificado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeEmpleados();
                    ActualizarTablaEmpleados();
                    PonerBotonesEmpleadosEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("Empleado No se pudo actualizar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void btnEmpleadosCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeEmpleados();
            PonerBotonesEmpleadosEnEdicion(false);
        }

        private void btnEmpleadosEliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = dtgEmpleaods.SelectedItem as Empleado;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este empleado", "Trabajo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorEmpleados.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Empleado eliminado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el empleado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        //==========================================================================================================================================================================
        enum accionMe
        {
            Nuevo,
            Editar
        }

        IManejadorMedicamentos manejadorMedicamentos;

        accionMe accionMedicamentos;
        private void btnMedicamentosNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposoDeMedicamentos();
            PonerBotonesMedicamentosEnEdicion(true);
            accionMedicamentos = accionMe.Nuevo;
        }

        private void btnMedicamentosEditar_Click(object sender, RoutedEventArgs e)
        {

            Medicamentos med = dtgMedicamentos.SelectedItem as Medicamentos;
            if (med != null)
            {
                txbMedicamentosId.Text = med.Id;
                txbMedicamentosNombre.Text = med.Nombre;
                txbMedicamentosCantidadCompra.Text = Convert.ToString(med.CantidadCompra);
                txbMedicamentosCantidadVenta.Text = Convert.ToString(med.CantidadVenta);
                txbMedicamentosCategoria.Text = med.Categoria;
                txbMedicamentosDescripcion.Text = med.Descripcion;


                accionMedicamentos = accionMe.Editar;
                PonerBotonesMedicamentosEnEdicion(true);
            }
        }

        private void btnMedicamentosGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionMedicamentos == accionMe.Nuevo)
            {
                Medicamentos med = new Medicamentos()
                {
                    Nombre = txbMedicamentosNombre.Text,
                    CantidadCompra = double.Parse(txbMedicamentosCantidadCompra.Text),
                    CantidadVenta = double.Parse(txbMedicamentosCantidadVenta.Text),
                    Categoria = txbMedicamentosCategoria.Text,
                    Descripcion = txbMedicamentosDescripcion.Text

                };
                if (manejadorMedicamentos.Agregar(med))
                {
                    MessageBox.Show("Medicamento agregado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposoDeMedicamentos();
                    ActualizarTablaMedicamentos();
                    PonerBotonesMedicamentosEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("Medicamento No se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Medicamentos med = dtgMedicamentos.SelectedItem as Medicamentos;
                med.Nombre = txbMedicamentosNombre.Text;
                med.CantidadCompra = double.Parse(txbMedicamentosCantidadCompra.Text);
                med.CantidadVenta = double.Parse(txbMedicamentosCantidadVenta.Text);
                med.Categoria = txbMedicamentosCategoria.Text;
                med.Descripcion = txbMedicamentosDescripcion.Text;


                if (manejadorMedicamentos.Modificar(med))
                {
                    MessageBox.Show("Medicamento modificado correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposoDeMedicamentos();
                    ActualizarTablaMedicamentos();
                    PonerBotonesMedicamentosEnEdicion(false);
                }
                else
                {
                    MessageBox.Show("Medicamento No se pudo actualizar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void btnMedicamentosCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposoDeMedicamentos();
            PonerBotonesMedicamentosEnEdicion(false);
        }

        private void btnMedicamentosEliminar_Click(object sender, RoutedEventArgs e)
        {
            Medicamentos med = dtgMedicamentos.SelectedItem as Medicamentos;
            if (med != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar este Medicamento", "Trabajo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorMedicamentos.Eliminar(med.Id))
                    {
                        MessageBox.Show("Medicamento eliminado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaMedicamentos();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Medicamento", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }
        //=========================================================================================================================================================
        enum accionVe
        {
            Nuevo,
            Editar
        }

        IManejadorVales manejadorVales;

        accionVe accionVale;
        private void btnVentaAceptar_Click(object sender, RoutedEventArgs e)
        {

            if (accionVale == accionVe.Nuevo)
            {
                Vale val = new Vale()
                {
                    Cliente = txbValeCliente.Text,
                    Rfc = txbValeRFC.Text,
                    Direccion = txbValeDireccion.Text,
                    Email = txbValeEmail.Text,
                    Telefono = txbValeTel.Text

                };
                if (manejadorVales.Agregar(val))
                {
                    MessageBox.Show("Venta agregada correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    // LimpiarCamposDeVales();
                    ActualizarTablaVales();
                    PonerBotonesValeEnEdicion(true);

                }
                else
                {
                    MessageBox.Show("La venta No se pudo agregar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Vale val = dtgVale.SelectedItem as Vale;
                val.Cliente = txbValeCliente.Text;
                val.Direccion = txbValeDireccion.Text;
                val.Email = txbValeEmail.Text;
                val.Rfc = txbValeRFC.Text;
                val.Telefono = txbValeTel.Text;
                if (manejadorVales.Modificar(val))
                {
                    MessageBox.Show("Venta correctamente", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposDeVales();
                    ActualizarTablaVales();

                }
                else
                {
                    MessageBox.Show("La Venta No se pudo actualizar", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void btnVentaNueva_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeVales();
            PonerBotonesValeEnEdicion(true);
            accionVale = accionVe.Nuevo;

        }

        private void btnVentaCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposDeVales();
            PonerBotonesValeEnEdicion(false);
        }

        private void btnVentaEliminar_Click(object sender, RoutedEventArgs e)
        {
            Vale val = dtgVale.SelectedItem as Vale;
            if (val != null)
            {
                if (MessageBox.Show("Realmente deseas eliminar esta Venta", "{0}", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (manejadorVales.Eliminar(val.Id))
                    {
                        MessageBox.Show("Venta eliminado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaVales();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la venta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void btnVentaGenerarVenta_Click(object sender, RoutedEventArgs e)
        {
            string ruta = ".txt";
            Object selectedItem = cmbVentaEmpleado.SelectedItem;
            ArchivoVenta1 archivo = new ArchivoVenta1();
            if (archivo.Genrar(txbValeCliente.Text, txbValeRFC.Text, txbValeTel.Text, txbValeDireccion.Text, txbValeEmail.Text, selectedItem.ToString(), manejadorVales.Listar, empleadosAr, ruta, contador, totalPagar, dineroRecibido, cambio, empleadosAr2))
            {
                MessageBox.Show("Ticket generado", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Information);
                LimpiarCamposDeVales();
                PonerBotonesValeEnEdicion(false);
                Array.Clear(empleadosAr, 1, contador);
                Array.Clear(empleadosAr2, 1, contador2);
                totalPagar = 0;
                dineroRecibido = 0;
                cambio = 0;
                contador = 1;
                contador = 1;
            }
            else
            {
                MessageBox.Show("No se pudo generar el Ticket", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        int contador = 1;
        string[] empleadosAr = new string[10];
        private void cmbVentaEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void cmbVentaMedicamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Medicamentos medica = new Medicamentos();

            Object selectedItemEm = cmbVentaMedicamento.SelectedItem;
            empleadosAr[contador] = selectedItemEm.ToString();
            contador += 1;
        }
        int contador2 = 1;
        double[] empleadosAr2 = new double[10];

        private void cmbVentaPresio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Presio presio = new Presio();
            Object selectedItemPr = cmbVentaPresio.SelectedItem;
            empleadosAr2[contador] = double.Parse(selectedItemPr.ToString());
            contador2 += 1;

        }
        double totalPagar = 0;
        private void btnVentaTotalPagar_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= contador2; i++)
            {
                totalPagar = totalPagar + empleadosAr2[i];

            }
            txbVentaTotalPagar.Text = totalPagar.ToString();
        }
        double dineroRecibido;
        double cambio;
        private void btnVentaCalcular_Click(object sender, RoutedEventArgs e)
        {
            dineroRecibido = double.Parse(txbVentaDinaroRecibido.Text);
            if (dineroRecibido >= totalPagar)
            {
                cambio = dineroRecibido - totalPagar;
                txbVentaCambio.Text = cambio.ToString();
            }
            else
            {
                MessageBox.Show("No se pudo Realizar la venta", "Trabajo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
