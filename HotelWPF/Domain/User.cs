using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class User
    {
        public string login { get; set; }
        public Nullable<int> password { get; set; }
        public Nullable<int> id_hotel { get; set; }
        public int id_user { get; set; }
    }
}
