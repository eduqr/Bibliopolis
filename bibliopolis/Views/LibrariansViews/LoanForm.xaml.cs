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

            SetFormTwo();
        }

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_Return_Click(object sender, RoutedEventArgs e)
        {
            StatusBar.Fill = Brushes.White;
            StatusTwo.Fill = Brushes.White;

            SetFormOne();
        }

        private void SetFormOne()
        {
            StatusStudent.Visibility = Visibility.Visible;
            StatusBook.Visibility = Visibility.Collapsed;

            LBL_RegistrationNumber.Visibility = Visibility.Visible;
            TXT_RegistrationNumber.Visibility = Visibility.Visible;

            TXT_ISBN.Visibility = Visibility.Collapsed;
            LBL_ISBN.Visibility = Visibility.Collapsed;

            LBL_Name.Visibility = Visibility.Visible;
            TXT_Name.Visibility = Visibility.Visible;

            LBL_Title.Visibility = Visibility.Collapsed;
            TXT_Title.Visibility = Visibility.Collapsed;

            LBL_Lastname.Visibility = Visibility.Visible;
            TXT_Lastname.Visibility = Visibility.Visible;

            LBL_Author.Visibility = Visibility.Collapsed;
            TXT_Author.Visibility = Visibility.Collapsed;

            LBL_Carrer.Visibility = Visibility.Visible;
            CB_Carrer.Visibility = Visibility.Visible;
            LBL_ContactInfo.Visibility = Visibility.Visible;
            LBL_Email.Visibility = Visibility.Visible;
            LBL_PhoneNumber.Visibility = Visibility.Visible;
            TXT_Email.Visibility = Visibility.Visible;
            TXT_PhoneNumber.Visibility = Visibility.Visible;

            LBL_LoanInfo.Visibility = Visibility.Collapsed;
            LBL_DateLoan.Visibility = Visibility.Collapsed;
            DP_DateLoan.Visibility = Visibility.Collapsed;
            LBL_DateDue.Visibility = Visibility.Collapsed;
            DP_DateDue.Visibility = Visibility.Collapsed;

            BTN_Next.Visibility = Visibility.Visible;
            BTN_Return.Visibility = Visibility.Collapsed;
            BTN_Save.Visibility = Visibility.Collapsed;
        }

        private void SetFormTwo()
        {
            StatusStudent.Visibility = Visibility.Collapsed;
            StatusBook.Visibility = Visibility.Visible;

            LBL_RegistrationNumber.Visibility = Visibility.Collapsed;
            TXT_RegistrationNumber.Visibility = Visibility.Collapsed;

            TXT_ISBN.Visibility = Visibility.Visible;
            LBL_ISBN.Visibility = Visibility.Visible;

            LBL_Name.Visibility = Visibility.Collapsed;
            TXT_Name.Visibility = Visibility.Collapsed;

            LBL_Title.Visibility = Visibility.Visible;
            TXT_Title.Visibility = Visibility.Visible;

            LBL_Lastname.Visibility = Visibility.Collapsed;
            TXT_Lastname.Visibility = Visibility.Collapsed;

            LBL_Author.Visibility = Visibility.Visible;
            TXT_Author.Visibility = Visibility.Visible;

            LBL_Carrer.Visibility = Visibility.Collapsed;
            CB_Carrer.Visibility = Visibility.Collapsed;
            LBL_ContactInfo.Visibility = Visibility.Collapsed;
            LBL_Email.Visibility = Visibility.Collapsed;
            LBL_PhoneNumber.Visibility = Visibility.Collapsed;
            TXT_Email.Visibility = Visibility.Collapsed;
            TXT_PhoneNumber.Visibility = Visibility.Collapsed;

            LBL_LoanInfo.Visibility = Visibility.Visible;
            LBL_DateLoan.Visibility = Visibility.Visible;
            DP_DateLoan.Visibility = Visibility.Visible;
            LBL_DateDue.Visibility = Visibility.Visible;
            DP_DateDue.Visibility = Visibility.Visible;

            BTN_Next.Visibility = Visibility.Collapsed;
            BTN_Return.Visibility = Visibility.Visible;
            BTN_Save.Visibility = Visibility.Visible;
        }
    }
}
