using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum Status { Свободно, Занято, Бронь }
    public enum Clean { Убрано, Грязно }

    public class Room
    {
        public int Number;
        public int Price;
        public string Category;
    }
}
