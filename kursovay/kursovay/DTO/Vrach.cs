﻿using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovay.DTO
{
    [Table("vrach")]
    public class Vrach : BaseDTO
    {
        

        [Column("Name")]
        public string Name { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("gender")]
        public string gender { get; set; }
    }
}
