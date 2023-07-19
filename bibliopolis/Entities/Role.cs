using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliopolis.Entities
{
    public class Role
    {
        [Key]
        public int PkRole { get; set; }
        public string Name { get; set; }
    }
}
