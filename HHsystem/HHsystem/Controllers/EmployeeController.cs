using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHsystem.Controllers
{
    class EmployeeController
    {
        DatabaseManager manager = new DatabaseManager();


        public void add(string uname, string fname, string lname, string phone, string email, string password, int type)
        {
            if (uname == "" || fname == "" || lname == "" || phone == "" || email == "" || password == "")
            {
                MessageBox.Show("Please fill out all the fields.");
            }
            else
            {
                manager.addEmployee(uname, fname, lname, email, phone, password, type);                
                MessageBox.Show("New employee has been added.");
            }
        }
    }
}
