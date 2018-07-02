using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HHsystem.Controllers
{
    class DatabaseManager
    {
        MySqlConnection conn;
        MySqlDataAdapter adapter;
        MySqlCommand cmd;

        public void connection()
        {
            conn = new MySqlConnection("Server=localhost; database=HairSalon; UID=root; password=;SslMode=none");
            conn.Open();
        }

        public MySqlDataAdapter getEmployee()
        {
            try
            {
                string command = "Call getEmployee";
                connection();


                cmd = new MySqlCommand(command, conn);
                adapter = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            return adapter;
        }

        public MySqlDataAdapter getBooking()
        {
            try
            {
                string command = "Call getBooking";
                connection();


                cmd = new MySqlCommand(command, conn);
                adapter = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }
            return adapter;
        }

        public MySqlDataAdapter getClients()
        {
            try
            {
                string command = "Call getCustomer";
                connection();


                cmd = new MySqlCommand(command, conn);
                adapter = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
                //throw;
            }
            return adapter;
        }

        public MySqlDataAdapter login()
        {
            try
            {
                string command = "Call login";
                connection();


                cmd = new MySqlCommand(command, conn);
                adapter = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //throw;
            }
            return adapter;
        }
    }
}
