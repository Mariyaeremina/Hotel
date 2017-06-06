using ApplicationLogic;
using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ViewModel;

namespace HotelWPF
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class RoomSearch : Window
    {
        public RoomSearch(string hotelCode, string registrationOrReserve)
        {
            InitializeComponent();
            Title = registrationOrReserve;
            DataContext = new RoomSearchViewModel(hotelCode);
        }
    }
}
