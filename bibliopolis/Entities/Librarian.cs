using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliopolis.Entities
{
    public class Librarian
    {
        [Key]
        public int PkLibrarian { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        
        [ForeignKey("Roles")]
        public int FkRole { get; set; }
        public Role Roles { get; set; }
    }
}
