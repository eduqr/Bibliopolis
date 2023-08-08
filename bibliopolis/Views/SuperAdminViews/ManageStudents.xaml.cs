using bibliopolis.Entities;
using bibliopolis.Services;
using bibliopolis.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace bibliopolis.Views
{
    /// <summary>
    /// Lógica de interacción para ManageStudents.xaml
    /// </summary>
    public partial class ManageStudents : Window
    {
        StudentServices services = new StudentServices();
        
        public ManageStudents()
        {
            InitializeComponent();
            GetStudentsTable();

        }
        
        private bool isEditMode = false;
        
        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var textBoxesToValidate = new List<TextBox>
                {
                    TXT_RegistrationNumber,
                    TXT_PhoneNumberStudent,
                    TXT_MailStudent,
                    TXT_LastnameStudent,             
                    TXT_NameStudent,
                };
               

                if (InputValidator.AreTextBoxesEmpty(textBoxesToValidate))
                {
                    MessageBox.Show("Todos los campos son obligatorios");
                    return;
                }

                if (SelectCareer.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, seleccione un programa educativo");
                    return;
                }

                if (!InputValidator.IsNumber(TXT_RegistrationNumber.Text) || !InputValidator.IsNumber(TXT_PhoneNumberStudent.Text))
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
                student.RegistrationNumber = TXT_RegistrationNumber.Text;
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
                    if (InputValidator.IsNumber(TXT_RegistrationNumber.Text))
                    {
                        services.AddStudent(student);
                    }
                }

                GetStudentsTable();
                ClearTextBoxes();
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

            
            TXT_RegistrationNumber.Text = student.RegistrationNumber;
            TXT_RegistrationNumber.IsEnabled = false; // Deshabilitar el TextBox para que no se pueda editar la matrícula
            TXT_NameStudent.Text = student.Name;
            TXT_LastnameStudent.Text = student.LastName;
            TXT_MailStudent.Text = student.Mail;
            TXT_PhoneNumberStudent.Text = student.PhoneNumber;
            SelectCareer.Text = student.Career;

            isEditMode = true; // Establecer la bandera en modo de edición
        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            student = (sender as FrameworkElement).DataContext as Student;

            string DeletePk = student.RegistrationNumber;
            services.DeleteStudent(DeletePk);

            GetStudentsTable();
        }

        public void GetStudentsTable()
        {
                StudentTable.ItemsSource = services.GetStudents();
        }

        private void BTN_GoBack_Click(object sender, RoutedEventArgs e)
        {
            SuperAdminMenu SuperAdminWindow = new SuperAdminMenu();
            Close();
            SuperAdminWindow.Show();
        }

        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            TXT_RegistrationNumber.Clear();
            TXT_NameStudent.Clear();
            TXT_LastnameStudent.Clear();
            TXT_MailStudent.Clear();
            TXT_PhoneNumberStudent.Clear();
            SelectCareer.SelectedIndex = -1;
            TXT_RegistrationNumber.IsEnabled = true;
        }
    }
}
