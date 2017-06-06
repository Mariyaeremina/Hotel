using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class Clients
    {
        public int id_client { get; set; }
        public int id_service { get; set; }
        public Nullable<int> id_room { get; set; }
        public string FIO { get; set; }
        public System.DateTime birth_date { get; set; }
        public string phone { get; set; }
        public Nullable<int> passport_series { get; set; }
        public Nullable<int> passport_number { get; set; }
    }
}
