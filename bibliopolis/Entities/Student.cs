﻿using System;
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]   // Primary key no será auto incrementable
        [Key] 
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Career { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
