using bibliopolis.Views.LibrariansViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bibliopolis.Views
{
    /// <summary>
    /// Lógica de interacción para HomeMenu.xaml
    /// </summary>
    public partial class HomeMenu : Window
    {
        public HomeMenu()
        {
            InitializeComponent();
        }

        private void BTN_ReturnToLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }

        private void BTN_ShowCatalog_Click(object sender, RoutedEventArgs e)
        {
            // Catálogo debe ser flotante
            BookCatalog catalog = new BookCatalog();
            catalog.Show();
        }

        private void BTN_AddLoan_Click(object sender, RoutedEventArgs e)
        {
            LoanForm form = new LoanForm();
            Close();
            form.Show();
        }

        private void BTN_ManageLoan_Click(object sender, RoutedEventArgs e)
        {
            ManageLoan manageLoan = new ManageLoan();
            Close();
            manageLoan.Show();
        }

        private void BTN_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpMenu help = new HelpMenu();
            help.Show();
        }
    }
}
