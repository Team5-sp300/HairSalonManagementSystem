using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        string location;

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

        public string[,] login()
        {
            string[,] loginDetails = null;
            string command = "Call login";
            connection();
            cmd = new MySqlCommand(command, conn);
            MySqlDataReader result = cmd.ExecuteReader();

            int i = 0;
            int arrySize = 0;

            if (result != null)
            {
                while (result.Read())
                {
                    arrySize++;
                }

                result.Close();

                loginDetails = new string[arrySize, 2];

                cmd = new MySqlCommand(command, conn);
                result = cmd.ExecuteReader();

                while (result.Read())

                {
                    loginDetails[i, 0] = result[0].ToString();
                    loginDetails[i, 1] = result[1].ToString();
                    i++;
                }
            }
            return loginDetails;
        }
        
        public void addEmployee(string name, string email, string phone, string password)
        {
            string command = "CALL addEmployee('" + name + "', " + email + "', " + phone + "', " + password + "')";
            connection();
            MessageBox.Show(command);
            cmd = new MySqlCommand(command, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void addClient(string name, string surname, string phone, string email)
        {
            string command = "CALL insertClient(" +name+", " + surname + ", " + phone + ", " + email + ")";
            connection();
            MessageBox.Show(command);
            cmd = new MySqlCommand(command, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void backup()
        {
            string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
            string file = "C:\\backup.sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
        }

        public void restore()
        {
            string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
            string file = "C:\\backup.sql";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ImportFromFile(file);
                        conn.Close();
                    }
                }
            }
        }

    }
}
