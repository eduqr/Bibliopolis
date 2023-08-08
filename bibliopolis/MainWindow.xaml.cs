using bibliopolis.Services;
using bibliopolis.Validations;
using bibliopolis.Views;
using bibliopolis.Views.SuperAdminViews;
using Renci.SshNet.Messages;
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

namespace bibliopolis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginServices login = new LoginServices();
        public MainWindow()
        {
            InitializeComponent();
            login.GenerateRoles();
            login.GenerateSuperAdmin();

            // Suscribirse al evento PreviewKeyDown del control de contraseña (TXT_Password)
            TXT_Password.PreviewKeyDown += TXT_Password_PreviewKeyDown;
        }

        public void BTN_Login_Click(object sender, RoutedEventArgs e)
        {
            string mail = TXT_Mail.Text;
            string password = TXT_Password.Password;

            var role = login.Login(mail, password);


            if (InputValidator.IsObjectNull(role) && !InputValidator.IsStringEmpty(mail) && !InputValidator.IsStringEmpty(password))
            {
                MessageBox.Show("Credenciales incorrectas");
                return;
            }

            if (InputValidator.IsObjectNull(role))
            {
                MessageBox.Show("Todos los campos son obligatorios");
                return;
            }

            if (role.Roles.Name == "Super Admin")
            {
                SuperAdminMenu superAdminMenu = new SuperAdminMenu();
                Close();
                superAdminMenu.Show();
            }
            else if (role.Roles.Name == "Bibliotecario")
            {

                HomeMenu home = new HomeMenu();
                Close();
                home.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TXT_Password_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Verificar si se presionó la tecla "Enter"
            if (e.Key == Key.Enter)
            {
                // Ejecutar el código del botón de login (BTN_Login_Click)
                BTN_Login_Click(sender, e);
            }
        }
    }
}
