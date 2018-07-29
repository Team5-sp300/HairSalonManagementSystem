using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHsystem.Controllers
{
    class ClientController
    {
        DatabaseManager manager = new DatabaseManager();
        
        public void add(string name, string surname, string phone, string email)
        {
            if (name == "" || surname == "" || phone == "" || email == "")
            {
                MessageBox.Show("Please fill out all the fields.");
            }
            else
            {
                manager.addClient(name, surname, phone, email);
                MessageBox.Show("New client has been added.");
            }
        }

    }
}
