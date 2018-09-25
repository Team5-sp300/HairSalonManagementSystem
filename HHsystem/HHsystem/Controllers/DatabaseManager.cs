using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            conn = new MySqlConnection("Server=localhost; database=HairSalon; UID=root; password=;SslMode=none;Allow User Variables=True");
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
            conn.Close();
            return adapter;
        }

        public string[,] getEmployeeDetails()
        {
            string[,] employeeDetails = null;
            string command = "Call getEmployee";
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

                employeeDetails = new string[arrySize, 6];

                cmd = new MySqlCommand(command, conn);
                result = cmd.ExecuteReader();

                while (result.Read())

                {
                    employeeDetails[i, 0] = result[0].ToString();
                    employeeDetails[i, 1] = result[1].ToString();
                    employeeDetails[i, 2] = result[2].ToString();
                    employeeDetails[i, 3] = result[3].ToString();
                    employeeDetails[i, 4] = result[4].ToString();
                    employeeDetails[i, 5] = result[5].ToString();
                    i++;
                }
            }
            return employeeDetails;
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

        public MySqlDataAdapter getBookingHistory(string id)
        {
            try
            {
                
                string command = "Call getBookingHistory (?id)";
                connection();
                cmd = new MySqlCommand(command, conn);
                cmd.Parameters.AddWithValue("?id", id);

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

        public MySqlDataAdapter getEmployeeSchedule(string id)
        {
            try
            {
                string command = "Call getEmployeeSchedule (?username)";
                connection();
                cmd = new MySqlCommand(command, conn);
                cmd.Parameters.AddWithValue("?username", id);

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

        public string[,] getBookingDetails()
        {
            string[,] bookingDetails = null;
            string command = "Call getBookingDetails";
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

                bookingDetails = new string[arrySize, 4];

                cmd = new MySqlCommand(command, conn);
                result = cmd.ExecuteReader();

                while (result.Read())

                {
                    bookingDetails[i, 0] = result[0].ToString();
                    bookingDetails[i, 1] = result[1].ToString();
                    bookingDetails[i, 2] = result[2].ToString();
                    bookingDetails[i, 3] = result[3].ToString();
                    i++;
                }
            }
            return bookingDetails;
        }

        public string[,] getServiceDetails()
        {
            string[,] serviceDetails = null;
            string command = "Call getService";
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

                serviceDetails = new string[arrySize, 3];

                cmd = new MySqlCommand(command, conn);
                result = cmd.ExecuteReader();

                while (result.Read())

                {
                    serviceDetails[i, 0] = result[0].ToString();
                    serviceDetails[i, 1] = result[1].ToString();
                    serviceDetails[i, 2] = result[2].ToString();
                    i++;
                }
            }
            return serviceDetails;
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

        public string[,] getClientDetails()
        {
            string[,] clientDetails = null;
            string command = "Call getCustomer";
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

                clientDetails = new string[arrySize, 5];

                cmd = new MySqlCommand(command, conn);
                result = cmd.ExecuteReader();

                while (result.Read())

                {
                    clientDetails[i, 0] = result[0].ToString();
                    clientDetails[i, 1] = result[1].ToString();
                    clientDetails[i, 2] = result[2].ToString();
                    clientDetails[i, 3] = result[3].ToString();
                    clientDetails[i, 4] = result[4].ToString();
                    i++;
                }
            }
            return clientDetails;
        }
                
        public string[,] getClientDetails(string fname,string lname)
        {
            string[,] clientDetails = null;
            string command = "Call getCustomerDetails(?fname,?lname)";
            connection();
            cmd.Parameters.AddWithValue("?fname", fname);
            cmd.Parameters.AddWithValue("?lname", lname);
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

                clientDetails = new string[arrySize, 4];

                cmd = new MySqlCommand(command, conn);
                result = cmd.ExecuteReader();

                while (result.Read())

                {
                    clientDetails[i, 0] = result[0].ToString();
                    clientDetails[i, 1] = result[1].ToString();
                    clientDetails[i, 2] = result[2].ToString();
                    clientDetails[i, 3] = result[3].ToString();
                    i++;
                }
            }
            return clientDetails;
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

        
        public void addEmployee(string uname, string fname, string lname, string email, string phone, string password)
        {
            string command = "CALL insertEmployee(?username,?fname,?lname,?email,?phone,?password)";
            connection();
            MessageBox.Show(command);
            cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("?username", uname);
            cmd.Parameters.AddWithValue("?fname", fname);
            cmd.Parameters.AddWithValue("?lname", lname);
            cmd.Parameters.AddWithValue("?email", email);
            cmd.Parameters.AddWithValue("?phone", phone);
            cmd.Parameters.AddWithValue("?password", password);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void addBooking(string cfname, string clname, string efname, string elname, string adate, string atime, string service)
        {
            string command = "CALL insertBooking(?cfname,?clname,?efname,?elname,?adate,?atime,?service)";
            connection();
            MessageBox.Show(command);
            cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("?cfname", cfname);
            cmd.Parameters.AddWithValue("?clname", clname);
            cmd.Parameters.AddWithValue("?efname", efname);
            cmd.Parameters.AddWithValue("?elname", elname);
            cmd.Parameters.AddWithValue("?adate", adate);
            cmd.Parameters.AddWithValue("?atime", atime);
            cmd.Parameters.AddWithValue("?service", service);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void addClient(string name, string surname, string phone, string email)
        {
            string command = "CALL insertClient(?fname, ?lname, ?email, ?phone)";
            connection();
            MessageBox.Show(command);
            cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("?fname", name);
            cmd.Parameters.AddWithValue("?lname", surname);
            cmd.Parameters.AddWithValue("?email", phone);
            cmd.Parameters.AddWithValue("?phone", email);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void updateClient(string id,string name, string surname, string phone, string email)
        {
            string command = "CALL updateClient(?id,?fname, ?lname, ?email, ?phone)";
            connection();
            MessageBox.Show("Updated");
            cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("?id", id);
            cmd.Parameters.AddWithValue("?fname", name);
            cmd.Parameters.AddWithValue("?lname", surname);
            cmd.Parameters.AddWithValue("?email", phone);
            cmd.Parameters.AddWithValue("?phone", email);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void updateEmployee(string username, string name, string surname, string phone, string email)
        {
            string command = "CALL updateEmployee(?id, ?fname, ?lname, ?email, ?phone)";
            connection();
            MessageBox.Show("Updated");
            cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("?id", username);
            cmd.Parameters.AddWithValue("?fname", name);
            cmd.Parameters.AddWithValue("?lname", surname);
            cmd.Parameters.AddWithValue("?email", phone);
            cmd.Parameters.AddWithValue("?phone", email);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void voidEmployee(string username)
        {
            string command = "CALL voidEmployee(?id)";
            connection();
            cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("?id", username);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void deleteEmployee(string username)
        {
            string command = "CALL deleteEmployee(?id)";
            connection();
            cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("?id", username);
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
