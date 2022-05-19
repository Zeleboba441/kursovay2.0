using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovay.DTO
{
    [Table("postavshik")]
    public class Postavshik : BaseDTO
    {      
        [Column("Name")]
        public string Name { get; set; }

     

    }
}
