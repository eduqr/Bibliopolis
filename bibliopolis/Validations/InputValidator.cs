using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static bool IsNumber(string srt)
        {
            foreach (char c in srt)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
