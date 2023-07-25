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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bibliopolis.Views.LibrariansViews
{
    /// <summary>
    /// Lógica de interacción para LoanForm.xaml
    /// </summary>
    public partial class LoanForm : Window
    {
        public LoanForm()
        {
            InitializeComponent();
        }

        public void BTN_Next_Click(object sender, RoutedEventArgs e)
        {
            StatusBar.Fill = Brushes.Black;
            StatusTwo.Fill = Brushes.Black;
        }
    }
}
