using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliopolis.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] //// Indicar que la clave no será generada automáticamente
        public string Matricula { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Career { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}
