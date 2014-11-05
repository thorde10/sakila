using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Wpf_skila2.Peliculas
{
    /// <summary>
    /// Lógica de interacción para V_AgregarPelicula.xaml
    /// </summary>
    public partial class V_AgregarPelicula : Window
    {
        public V_AgregarPelicula()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Wpf_skila2.sakilaDataSetIdioma sakilaDataSetIdioma = ((Wpf_skila2.sakilaDataSetIdioma)(this.FindResource("sakilaDataSetIdioma")));
            // Cargar datos en la tabla language. Puede modificar este código según sea necesario.
            Wpf_skila2.sakilaDataSetIdiomaTableAdapters.languageTableAdapter sakilaDataSetIdiomalanguageTableAdapter = new Wpf_skila2.sakilaDataSetIdiomaTableAdapters.languageTableAdapter();
            sakilaDataSetIdiomalanguageTableAdapter.Fill(sakilaDataSetIdioma.language);
            System.Windows.Data.CollectionViewSource languageViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("languageViewSource")));
            languageViewSource.View.MoveCurrentToFirst();
        }

        private void guardarPelicula(object sender, RoutedEventArgs e)
        {
            SqlConnection conecta_sakila = new SqlConnection(ConfigurationManager.ConnectionStrings["Wpf_skila2.Properties.Settings.sakilaConnectionString"].ToString());
            SqlCommand inserta_pelicula = new SqlCommand("insert into film(title,description,release_year,language_id,original_language_id,rental_duration,rental_rate,length,replacement_cost,rating,special_features) values(@p_title,@p_description,@p_release_year,@p_language_id,@p_original_language_id,@p_rental_duration,@p_rental_rate,@p_length,@p_replacement_cost,@p_rating,@p_special_features)",conecta_sakila);
            inserta_pelicula.Parameters.AddWithValue("@p_title",txt_titulo.Text.ToUpper());
            inserta_pelicula.Parameters.AddWithValue("@p_description", txt_descripcion.Text);
            inserta_pelicula.Parameters.AddWithValue("@p_release_year", txt_añoRealizacion.Text);
            inserta_pelicula.Parameters.AddWithValue("@p_language_id", cbb_idioma.SelectedValue);
            inserta_pelicula.Parameters.AddWithValue("@p_original_language_id", txt_idiomaOriginal.Text);
            inserta_pelicula.Parameters.AddWithValue("@p_rental_duration", txt_duracionArriendo.Text);
            inserta_pelicula.Parameters.AddWithValue("@p_rental_rate", txt_valorArriendo.Text);
            inserta_pelicula.Parameters.AddWithValue("@p_length", txt_duracionPelicula.Text);
            inserta_pelicula.Parameters.AddWithValue("@p_replacement_cost", txt_costoReemplazo.Text);
            inserta_pelicula.Parameters.AddWithValue("@p_rating", txt_rating.Text);
            inserta_pelicula.Parameters.AddWithValue("@p_special_features", txt_caracteristicasEspeciales.Text);

            try
            {
                conecta_sakila.Open();
                inserta_pelicula.ExecuteNonQuery();
                conecta_sakila.Close();

                MessageBox.Show("Pelicula Ingresada Correctamente","INGRESO CORRETO",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
