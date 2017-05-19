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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Infrastructure;

namespace HotelWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button.Click += (sender, args) => entryOnSystem();
        }

        private void entryOnSystem()
        {
            string hotelCode;
            try
            {
                checkFullField();
            }
            catch(Exception ex)
            {
                var result = MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                hotelCode = Authorization.Authorize(textBox1.Text, textBox2.Text);
                Main window = new Main(hotelCode);
                window.Show();
            }
            catch
            {
                MessageBox.Show("Введенные данные не верны. Попробуйте еще раз.");
                return;
            }
        }

        private void checkFullField()
        {
            if (textBox1.Text == "" || textBox2.Text == "" )
            {
                throw new Exception("Заполнены не все поля");
            }
        }
    }
}
