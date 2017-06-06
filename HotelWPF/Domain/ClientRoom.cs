using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class ClientRoom
    {
        public int id_room { get; set; }
        public string FIO { get; set; }
        public int id_client { get; set; }
        public Nullable<System.DateTime> arrival_date { get; set; }
        public Nullable<System.DateTime> departure_date { get; set; }
    }
}
