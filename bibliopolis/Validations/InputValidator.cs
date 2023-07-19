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
    }
}
