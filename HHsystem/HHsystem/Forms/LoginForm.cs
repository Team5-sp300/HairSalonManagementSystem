using HHsystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHsystem.Forms
{
    public partial class LoginForm : Form
    {
        MainForm mf;
        LoginController lc=new LoginController();

        public LoginForm(MainForm m)
        {
            InitializeComponent();
            mf = m;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (lc.login(getUsername(), getPassword(), mf).Equals(true))
            {
                this.mf.labelloggedin.Text = getUsername();
                this.Dispose();
            }
        }

        public string getUsername() {
            return usernametxt.Text;
        }

        public string getPassword()
        {
            return passwordtxt.Text;
        }

    }
}
