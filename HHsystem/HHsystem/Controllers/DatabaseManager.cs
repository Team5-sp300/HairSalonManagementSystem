using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HHsystem.Controllers
{
    class DatabaseManager
    {
        MySqlConnection conn;

       public void connection() {
            conn = new MySqlConnection("Server=localhost; database=HairSalonDB; UID=root; password=root");
            conn.Open();
        }

        public object[][] bookings() {
            object[][] member=null;
            string commandString = "SELECT * FROM booking";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = commandString;
            MySqlDataReader result = cmd.ExecuteReader();

            int i=0;

            if (result != null)
            {
                while (result.Read())
                {
                    member[i][0] = result["idBooking"].ToString();
                    member[i][1] = result["idCustomer"].ToString();
                    member[i][2] = result["idEmployee"].ToString();
                    i++;
                    Console.WriteLine(member[i][0]);
                }
            }

            return member;
        }
    }
}
