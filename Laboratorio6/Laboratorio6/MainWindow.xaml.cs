using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Laboratorio6
{
    public partial class MainWindow : Window
    {
        // Actualiza la cadena de conexión con los nuevos datos proporcionados
        private string connectionString = "Data Source=LAB1504-26\\SQLEXPRESS01;Initial Catalog=LAB05;User ID=antony;Password=123456;";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("InsertarCliente", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdCliente", txtIdCliente.Text);
                command.Parameters.AddWithValue("@NombreCompañia", txtNombreCompañia.Text);
                command.Parameters.AddWithValue("@NombreContacto", txtNombreContacto.Text);
                command.Parameters.AddWithValue("@CargoContacto", txtCargoContacto.Text);
                command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                command.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                command.Parameters.AddWithValue("@Region", txtRegion.Text);
                command.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                command.Parameters.AddWithValue("@Pais", txtPais.Text);
                command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                command.Parameters.AddWithValue("@Fax", txtFax.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cliente agregado correctamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar cliente: " + ex.Message);
                }
            }
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("ActualizarCliente", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdCliente", txtIdCliente.Text);
                command.Parameters.AddWithValue("@NombreCompañia", txtNombreCompañia.Text);
                command.Parameters.AddWithValue("@NombreContacto", txtNombreContacto.Text);
                command.Parameters.AddWithValue("@CargoContacto", txtCargoContacto.Text);
                command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                command.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                command.Parameters.AddWithValue("@Region", txtRegion.Text);
                command.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                command.Parameters.AddWithValue("@Pais", txtPais.Text);
                command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                command.Parameters.AddWithValue("@Fax", txtFax.Text);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente actualizado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún cliente con el ID proporcionado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar cliente: " + ex.Message);
                }
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("EliminarCliente", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdCliente", txtIdCliente.Text);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cliente eliminado correctamente.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún cliente con el ID proporcionado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar cliente: " + ex.Message);
                }
            }
        }

        private void txtNombreCompania_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void txtCargoContacto_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
