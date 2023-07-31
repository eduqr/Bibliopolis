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
            return string.IsNullOrWhiteSpace(str);  // Retorna true si hay un string vacío
        }

        public static bool IsNumber(string text)
        {
            return int.TryParse(text, out _);   // Retorna true si text es un número
        }

        public static bool IsValidEmail(string email)
        {
            return email.Contains("@");     // Retorna true si email contiene "@"
        }

        public static bool AreTextBoxesEmpty(IEnumerable<TextBox> textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
