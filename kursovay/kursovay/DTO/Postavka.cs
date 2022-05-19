using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovay.DTO
{
    [Table("postavka reagentov")]
    public class Postavka : BaseDTO
    {
        [Column("idpostavshik")]
        public int PostavshikID { get; set; }
        [Column("idreagents")]
        public int ReagentID { get; set; }
    }
}
