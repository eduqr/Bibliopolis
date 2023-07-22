using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace bibliopolis.Validations
{
    public class InputValidator
    {
        public static bool IsObjectNull(object obj)
        {
            return obj == null;     // Retorna true si se cumple que obj sea null
        }
        public static bool IsStringEmpty(string str)
        {
            return string.IsNullOrWhiteSpace(str); //Retorna true si hay un string vacío
        }

        public static bool IsNumber(string text)
        {
            return int.TryParse(text, out _); //Convierte un string a numero
        }

        public static bool ValidateNumericTextBox(TextBox textBox)
        {
            if (!int.TryParse(textBox.Text, out _))
            {
                
                textBox.Text = string.Empty;
                textBox.Focus();
                return false;
            }
            return true;
        }
        public static bool IsValidEmail(string email)
        {
            return email.Contains("@"); //Valida que el correo contenga "@"
        }

    }
}
