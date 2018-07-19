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


        public void add(string username, string phone, string email, string password)
        {
            if (username == "" || phone == "" || email == "" || password == "")
            {
                MessageBox.Show("Please fill out all the fields.");
            }
            else
            {
                //manager.addEmployee(username,email,phone,password);
                MessageBox.Show("New employee has been added.");
            }
        }
    }
}
