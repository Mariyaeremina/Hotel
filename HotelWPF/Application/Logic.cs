using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic
{
    public class Logic
    {
        public static Hotel GetHotel(string hotelCode)
        {
            Hotel hotel = new Hotel();
            HotelDB db = new HotelDB();
            db.QueryExecuteReader("select Адрес, Телефон, Название " +
                                  "from [Гостиница] " + 
                                  "where [Код гостиницы] = " + Convert.ToInt32(hotelCode));
            if (db.reader.Read())
            {
                hotel.address = db.reader["Адрес"].ToString();
                hotel.phone = db.reader["Телефон"].ToString();
                hotel.name = db.reader["Название"].ToString();
                db.CloseConnection();
                return hotel;
            }
            else
            {
                db.CloseConnection();
                throw new ArgumentException("Гостиница не найдена");
            }
        }

        public static DataSet GetFreeRooms(int capacity, string category)
        {
            HotelDB db = new HotelDB();
            db.QueryExecuteReader("SELECT COUNT([Номера].[Код номера]) AS Число " + 
                                    "FROM Категории INNER JOIN Номера ON Категории.[Код категории] = Номера.[Код категории] WHERE [Кол-во мест] = "
                                    + capacity + " AND [Категории].[Название] =\"" + category + "\" AND [Занятые места] = 2");
            db.reader.Read();
            
            if (Convert.ToInt32(db.reader["Число"]) == 0)
            {
                db.CloseConnection();
                throw new ArgumentException("Свободных номеров с выбранными параметрами нет");
            }

            else
            {
                return db.GetDataSet(@"SELECT [Номера].[Код номера] AS Номер, [Категории].[Название] AS Категория, [Стоимость проживания] AS Цена
                                    FROM Категории INNER JOIN Номера ON Категории.[Код категории] = Номера.[Код категории] WHERE [Кол-во мест] = "
                                    + capacity + " AND [Категории].[Название] =\"" + category + "\" AND [Занятые места] = 2");
            }
        }

        public static ObservableCollection<int> GetCapacity(string hotelCode)
        {
            ObservableCollection<int> capacities = new ObservableCollection<int>();
            HotelDB db = new HotelDB();
            db.QueryExecuteReader(@"SELECT DISTINCT [Кол-во мест]
                                    FROM Номера 
                                    WHERE [Код гостиницы] = " + Convert.ToInt32(hotelCode));
            while (db.reader.Read())
            {
                var temp = Convert.ToInt32(db.reader["Кол-во мест"]);
                capacities.Add(temp);
            }
            db.CloseConnection();
            return capacities;
        }

        public static ObservableCollection<string> GetCategory(string hotelCode)
        {
            ObservableCollection<string> categories = new ObservableCollection<string>();
            HotelDB db = new HotelDB();
            db.QueryExecuteReader(@"SELECT DISTINCT [Категории].[Название]
                                    FROM Категории INNER JOIN Номера ON Категории.[Код категории] = Номера.[Код категории]
                                    WHERE [Код гостиницы] = " + Convert.ToInt32(hotelCode));
            while (db.reader.Read())
            {
                var temp = db.reader["Название"].ToString();
                categories.Add(temp);
            }
            db.CloseConnection();
            return categories;
        }

    }
}
