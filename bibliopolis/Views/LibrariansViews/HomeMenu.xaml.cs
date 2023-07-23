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

        //private void BTN_ManageStudent_Click(object sender, RoutedEventArgs e)
        //{
        //    Students students = new Students();
        //    Close();
        //    students.Show();
        //}


    }
}
