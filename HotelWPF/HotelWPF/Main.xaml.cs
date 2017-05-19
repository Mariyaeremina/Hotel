using ApplicationLogic;
using Domain;
using System;
using System.Collections.Generic;
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

namespace HotelWPF
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main(string hotelCode)
        {
            InitializeComponent();
            
            Hotel hotel = new Hotel();
            hotel = Logic.GetHotel(hotelCode);
            label1.Content = hotel.Name;
            label2.Content = hotel.Adress;
            label3.Content = hotel.Phone;

            button1.Click += (sender, args) =>
            {
                RoomSearch window = new RoomSearch(hotelCode, "Регистрация");
                window.Show();
            };
        }
    }
}
