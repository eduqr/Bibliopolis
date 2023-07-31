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
using static bibliopolis.Entities.Loan;

namespace bibliopolis.Views.LibrariansViews
{
    /// <summary>
    /// Lógica de interacción para EditStatusWindow.xaml
    /// </summary>
    public partial class EditStatusWindow : Window
    {
        public bool IsActivo { get; set; }
        public bool IsVencido { get; set; }
        public bool IsDevuelto { get; set; }

        public EditStatusWindow(LoanStatus currentStatus)
        {
            InitializeComponent();

            IsActivo = currentStatus == LoanStatus.Activo;
            IsVencido = currentStatus == LoanStatus.Vencido;
            IsDevuelto = currentStatus == LoanStatus.Devuelto;

            DataContext = this;
        }

        private void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
