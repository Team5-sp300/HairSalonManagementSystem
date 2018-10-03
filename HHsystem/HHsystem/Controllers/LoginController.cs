using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHsystem.Controllers
{
    class LoginController
    {
        DatabaseManager manager = new DatabaseManager();
        int admincheck;

        public void login(string username, string password, MainForm f)
        {
            for (int i = 0; i < manager.login().GetLength(0); i++)
            {
                if (username.Equals(manager.login()[i, 0]) && password.Equals(manager.login()[i, 1]))
                {
                    if (int.Parse(manager.login()[i, 2]) == 1)
                    {
                        f.adminLogin();
                    }
                    else
                    {
                        f.stylistLogin();
                    }
                    admincheck = int.Parse(manager.login()[i, 2]);
                    MessageBox.Show("Logged in as " + username);
                    break;
                }
                else if (i.Equals(manager.login().GetLength(0)-1))
                {
                    MessageBox.Show("Incorrect Username/Password");
                }
            }
        }
    }
}
