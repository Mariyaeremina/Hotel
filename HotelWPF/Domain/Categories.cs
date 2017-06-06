using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public partial class Categories
    {
        public int id_category { get; set; }
        public string name { get; set; }
        public Nullable<int> room_cnt { get; set; }
    }
}
