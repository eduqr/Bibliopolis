using bibliopolis.Context;
using bibliopolis.Entities;
using bibliopolis.Services;
using bibliopolis.Validations;
using bibliopolis.Views;
using bibliopolis.Views.LibrariansViews;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace bibliopolis.UserControls
{
    /// <summary>
    /// Lógica de interacción para Loan.xaml
    /// </summary>
    public partial class LoanControl : UserControl
    {
        public LoanControl()
        {
            InitializeComponent();
        }

        private bool StudenIsRegistered = false;

        private void BTN_Next_Click(object sender, RoutedEventArgs e)
        {
            var textBoxesToValidate = new List<TextBox>
            {
                TXT_RegistrationNumber,
                TXT_Name,
                TXT_Lastname,
                TXT_Email,
                TXT_PhoneNumber
            };

            if (InputValidator.AreTextBoxesEmpty(textBoxesToValidate))
            {
                MessageBox.Show("Por favor, llene todos los campos.");
                return;
            }

            if (!InputValidator.IsNumber(TXT_RegistrationNumber.Text))
            {
                MessageBox.Show("Por favor, ingrese una matrícula válida");
                return;
            }

            if (CB_Carrer.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un programa educativo");
                return;
            }

            if (!InputValidator.IsValidEmail(TXT_Email.Text))
            {
                MessageBox.Show("Por favor, ingrese un correo válido");
                return;
            }

            if (!InputValidator.IsNumber(TXT_PhoneNumber.Text))
            {
                MessageBox.Show("Por favor, ingrese un número de teléfono válido");
                return;
            }

            string registrationNumber = TXT_RegistrationNumber.Text;

            using (var _context = new ApplicationDbContext())
            {
                bool hasOverdueLoans = _context.Loans.Any(loan =>
                     loan.RegistrationNumber == registrationNumber &&
                     loan.Status == Loan.LoanStatus.Vencido);

                if (hasOverdueLoans)
                {
                    MessageBox.Show("El alumno tiene préstamos vencidos pendientes. No se puede realizar un nuevo préstamo.");
                    return;
                }
            }

            StatusBar.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F0720B"));
            StatusTwo.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F0720B"));

            SP_BookForm.Visibility = Visibility.Visible;
            SP_StudenForm.Visibility = Visibility.Collapsed;
        }

        private void BTN_Back_Click(object sender, RoutedEventArgs e)
        {
            StatusBar.Fill = Brushes.Transparent;
            StatusTwo.Fill = Brushes.Transparent;

            SP_StudenForm.Visibility = Visibility.Visible;
            SP_BookForm.Visibility = Visibility.Collapsed;
        }

        private void BTN_Cancel_Click(object sender, RoutedEventArgs e)
        {
            TXT_RegistrationNumber.Text = string.Empty;
            TXT_Name.Text = string.Empty;
            TXT_Lastname.Text = string.Empty;
            CB_Carrer.SelectedIndex = -1;
            TXT_Email.Text = string.Empty;
            TXT_PhoneNumber.Text = string.Empty;
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                HomeMenu homeMenu = new HomeMenu();
                homeMenu.Show();
                parentWindow.Close();
            }
            EnableStudentsComponents();
        }

        private void BTN_Confirm_Click(object sender, RoutedEventArgs e)
        {
            var textBoxesToValidate = new List<TextBox>
            {
                TXT_ISBN,
                TXT_Title,
                TXT_Author
            };
            
            if (InputValidator.AreTextBoxesEmpty(textBoxesToValidate))
            {
                MessageBox.Show("Por favor, ingrese un ISBN existente");
                return;
            }

            if (InputValidator.IsObjectNull(DP_LoanDate.SelectedDate) || InputValidator.IsObjectNull(DP_DueDate.SelectedDate))
            {
                MessageBox.Show("Por favor, seleccione las fechas del préstamo");
                return;
            }

            if (DP_LoanDate.SelectedDate < DateTime.Today || DP_DueDate.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Por favor, revise las fechas del préstamo, no se puede seleccionar una fecha ya pasada");
                return;
            }

            BookServices services = new BookServices();
            LoanServices loanServices = new LoanServices();

            if (!StudenIsRegistered)
            {
                StudentServices studentServices = new StudentServices();
                Student student = new Student();
                student.RegistrationNumber = TXT_RegistrationNumber.Text;
                student.Name = TXT_Name.Text;
                student.LastName = TXT_Lastname.Text;
                student.Career = CB_Carrer.Text;
                student.Mail = TXT_Email.Text;
                student.PhoneNumber = TXT_PhoneNumber.Text;
                studentServices.AddStudent(student);
            }
            
            Loan newLoan = new Loan();
            
            newLoan.RegistrationNumber = TXT_RegistrationNumber.Text;
            newLoan.ISBN = TXT_ISBN.Text;
            newLoan.LoanDate = (DateTime)DP_LoanDate.SelectedDate;
            newLoan.DueDate = (DateTime)DP_DueDate.SelectedDate;
            newLoan.Status = Loan.LoanStatus.Activo;
            loanServices.AddLoan(newLoan);
            MessageBox.Show("Préstamo guardado con éxito, será redirigido al menú principal");
            
            services.UpdateUnits(TXT_ISBN.Text, "REMOVE_UNIT");

            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                HomeMenu homeMenu = new HomeMenu();
                homeMenu.Show();
                parentWindow.Close();
            }

        }

        private void TXT_RegistrationNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            StudentServices services = new StudentServices();
            string registrationNumber = TXT_RegistrationNumber.Text;
            if (!InputValidator.IsStringEmpty(registrationNumber))
            {
                if (services.StudentExists(registrationNumber))
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        var student = _context.Students.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

                        if (!InputValidator.IsObjectNull(student))
                        {
                            TXT_Name.Text = student.Name;
                            TXT_Lastname.Text = student.LastName;
                            CB_Carrer.Text = student.Career;
                            TXT_Email.Text = student.Mail;
                            TXT_PhoneNumber.Text = student.PhoneNumber;
                            StudenIsRegistered = true;
                            DisableStudentsComponents();
                        }
                    }
                }
                else
                {
                    EnableStudentsComponents();
                }
            }
        }

        private void TXT_ISBN_LostFocus(object sender, RoutedEventArgs e)
        {
            BookServices services = new BookServices();
            string isbn = TXT_ISBN.Text;
            if (!InputValidator.IsStringEmpty(isbn))
            {
                if (services.BookExists(isbn))
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        var book = _context.Books.FirstOrDefault(x => x.ISBN == isbn);

                        if (book.Units < 1)
                        {
                            MessageBox.Show("No hay unidades disponibles para prestar por el momento", "Libro: " + book.Title + " no disponible");
                            return;
                        }

                        if (!InputValidator.IsObjectNull(book))
                        {
                            TXT_Title.Text = book.Title;
                            TXT_Author.Text = book.Author;
                            LBL_AvailableUnits.Content = "Unidades disponibles: " + book.Units.ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Si se trata de un libro nuevo inicie sesión con una cuenta de Super Admin para registrar el libro", "Libro no encontrado", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void EnableStudentsComponents()
        {
            TXT_Name.IsEnabled = true;
            TXT_Lastname.IsEnabled = true;
            CB_Carrer.IsEnabled = true;
            TXT_Email.IsEnabled = true;
            TXT_PhoneNumber.IsEnabled = true;
        }

        private void DisableStudentsComponents()
        {
            TXT_Name.IsEnabled = false;
            TXT_Lastname.IsEnabled = false;
            CB_Carrer.IsEnabled = false;
            TXT_Email.IsEnabled = false;
            TXT_PhoneNumber.IsEnabled = false;
        }

    }
}
