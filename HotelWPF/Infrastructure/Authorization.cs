using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Authorization
    {
        public static string Authorize(string login, string password)
        {
            using (StreamReader reader = new StreamReader("authorization.txt", Encoding.Default))
            {
                string log, pass, hotel;
                while ((log = reader.ReadLine()) != null)
                {
                    pass = reader.ReadLine();
                    hotel = reader.ReadLine();
                    if (log == login && pass == password)
                    {
                        reader.Close();
                        return hotel;
                    }
                }
                throw new Exception("User is not found");
            }
        }
    }
}
