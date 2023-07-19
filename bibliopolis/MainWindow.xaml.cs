using bibliopolis.Services;
using bibliopolis.Views;
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
            login.GenerateSuperAdmin();
        }

        public void BTN_Login_Click(object sender, RoutedEventArgs e)
        {
            string mail = TXT_Mail.Text;
            string password = TXT_Password.Password;

            var role = login.Login(mail, password);

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
    }
}
