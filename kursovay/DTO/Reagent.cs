using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovay.DTO
{
    [Table("reagents")]
    public class Reagent : BaseDTO
    {
        [Column("name")]
        public string Name { get; set; }

    }
}
