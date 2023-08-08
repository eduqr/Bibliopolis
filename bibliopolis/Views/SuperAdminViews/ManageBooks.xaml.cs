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

namespace bibliopolis.Views.SuperAdminViews
{
    /// <summary>
    /// Lógica de interacción para ManageBooks.xaml
    /// </summary>
    public partial class ManageBooks : Window
    {
        BookServices services = new BookServices();
        private bool isEditMode;

        public ManageBooks()
        {
            InitializeComponent();
            GetBooksTable();
        }

        private void GetBooksTable()
        {
            DataGridBooks.ItemsSource = services.GetBooks();
        }

        private void BTN_Clear_Click(object sender, RoutedEventArgs e)
        {
            TXT_ISBN.Clear();
            TXT_Title.Clear();
            TXT_Author.Clear();
            TXT_Editorial.Clear();
            TXT_Units.Clear();
            TXT_ISBN.IsEnabled = true;
        }

        private void BTN_GoBack_Click(object sender, RoutedEventArgs e)
        {
            SuperAdminMenu SuperAdminWindow = new SuperAdminMenu();
            Close();
            SuperAdminWindow.Show();
        }

        private void BTN_EditItem_Click(object sender, EventArgs e) // Misma función que en 'ManageStudents.xaml.cs'
        {
            Book book = new Book();

            book = (sender as FrameworkElement).DataContext as Book;


            TXT_ISBN.Text = book.ISBN;
            TXT_ISBN.IsEnabled = false;
            TXT_Title.Text = book.Title;
            TXT_Author.Text = book.Author;
            TXT_Editorial.Text = book.Editorial;
            TXT_Units.Text = book.Units.ToString();  ///////////////////////////

            isEditMode = true;
            GetBooksTable();
        }

        private void BTN_Delete_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();

            book = (sender as FrameworkElement).DataContext as Book;
            string DeletedBook = book.ISBN;
            services.DeleteBook(DeletedBook);
            GetBooksTable();

        }

        private void BTN_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (!InputValidator.IsNumber(TXT_ISBN.Text) || !InputValidator.IsNumber(TXT_Units.Text))
                {
                    MessageBox.Show("Por favor, asegúrese de que el ISBN y el número de existencias sean valores numéricos.");
                    return;
                }
                else
                {

                    Book book = new Book();
                    book.ISBN = TXT_ISBN.Text;
                    book.Title = TXT_Title.Text;
                    book.Author = TXT_Author.Text;
                    book.Editorial = TXT_Editorial.Text;
                    book.Units = int.Parse(TXT_Units.Text);  ///////////////////

                    if (isEditMode)
                    {
                        isEditMode = false;
                        services.UpdateBook(book);
                        MessageBox.Show("Libro editado correctamente");
                    }
                    else
                    {
                        services.AddBook(book);
                    }
                    GetBooksTable();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el libro.\n {ex.Message}");
            }
        }
    }
}
