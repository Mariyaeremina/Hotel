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

            List<int> capacities = new List<int>();
            capacities = Logic.GetCapacity(hotelCode);
            for (int i = 0; i < capacities.Count; i++)
            {
                comboBox1.Items.Add(capacities[i]);
            }

            List<string> categories = new List<string>();
            categories = Logic.GetCategory(hotelCode);
            for (int i = 0; i < categories.Count; i++)
            {
                comboBox2.Items.Add(categories[i]);
            }

            if (registrationOrReserve == "Регистрация")
            {
                button1.Click += (sender, args) =>
                {
                    try
                    {
                        checkFields();
                        
                        DataSet ds = new DataSet();
                        ds = Logic.GetFreeRooms(Convert.ToInt32(comboBox1.Text), comboBox2.Text);
                        dataGrid.ItemsSource = ds.Tables[0].DefaultView;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                };
            }
        }

        private void checkFields()
        {
            if (comboBox1.Text == "" || comboBox2.Text == "")
            {
                throw new Exception("Критерии поиска не выбраны");
            }
        }
    }
}
