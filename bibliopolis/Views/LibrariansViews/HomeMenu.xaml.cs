using bibliopolis.Context;
using bibliopolis.Entities;
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
            UpdateBooksStats();
            UpdateLoanStats();
            UpdateTodayLoanStats();
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

        private void UpdateBooksStats()
        {
            using (var _context = new ApplicationDbContext())
            {
                int amountBooks = _context.Books.Count();
                if (amountBooks == 1)
                {
                    LBL_BookStats.Content = amountBooks + " libro registrado";
                }
                else
                {
                    LBL_BookStats.Content = amountBooks + " libros registrados";
                }
            }
        }

        private void UpdateLoanStats()
        {
            using (var _context = new ApplicationDbContext())
            {
                int activeLoansCount = _context.Loans.Count(loan => loan.Status == Loan.LoanStatus.Activo);
                int overdueLoansCount = _context.Loans.Count(loan => loan.Status == Loan.LoanStatus.Vencido);

                string activeLoansText = activeLoansCount == 1 ? "1 préstamo activo" : activeLoansCount + " préstamos activos";
                string overdueLoansText = overdueLoansCount == 1 ? "1 vencido" : overdueLoansCount + " vencidos";

                if (activeLoansCount > 0 && overdueLoansCount > 0)
                {
                    LBL_LoanStats.Content = $"{activeLoansText}, {overdueLoansText}";
                }
                else if (activeLoansCount > 0)
                {
                    LBL_LoanStats.Content = activeLoansText;
                }
                else if (overdueLoansCount > 0)
                {
                    LBL_LoanStats.Content = overdueLoansText;
                }
                else
                {
                    LBL_LoanStats.Content = "0 préstamos activos";
                }
            }
        }

        private void UpdateTodayLoanStats()
        {
            using (var _context = new ApplicationDbContext())
            {
                DateTime today = DateTime.Today;
                int amountDueLoans = _context.Loans.Count(loan => loan.DueDate.Date == today.Date);
                if (amountDueLoans == 1)
                {
                    LBL_TodayLoanStats.Content = amountDueLoans + " préstamo vence hoy";
                }
                else
                {
                    LBL_TodayLoanStats.Content = amountDueLoans + " préstamos vencen hoy";
                }
            }
        }
    }
}
