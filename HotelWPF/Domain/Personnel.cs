using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class Personnel
    {
        public short id_employee { get; set; }
        public int id_room { get; set; }
        public string FIO { get; set; }
        public string position { get; set; }
        public string phone { get; set; }
    }
}
