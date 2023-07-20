using bibliopolis.Entities;
using bibliopolis.Services;
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

                if (int.TryParse(possiblePk, out int existPk))
                {
                    Student student = new Student();

                    student.Matricula = TXT_Matricula.Text;
                    student.Name = TXT_NameStudent.Text;
                    student.LastName = TXT_LastnameStudent.Text;
                    student.Mail = TXT_MailStudent.Text;
                    student.PhoneNumber = TXT_PhoneNumberStudent.Text;
                    student.Career = SelectCareer.Text;

                    services.AddStudent(student);

                    GetStudentsTable();
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
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"Error al guardar el estudiante: {ex.Message}");
            }
        }


        public void GetStudentsTable()
            {
                StudentTable.ItemsSource = services.GetStudents();
            }
    }
}
