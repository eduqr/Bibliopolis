using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace bibliopolis.Messages
{
    public class MessageToUser
    {
        public static void ShowInfo(string message, string title = "Información")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ShowWarning(string message, string title = "Advertencia")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public static void ShowError(string message, string title = "Error")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool ShowConfirmation(string message, string title = "Confirmación")
        {
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}

