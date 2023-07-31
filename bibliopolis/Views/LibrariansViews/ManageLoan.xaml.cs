using bibliopolis.Entities;
using bibliopolis.Services;
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
    /// Lógica de interacción para ManageLoan.xaml
    /// </summary>
    public partial class ManageLoan : Window
    {
        LoanServices services = new LoanServices();
        public ManageLoan()
        {
            InitializeComponent();
            GetLoansTable();
        }

        public void GetLoansTable()
        {
            LoansTable.ItemsSource = services.GetLoans();
        }

        private void BTN_Return_Click(object sender, RoutedEventArgs e)
        {
            HomeMenu home = new HomeMenu();
            Close();
            home.Show();
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            Loan loan = new Loan();
            loan = (sender as FrameworkElement).DataContext as Loan;

            int DeletedLoan = loan.PkLoan;
            
            LoanServices services = new LoanServices();
            BookServices bookServices = new BookServices();

            services.DeleteLoan(DeletedLoan);
            GetLoansTable();

            bookServices.UpdateUnits(loan.ISBN, "ADD_UNIT");
        }

        private void BTN_UpdateStatus_Click(object sender, RoutedEventArgs e)
        {
            Loan selectedLoan = (sender as FrameworkElement).DataContext as Loan;

            var editStatusWindow = new EditStatusWindow(selectedLoan.Status);

            bool? result = editStatusWindow.ShowDialog();

            if (result == true)
            {
                // Determinar el estado seleccionado por el usuario
                if (editStatusWindow.IsActivo)
                {
                    selectedLoan.Status = LoanStatus.Activo;
                }
                else if (editStatusWindow.IsVencido)
                {
                    selectedLoan.Status = LoanStatus.Vencido;
                }     
                else if (editStatusWindow.IsDevuelto)
                {
                    selectedLoan.Status = LoanStatus.Devuelto;
                    BookServices bookServices = new BookServices();
                    bookServices.UpdateUnits(selectedLoan.ISBN, "ADD_UNIT");
                }

                LoanServices services = new LoanServices();
                services.UpdateStatusLoan(selectedLoan);

                GetLoansTable();
                // LoansTable.Items.Refresh();
            }
        }
    }
}
