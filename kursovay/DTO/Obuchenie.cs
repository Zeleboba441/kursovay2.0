using kursovay.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovay.DTO
{
    [Table("obuchenie")]
    public class Obuchenie : BaseDTO
    {
        [Column("idPersonal")]
        public int PersonalID { get; set; }
        [Column("idVrach")]
        public int VrachID { get; set; }
    }
}