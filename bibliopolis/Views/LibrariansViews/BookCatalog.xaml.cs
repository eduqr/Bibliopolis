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
    /// Lógica de interacción para BookCatalog.xaml
    /// </summary>
    public partial class BookCatalog : Window
    {
        BookServices services = new BookServices();
        private bool isEditMode;

        public BookCatalog()
        {
            InitializeComponent();
            GetBooksTable();
        }

        private void GetBooksTable()
        {
            DataGridBooks.ItemsSource = services.GetBooks();
        }

        private void BTN_GoBack_Click(object sender, RoutedEventArgs e)
        {
            HomeMenu HomeMenu = new HomeMenu();
            Close();
            HomeMenu.Show();
        }

        private void BTN_CopyItem_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();

            book = (sender as FrameworkElement).DataContext as Book;

            Clipboard.SetText(book.ISBN);
            MessageBox.Show("Contenido copiado al portapapeles: " + book.ISBN, "ISBN copiado", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
