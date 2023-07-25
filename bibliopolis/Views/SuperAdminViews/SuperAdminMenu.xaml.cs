using bibliopolis.Views.SuperAdminViews;
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

namespace bibliopolis.Views
{
    /// <summary>
    /// Lógica de interacción para SuperAdminMenu.xaml
    /// </summary>
    public partial class SuperAdminMenu : Window
    {
        public SuperAdminMenu()
        {
            InitializeComponent();
        }

        private void BTN_ManageLibrarians_Click(object sender, RoutedEventArgs e)
        {
            ManageLibrarians manageWindow = new ManageLibrarians();
            Close();
            manageWindow.Show();
        }

        private void BTN_ManageStudents_Click(object sender, RoutedEventArgs e)
        {
            ManageStudents managestudents = new ManageStudents();
            Close();
            managestudents.Show();
        }

        private void BTN_ManageBooks_Click(object sender, RoutedEventArgs e)
        {
            ManageBooks managebooks = new ManageBooks();
            Close();
            managebooks.Show();
        }

        private void BTN_ReturnToLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            Close();
            login.Show();
        }
    }
}
