﻿using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
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
using System.Windows.Shapes;

namespace ProyectoFinal.UI.Registros
{
    /// <summary>
    /// Interaction logic for rUsuario.xaml
    /// </summary>
    public partial class rUsuario : Window
    {
        private Usuarios usuario = new Usuarios();
        public rUsuario()
        {
            InitializeComponent();
            this.DataContext = usuario;
        }
        private void BtnBuscar(object sender, RoutedEventArgs e)
        {
            if (TextUsuarioId.Text.Length == 0)
            {

                MessageBox.Show("ID vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else if (!UsuarioBLL.Existe(Convert.ToInt32(TextUsuarioId.Text)))
            {
                Limpiar();
                MessageBox.Show("El registro no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var usuario = UsuarioBLL.Buscar(Convert.ToInt32(TextUsuarioId.Text));
            if (usuario != null)
            {
                Limpiar();
                this.usuario = usuario;

            }
            else
                Limpiar();

           /* if (usuario.Activo == CheckActivo.Content.ToString())
                CheckActivo.IsChecked = true;*/


            this.DataContext = this.usuario;
        }

        private void BtnNuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            this.usuario = new Usuarios();
            this.DataContext = usuario;
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            //TextClave.Password = string.Empty;
            //CheckActivo.IsChecked = false;
        }
        private bool Validar()
        {
            bool esValido = true;
            if (TextUsuarioId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextUsuario.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            if (TextNombre.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
            /*if (TextEmail.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }*/
            if (TextClave.Password.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }
           /* if (TextRolId.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }*/
           /* if (!Utilidades.Validar_Email(TextEmail.Text))
            {
                esValido = false;
                MessageBox.Show("Email no valido ", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return esValido;
            }*/
            return esValido;
        }
        private void BtnGuardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            // usuario.Clave = TextClave.Password;
            var paso = UsuarioBLL.Guardar(usuario);

            if (paso)
            {

                Limpiar();
                MessageBox.Show("Transaccion Exitosa", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnEliminar(object sender, RoutedEventArgs e)
        {
          /*  if (TextUsuarioId.Text.Length != 0)
            {

                if (!UsuarioBLL.Existe(Convert.ToInt32(TextUsuarioId.Text)))
                {
                    MessageBox.Show("El registro no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("ID vacio", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (TextUsuarioId.Text.Length == 0 || TextAlias.Text.Length == 0 || TextNombre.Text.Length == 0 || TextEmail.Text.Length == 0 || TextClave.Password.Length == 0 || TextRolId.Text.Length == 0)
            {
                MessageBox.Show("Para eliminar un registro primero debe buscarlo", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }*/

            if (UsuarioBLL.Eliminar(Convert.ToInt32(TextUsuarioId.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
