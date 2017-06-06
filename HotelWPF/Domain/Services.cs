using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class Services
    {
        public int id_service { get; set; }
        public string name_service { get; set; }
        public Nullable<int> price_service { get; set; }
        public Nullable<int> id_client { get; set; }
    }
}
