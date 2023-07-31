using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliopolis.Entities
{
    public class Loan
    {
        [Key]
        public int PkLoan { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public LoanStatus Status { get; set; }

        [ForeignKey("Students")]
        public string RegistrationNumber { get; set; }
        public Student Students { get; set; }

        [ForeignKey("Books")]
        public string ISBN { get; set; }
        public Book Books { get; set; }

        public enum LoanStatus
        {
            Activo,
            Vencido,
            Devuelto,
        }
    }
}
