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

namespace Wpf_skila2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void agregarPelicula(object sender, RoutedEventArgs e)
        {
            Peliculas.V_AgregarPelicula agregarPelicula = new Peliculas.V_AgregarPelicula();
            agregarPelicula.ShowDialog();
        }

        private void actualizarPelicula(object sender, RoutedEventArgs e)
        {
            Peliculas.V_ActualizarPelicula actualizarPelicula = new Peliculas.V_ActualizarPelicula();
            actualizarPelicula.ShowDialog();
        }

        private void eliminarPelicula(object sender, RoutedEventArgs e)
        {
            Peliculas.V_EliminarPelicula eliminarPelicula = new Peliculas.V_EliminarPelicula();
            eliminarPelicula.ShowDialog();
        }

        private void agregarCliente(object sender, RoutedEventArgs e)
        {
            Clientes.V_AgregarCliente agregarCliente = new Clientes.V_AgregarCliente();
            agregarCliente.ShowDialog();
        }

        private void actualizarCliente(object sender, RoutedEventArgs e)
        {
            Clientes.V_ActualizarCliente actualizarCliente = new Clientes.V_ActualizarCliente();
            actualizarCliente.ShowDialog();
        }

        private void eliminarCliente(object sender, RoutedEventArgs e)
        {
            Clientes.V_EliminarCliente eliminarCliente = new Clientes.V_EliminarCliente();
            eliminarCliente.ShowDialog();
        }

        private void agregarArriendo(object sender, RoutedEventArgs e)
        {
            Arriendos.V_AgregarArriendo agregarArriendo = new Arriendos.V_AgregarArriendo();
            agregarArriendo.ShowDialog();
        }

        private void consultarArriendo(object sender, RoutedEventArgs e)
        {
            Arriendos.V_ConsultarArriendo consultarArriendo = new Arriendos.V_ConsultarArriendo();
            consultarArriendo.ShowDialog();
        }
    }
}
