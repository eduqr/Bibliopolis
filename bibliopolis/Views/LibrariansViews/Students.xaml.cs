using bibliopolis.Context;
using bibliopolis.Entities;
using bibliopolis.Services;
using bibliopolis.Validations;
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

namespace bibliopolis.Views.LibrariansViews
{
    /// <summary>
    /// Lógica de interacción para Students.xaml
    /// </summary>
    public partial class Students : Window
    {
        Librarian librarian = new Librarian();

        
        public Students()
        {
            
            InitializeComponent();
            StudentTable.ItemsSource = null;

        }
        

        StudentServices services = new StudentServices();

        private bool isEditMode = false;

       
        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!InputValidator.IsNumber(TXT_Matricula.Text) || !InputValidator.IsNumber(TXT_PhoneNumberStudent.Text))
                {
                    MessageBox.Show("Por favor, asegúrese de que la matrícula y el número sean valores numéricos.");
                    return;
                }

                // Verificar si la dirección de correo electrónico contiene el símbolo "@"
                if (!InputValidator.IsValidEmail(TXT_MailStudent.Text))
                {
                    MessageBox.Show("Por favor, ingrese una dirección de correo electrónico válida.");
                    return;
                }
                
                Student student = new Student();
                student.Matricula = TXT_Matricula.Text;
                student.Name = TXT_NameStudent.Text;
                student.LastName = TXT_LastnameStudent.Text;
                student.Mail = TXT_MailStudent.Text;
                student.PhoneNumber = TXT_PhoneNumberStudent.Text;
                student.Career = SelectCareer.Text;

                if (isEditMode)
                {
                    services.UpdateStudent(student);
                    MessageBox.Show("Estudiante editado correctamente");
                    isEditMode = false; // Restablecer la bandera después de guardar los cambios en modo de edición
                }
                else
                {
                    if (InputValidator.IsNumber(TXT_Matricula.Text))
                    {
                        services.AddStudent(student);
                    }
                }
                

                GetStudentsTableForLibrarian();
                TXT_Matricula.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el estudiante: {ex.Message}");
            }
        }


        private void BTN_EditItem_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            student = (sender as FrameworkElement).DataContext as Student;


            TXT_Matricula.Text = student.Matricula;
            TXT_Matricula.IsEnabled = false; // Deshabilitar el TextBox para que no se pueda editar la matrícula
            TXT_NameStudent.Text = student.Name;
            TXT_LastnameStudent.Text = student.LastName;
            TXT_MailStudent.Text = student.Mail;
            TXT_PhoneNumberStudent.Text = student.PhoneNumber;
            SelectCareer.Text = student.Career;

            isEditMode = true; // Establecer la bandera en modo de edición

        }

        

       
        private void BTN_GoBack_Click(object sender, RoutedEventArgs e)
        {
            SuperAdminMenu SuperAdminWindow = new SuperAdminMenu();
            Close();
            SuperAdminWindow.Show();
        }

        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            TXT_Matricula.Clear();
            TXT_NameStudent.Clear();
            TXT_LastnameStudent.Clear();
            TXT_MailStudent.Clear();
            TXT_PhoneNumberStudent.Clear();
            SelectCareer.SelectedIndex = -1;
            TXT_Matricula.IsEnabled = true;
        }

        public void GetStudentsTableForLibrarian()
        {
           
                // Limpiar la tabla de estudiantes (ponerla vacía)
                StudentTable.ItemsSource = services.GetStudents();        
        }

    }
}
