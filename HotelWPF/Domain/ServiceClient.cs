using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class ServiceClient
    {
        public int id_service { get; set; }
        public int id_client { get; set; }
        public Nullable<int> id_room { get; set; }
    }
}
