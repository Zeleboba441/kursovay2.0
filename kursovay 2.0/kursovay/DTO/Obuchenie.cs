using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovay.DTO
{
    [Table("postavka reagentov")]
    public class Obuchenie : BaseDTO
    {
        [Column("idpersonal")]
        public int ReagentID { get; set; }
        [Column("idvrach")]
        public int VrachID { get; set; }
    }
}