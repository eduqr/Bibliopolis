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

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string possiblePk = TXT_Matricula.Text;
                

                if (!InputValidator.IsNumber(possiblePk))
                {
                    Student student = new Student();

                    student.Matricula = TXT_Matricula.Text;
                    student.Name = TXT_NameStudent.Text;
                    student.LastName = TXT_LastnameStudent.Text;
                    student.Mail = TXT_MailStudent.Text;
                    student.PhoneNumber = TXT_PhoneNumberStudent.Text;
                    student.Career = SelectCareer.Text;

                    services.AddStudent(student);
                    
                       
                }
                else
                {
                    Student student = new Student();

                    student.Matricula = TXT_Matricula.Text;
                    student.Name = TXT_NameStudent.Text;
                    student.LastName = TXT_LastnameStudent.Text;
                    student.Mail = TXT_MailStudent.Text;
                    student.PhoneNumber = TXT_PhoneNumberStudent.Text;
                    student.Career = SelectCareer.Text;

                    services.UpdateStudent(student);
                }

                GetStudentsTable();
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

            TXT_Matricula.IsEnabled= false;

            TXT_Matricula.Text = student.Matricula;
            TXT_NameStudent.Text = student.Name.ToString();
            TXT_LastnameStudent.Text = student.LastName.ToString();
            TXT_MailStudent.Text = student.Mail.ToString();
            TXT_PhoneNumberStudent.Text = student.PhoneNumber.ToString();
            SelectCareer.Text = student.Career.ToString();

        }

        private void BTN_Delete_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            student = (sender as FrameworkElement).DataContext as Student;

            string DeletePk = student.Matricula;
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
            TXT_Matricula.Clear();
            TXT_NameStudent.Clear();
            TXT_LastnameStudent.Clear();
            TXT_MailStudent.Clear();
            TXT_PhoneNumberStudent.Clear();
            SelectCareer.SelectedIndex = -1;
            TXT_Matricula.IsEnabled = true;
        }

        private void NumericTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            
                // Verificar si el contenido es numérico
                if (!int.TryParse(TXT_Matricula.Text, out _))
                {
                    MessageBox.Show("Por favor, ingrese solo números.");
                    TXT_Matricula.Focus();
                }
            
        }

   
    }
}
