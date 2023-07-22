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

namespace bibliopolis.Views
{
    /// <summary>
    /// Lógica de interacción para ManageLibrarians.xaml
    /// </summary>
    public partial class ManageLibrarians : Window
    {
        LibrarianServices services = new LibrarianServices();

        public ManageLibrarians()
        {
            InitializeComponent();
            GetLibrariansTable();
            GetRoles();
        }

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            string possiblePk = TXT_PkLibrarian.Text;
            

            if (!int.TryParse(possiblePk, out int existPk))
            {
                Librarian librarian = new Librarian();

                librarian.Name = TXT_Name.Text;
                librarian.Lastname = TXT_Lastname.Text;
                librarian.Mail = TXT_Mail.Text;
                librarian.PhoneNumber = TXT_PhoneNumber.Text;
                librarian.Password = TXT_Password.Text;
                librarian.FkRole = int.Parse(SelectRol.SelectedValue.ToString());
                
                services.AddLibrarian(librarian);
            }
            else
            {
                Librarian librarian = new Librarian();

                librarian.PkLibrarian = int.Parse(TXT_PkLibrarian.Text);
                librarian.Name = TXT_Name.Text;
                librarian.Lastname = TXT_Lastname.Text;
                librarian.Mail = TXT_Mail.Text;
                librarian.PhoneNumber = TXT_PhoneNumber.Text;
                librarian.Password = TXT_Password.Text;
                librarian.FkRole = int.Parse(SelectRol.SelectedValue.ToString());

                services.UptadeLibrarian(librarian);
            }
            GetLibrariansTable();
            // CleanTXTs(); <- No borrar este comentario
        }

        public void BTN_EditItem_Click(object sender, EventArgs e)
        {
            Librarian librarian = new Librarian();

            librarian = (sender as FrameworkElement).DataContext as Librarian;

            TXT_PkLibrarian.Text = librarian.PkLibrarian.ToString();
            TXT_Name.Text = librarian.Name.ToString();
            TXT_Lastname.Text = librarian.Lastname.ToString();
            TXT_Mail.Text = librarian.Mail.ToString();
            TXT_PhoneNumber.Text = librarian.PhoneNumber.ToString();
            TXT_Password.Text = librarian.Password.ToString();

        }

        public void BTN_Delete_Click(object sender, EventArgs e)
        {
            Librarian librarian = new Librarian();

            librarian = (sender as FrameworkElement).DataContext as Librarian;

            int DeletePk = int.Parse(librarian.PkLibrarian.ToString());
            services.DeleteLibraian(DeletePk);
            
            GetLibrariansTable();
        }

        public void GetLibrariansTable()
        {
            LibrarianTable.ItemsSource = services.GetLibrarians();
        }

        public void GetRoles()
        {
            SelectRol.ItemsSource = services.GetRoles();
            SelectRol.DisplayMemberPath = "Name";
            SelectRol.SelectedValuePath = "PkRole";
        }

        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            CleanTXTs();
        }

        public void BTN_GoBack_Click(object sender, RoutedEventArgs e)
        {
            SuperAdminMenu SuperAdminWindow = new SuperAdminMenu();
            Close();
            SuperAdminWindow.Show();
        }

        private void CleanTXTs()
        {
            TXT_PkLibrarian.Clear();
            TXT_Name.Clear();
            TXT_Lastname.Clear();
            TXT_Mail.Clear();
            TXT_PhoneNumber.Clear();
            TXT_Password.Clear();
        }
    }
}
