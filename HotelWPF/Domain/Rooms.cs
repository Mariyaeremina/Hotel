using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class Rooms
    {
        public short id_employee { get; set; }
        public int id_client { get; set; }
        public int id_room { get; set; }
        public int id_category { get; set; }
        public Nullable<short> price { get; set; }
        public Nullable<int> place_cnt { get; set; }
        public Nullable<int> busy_place { get; set; }
        public Nullable<int> id_hotel { get; set; }
    }
}
