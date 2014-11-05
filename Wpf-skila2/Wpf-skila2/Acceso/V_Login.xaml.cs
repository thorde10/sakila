using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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

namespace Wpf_skila2.Acceso
{
    /// <summary>
    /// Lógica de interacción para V_Login.xaml
    /// </summary>
    public partial class V_Login : Window
    {
        public V_Login()
        {
            InitializeComponent();
        }

        private void verificaAcceso(object sender, RoutedEventArgs e)
        {
            /* Obtiene usuario y clave desde ventana*/
            string v_usuario_ingresado = txt_usuario.Text;
            string v_clave_ingresada = txt_password.Password.ToString();

            /* Verifica que los identificadores no estén vacíos. Si es vacío muestra un mensaje y limpia las cajas de texto.*/
            if (String.IsNullOrEmpty(v_usuario_ingresado) || String.IsNullOrEmpty(v_clave_ingresada))
            {
                MessageBox.Show("No pueden ser valores nulos");
                txt_usuario.Clear();
                txt_password.Clear();
            }
            /* Si los datos no vienen vacíos*/
            else
            {
                /* Encripta la clave en algoritmo sha1*/
                string clave_encriptada = encriptarSha1(v_clave_ingresada);
                /* Determina si existen o no resultados (La consulta encontró coincidencia o no)*/
                Boolean existe_resultado = verificaUsuarioClave(v_usuario_ingresado, clave_encriptada);


                try
                {
                    /* Si se encontró coincidencia de usuario y clave muestra la ventana principal y cierra la ventana de login.
                     Si no encuentra muestra un mensaje*/
                    if (existe_resultado)
                    {
                        MainWindow principal = new MainWindow();
                        principal.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o clave incorrecta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error :" + ex.Message);
                }


            }
        }
        private bool verificaUsuarioClave(string v_usuario_ingresado, string clave_encriptada)
        {
            try
            {
                SqlConnection conecta_sakila = new SqlConnection(ConfigurationManager.ConnectionStrings["WPF_Sakila.Properties.Settings.sakilaConnectionString"].ToString());
                SqlCommand consulta_credencial = new SqlCommand("select 1 from staff where username =@v_usuario and password=@v_password", conecta_sakila);
                consulta_credencial.Parameters.AddWithValue("@v_usuario", v_usuario_ingresado);
                consulta_credencial.Parameters.AddWithValue("@v_password", clave_encriptada);

                conecta_sakila.Open();
                SqlDataReader consulta_datos = consulta_credencial.ExecuteReader();
                consulta_datos.Read();
                if (consulta_datos.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error" + ex.Message);
                return false;
            }

        }


        private string encriptarSha1(string v_clave_ingresada)
        {
            UTF8Encoding codificacionCaracteres = new UTF8Encoding();
            byte[] bytes_clave_ingresada = codificacionCaracteres.GetBytes(v_clave_ingresada);

            SHA1CryptoServiceProvider encriptarSHA1 = new SHA1CryptoServiceProvider();
            string clave_encriptada = BitConverter.ToString(encriptarSHA1.ComputeHash(bytes_clave_ingresada)).Replace("-", "");
            return clave_encriptada;
        }
    }
}
